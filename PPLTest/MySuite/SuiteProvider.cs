using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Reflection;
using System.Data;
using PPLTest.ClassLib;
using System.IO;
using System.Configuration;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace PPLTest.MySuite
{
    public class SuiteProvider
    {
        #region Declare the global variables 
        //Creat an instance of  excel files operator
        private XLSDataReader myDataReader = new XLSDataReader();
        //Creat an instance of  xml files operator
        private XmlHelper myXmlOperater = new XmlHelper();
        //Creat a instance of  log writer
        private Log mylogwriter = new Log();
        //Creat a instance of general service provider
        private CommonServices myServer = new CommonServices();

        //Creat a datatable to chache the information of every cases
        public static DataTable MyCasesDataTable;

        //set current testing environment
        public static int SeleniumServerPort;
        public static string TestingEnvironment_url;
        public static string TestingEnvironment_login;

        //set the save path for the images which were generated when error occured
        public static string TestResult_log_Path;
        //set the save path for the log which were generated when error occured
        public static string TestResult_Img_Path;
        //set the save path for the test result
        public static string TestReportSavePath;

        //gte the output directory
        private string EnvironmenDirectory = global::System.Environment.CurrentDirectory;

        //
        private StringBuilder CreatSuiteError;

        //2011/3/10
        public static string TimeOutSpan;
        public static string StateName;
        public static string Enviorment;
        public static string ConnectionString;
            
        #endregion

        #region Constructor of SuiteProvider
        /// <summary>
        /// constructor
        /// </summary>
        public SuiteProvider()
        {
        }
        #endregion

        #region Get data from the excel and generate the suite
        /// <summary>
        /// Reading the config file and get the save paths of the  integration testing cases
        /// </summary>
        /// <returns>The List of all cases</returns>
        public ArrayList GetConfigSuite()
        {
            string configXML = EnvironmenDirectory + "\\Config.xml";

            CreatSuiteError = new StringBuilder();
            #region Get the information about log , screen shot images and config file's saved path from the App.config
            //Get the which envirement to use
            string[] weburl = Regex.Split(myXmlOperater.GetNodeValue(configXML, "Settings/URL").Trim(), ".com/");
            TestingEnvironment_url = weburl[0].Trim() + ".com/";
            TestingEnvironment_login = "/" + weburl[1].Trim();

            //Get the Config file path from the App.config
            string configXlsx = myXmlOperater.GetNodeValue(configXML, "Settings/Config").Trim();

            TimeOutSpan = myXmlOperater.GetNodeValue(configXML, "Settings/TimeOutSpan").Trim();
            Enviorment = myXmlOperater.GetNodeValue(configXML, "Settings/Envior").Trim();
            ConnectionString = ConfigurationManager.AppSettings["mySQLconnectionString"].ToString();


            string configSavePath = EnvironmenDirectory + configXlsx;
            //Get current server port from the app.config 
            SeleniumServerPort = int.Parse(myXmlOperater.GetNodeValue(configXML, "Settings/RC_Port").Trim());
            //Get the screen shot images save path from the App.config (create a new folder if not exist)
            TestResult_Img_Path = EnvironmenDirectory + ConfigurationManager.AppSettings["ScrnImageSavePath"].ToString();
            if (!Directory.Exists(TestResult_Img_Path))
            {
                Directory.CreateDirectory(TestResult_Img_Path);
            }
            //Get the log save path from the App.config (create a new folder if not exist)
            TestResult_log_Path = EnvironmenDirectory + ConfigurationManager.AppSettings["LogSavePath"].ToString();
            if (!Directory.Exists(TestResult_log_Path))
            {
                Directory.CreateDirectory(TestResult_log_Path);
            }
            #endregion

            #region  Creat the test report file in xml format
            StateName = configXlsx.Substring(configXlsx.LastIndexOf('_') + 1, configXlsx.LastIndexOf('.') - configXlsx.LastIndexOf('_') - 1);
            //Creat the filename for the testreport by adding its' creat time into it
            string fileName = "TestReport_" + StateName + "(" + myServer.FileName("TestReport") + ").xml";
            //Combin the fullname for by adding the save path to the filename
            TestReportSavePath = global::System.Environment.CurrentDirectory + @"\TestResult\" + fileName;
            //Creat the test report file in xml  format
            myXmlOperater.CreateXmlDocument(TestReportSavePath, "test-results", "utf-8", StateName);
            #endregion

            #region Select the integration testing cases and get their info from the excel files 
            //Read all the integration testing cases information from the file
            DataTable myConfigInfo=new DataTable();
            try
            {
                myConfigInfo = this.GetAllData(configSavePath);
            }
            catch
            {
                CreatSuiteError.AppendLine("The " + configSavePath + " is not exist, please check in App.config ");
            }
            //Count the numbers of the integrations
            int Integrations = myConfigInfo.Rows.Count;
            //Define a dictionary to store the selected integrations' info
            List<string> MySuiteInfo = new List<string>();
            //prepar a hashtable to store the newly added integration testing case's attrbuites
            Hashtable suiteAttribute = new Hashtable();
            int suiteID = 0;
            //Iterates through all the  integration testing cases and choose the one marked "used"
            for (int i = 0; i < Integrations; i++)
            {
                //Select the integration testing cases and record them into the dictionary
                if (myConfigInfo.Rows[i][0].ToString().Trim().ToUpper() == "USE")
                {
                    //get the save path of the excel which current selected integration testing case's data was saved in
                    string IntegrationPath = EnvironmenDirectory + myConfigInfo.Rows[i]["SuiteInfoPath"].ToString();
                    //add info to the dictionary
                    MySuiteInfo.Add(IntegrationPath);

                    #region Add a suite node with the attrbuite in the report

                    //Set the suite ID
                    suiteAttribute.Add("ID", "Suite" + suiteID.ToString());
                    //Creat the suite Name
                    int startSub = IntegrationPath.LastIndexOf("\\") + 1;
                    suiteAttribute.Add("Int_Name", IntegrationPath.Substring(startSub, IntegrationPath.IndexOf('.') - startSub));
                    //
                    suiteAttribute.Add("Int_Program", myConfigInfo.Rows[i]["Program"].ToString());
                    //
                    suiteAttribute.Add("Int_Role", myConfigInfo.Rows[i]["Role"].ToString());

                    //new role node
                    //
                    suiteAttribute.Add("Int_MenuName", myConfigInfo.Rows[i]["MenuName"].ToString());
                    //
                    suiteAttribute.Add("Int_Subfunction", myConfigInfo.Rows[i]["Subfunction"].ToString());
                    //Add the suite description
                    suiteAttribute.Add("Int_Description", myConfigInfo.Rows[i]["Description"].ToString());

                    //Save the change of report
                    myXmlOperater.InsertNode(TestReportSavePath, "test-suite", suiteAttribute, "test-results");

                    suiteAttribute.Clear();
                    #endregion

                    suiteID += 1;
                
                }
            }
            #endregion

            //Generate the test suite
            return this.suite(MySuiteInfo);
        }

        /// <summary>
        /// Get info about the single cases included in the  integration testing cases through its' saved path 
        /// Turn the cases' names to classes and composed them to a testsuite
        /// Generate the test suite and Create a new empty report
        /// </summary>
        /// <param name="SuiteInfo">the  integration testing cases' saved path and their description </param>
        /// <returns>test suite</returns>
        private ArrayList suite(List<string> SuiteInfo)
        {
            //declare an arraylist to record the cases of the suite
            ArrayList MySuite = new ArrayList();
           
            #region Creat the suite
            if (SuiteInfo == null)
            {
                CreatSuiteError.Append("No integrations in the suite ! \r\n\r\n");
            }
            else
            {
                try
                {
                    //Creat an assembly instance of current executing one 
                    Assembly a = Assembly.GetExecutingAssembly();

                    #region  Creat an instance of the public static datatable to storage every case's information
                    MyCasesDataTable = new DataTable();
                    //add case description
                    MyCasesDataTable.Columns.Add("Description", typeof(string));
                    //add the save path of case data
                    MyCasesDataTable.Columns.Add("DataPath", typeof(string));
                    //select  row from the case data for current test 
                    MyCasesDataTable.Columns.Add("dataRow", typeof(string));
                    #endregion

                    #region  Get cases from the integration testing cases one by one, storage the cases' info and update the xml report

                    //Initialize the suite's record ID
                    int testSuiteID = 0;

                    foreach (string IntegrationDataPath in SuiteInfo)
                    {
                        try
                        {
                            //record current shuite node's Xpath in the xml report
                            string CurrentSuiteElement = @"//test-results/test-suite[@ID='" + "Suite" + testSuiteID.ToString() + "']";
                            //Initialize the case ID of current suite 
                            int testcaseID = 0;

                            #region get information of every cases in current Integration testing case
                            DataTable mydatetable = new DataTable();
                            try
                            {
                                //Read data from the excel
                                mydatetable = this.GetAllData(IntegrationDataPath);
                            }
                            catch (Exception ex)
                            {
                                CreatSuiteError.Append("SuiteProvider Error:can't find table " + IntegrationDataPath + " \r\n" + ex.Message + ex.TargetSite + "\r\n\r\n");
                            }
                            //count the cases number of currrent Integration testing case
                            int caseNum = mydatetable.Rows.Count;

                            //record last stepdescription
                            string LastStepDes = "";
                            //if the RowID was multi-id
                            int subtractNum = 0;

                            for (int i = 0; i < caseNum; i++)
                            {
                                string MultiRow = mydatetable.Rows[i]["RowID"].ToString().Trim();

                                if (MultiRow == "")//current case includes several steps
                                {
                                    #region  add step descriptions directly
                                    for (int m = testcaseID; m >= testcaseID - subtractNum; m--)//???????????????????1704???????????????????
                                    {
                                        Hashtable StepDesAttribute = new Hashtable();
                                        StepDesAttribute.Add("StepDes", mydatetable.Rows[i]["StepDescription"].ToString().Trim());
                                        myXmlOperater.InsertNode(TestReportSavePath, "StepDescription", StepDesAttribute, CurrentSuiteElement + @"//test-case[@ID=" + m.ToString() + "]");
                                        StepDesAttribute.Clear();
                                    }
                                    #endregion
                                }
                                else//come to next case
                                {
                                    #region clip the rowID(combined by rowname and rownum) to find which single data to use for current case

                                    //clip the rowID to find which data to use for current case
                                    string[] Rows = MultiRow.Split('-');
                                    //clip the rowID to get the rowname of rowID 
                                    string[] StartRow = myServer.ClipName(Rows[0]);
                                    string rowname = StartRow[0].Trim();

                                    #region    get the start rownum of rowID
                                    int startNum = 0;
                                    try
                                    {
                                        startNum = int.Parse(StartRow[1].Trim());
                                    }
                                    catch { }
                                    #endregion

                                    int EndNum = startNum;
                                    if (Rows.Length > 1)//if several data need this time ,the end rownum should be different
                                    {
                                        string[] EndRow = myServer.ClipName(Rows[1]);
                                        EndNum = int.Parse(EndRow[1].Trim());
                                    }
                                    subtractNum = EndNum - startNum;

                                    #endregion

                                    #region add cases to the suite and cases' info to the report
                                    for (int j = startNum; j <= EndNum; j++)
                                    {

                                        testcaseID += 1;

                                        #region get the Class type of current case by reflect current executing assembly and add it to suite
                                        string myAction = "";
                                        try
                                        {
                                            myAction = mydatetable.Rows[i]["ActionName"].ToString().Trim();
                                            Type type = a.GetType("PPLTest.TestCases." + myAction);
                                            if (type == null)
                                            {
                                                CreatSuiteError.Append("SuiteProvider Error: (suiteID-" + testSuiteID.ToString() + ")  The " + myAction + " case script is not in current assembly \r\n");
                                            }
                                            MySuite.Add(type);
                                        }
                                        catch (Exception ex)
                                        {
                                            CreatSuiteError.Append("SuiteProvider Error:"+testSuiteID.ToString()+" The " + myAction + "case script is not in current assembly \r\n" + ex.Message + ex.TargetSite + "\r\n\r\n");
                                        }
                                        #endregion

                                        #region storge current case info in a new row of the static datatable to
                                        try
                                        {
                                            //
                                            DataRow NewRow = MyCasesDataTable.NewRow();
                                            NewRow["Description"] = mydatetable.Rows[i]["DetailDescription"].ToString().Trim();
                                            //
                                            NewRow["DataPath"] = EnvironmenDirectory + mydatetable.Rows[i]["DataPath"].ToString().Trim();
                                            //combin rowID again
                                            NewRow["dataRow"] = rowname + j.ToString();
                                            MyCasesDataTable.Rows.Add(NewRow);
                                        }
                                        catch (Exception ex)
                                        {
                                            CreatSuiteError.Append("SuiteProvider Error: on suite  " + testSuiteID.ToString() + "\r\n" + ex.Message + ex.TargetSite + "\r\n\r\n");
                                        }
                                        #endregion

                                        #region  add the current case's info to current integration testing case for ther eport
                                        Hashtable caseAttribute = new Hashtable();
                                        caseAttribute.Add("ID", testcaseID.ToString());
                                        caseAttribute.Add("Name", myAction);
                                        myXmlOperater.InsertNode(TestReportSavePath, "test-case", caseAttribute, CurrentSuiteElement);
                                        caseAttribute.Clear();

                                        Hashtable StepDesAttribute = new Hashtable();
                                        string stepdes = mydatetable.Rows[i]["StepDescription"].ToString().Trim();
                                        if (stepdes != "")
                                        {
                                            //add step description
                                            StepDesAttribute.Add("StepDes", stepdes);
                                            LastStepDes = stepdes;
                                        }
                                        else
                                        {
                                            //this step contain several cases ,current case's step description was the last one
                                            StepDesAttribute.Add("StepDes", LastStepDes);
                                        }
                                        myXmlOperater.InsertNode(TestReportSavePath, "StepDescription", StepDesAttribute, CurrentSuiteElement + @"//test-case[@ID=" + testcaseID.ToString() + "]");
                                        StepDesAttribute.Clear();
                                        #endregion
                                    }
                                    #endregion
                                }
                            }
                            #endregion

                            #region count the total steps of currrent integration testing case for report
                            Hashtable suiteAttribute = new Hashtable();
                            suiteAttribute.Add("TotalStep", testcaseID.ToString());
                            myXmlOperater.UpdateNode(TestReportSavePath, CurrentSuiteElement, suiteAttribute);
                            suiteAttribute.Clear();
                            #endregion

                            testSuiteID += 1;
                        }
                        catch (Exception ex)
                        {
                            CreatSuiteError.Append("Error happend in :" + IntegrationDataPath+ ex.Message + ex.StackTrace);
                        }
                    }

                    #region   add the total number of integration testing cases to the report
                    Hashtable resultAttribute = new Hashtable();
                    resultAttribute.Add("Total", SuiteInfo.Count.ToString());
                    myXmlOperater.UpdateNode(TestReportSavePath, "test-results", resultAttribute);
                    resultAttribute.Clear();
                    #endregion

                    #endregion

                    #region   Add a EndTest which will stop test and creat the test report
                    Type MyType = a.GetType("PPLTest.TestCases.EndTest");
                    MySuite.Add(MyType);
                    #endregion
                }
                catch (Exception ex)
                {
                    CreatSuiteError.Append(ex.Message + ex.StackTrace);
                }
            }
            #endregion

            #region If there were any error happened during the loading period , the suite will be cleared and return null
            if (CreatSuiteError.ToString() != "")
            {
                //
                mylogwriter.WriteLog(CreatSuiteError.ToString());
                //
                MySuite.Clear();
                //
                Process.Start("explorer.exe", TestResult_log_Path);
            }
            #endregion

            return MySuite;
        }
        #endregion

        /// <summary>
        /// Get the information of integration testing cases  from the excel files
        /// </summary>
        /// <param name="Path">the save path of the excel files</param>
        /// <returns>a table contains all the inegrationtesting cases info included case name, save path of case data…… </returns>
        private DataTable GetAllData(string Path)
        {
            myDataReader.MyExcelPath = Path;
            return myDataReader.GetData();
        }
    }
}