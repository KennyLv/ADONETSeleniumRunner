using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;
using System.Xml;
using PPLTest.ClassLib;
using PPLTest.MySuite;
using NUnit.Framework;
using Selenium;
using System.Threading;
using System.Collections;
using System.Data.SqlClient;
using MySqlOperator;


namespace PPLTest.TestCases
{
    public class BaseCase
    {
        #region Declare the global variables
        //
        private Log MyLogWriter = new Log();
        private XLSDataReader MyExcelDataReader = new XLSDataReader();
        private CommonServices MyServices = new CommonServices();
        private XmlHelper MyXMLOperater = new XmlHelper();
        private DataBase MyDBOperater = new DataBase();


        private DBHelper mySQL = new DBHelper(SuiteProvider.ConnectionString);



        //a static xml operater using in the static constructor of BaseCase
        private static XmlDocument XMLOperater = new XmlDocument();
        //
        public static ISelenium selenium;
        //sting builder for verify error message
        public StringBuilder verificationErrors = new StringBuilder();

        //set the define of timeOut
        public static string  timeOutSpan;

        ///index for current case
        private static int CurrentID;
        //index for current integration testing case
        private static int CurrentIntegrationID = 1;
        //private int CurrentIntegrationFailedNum = 0;
        //private int CurrentIntegrationAssertNum = 0;
        private static int CurrentIntegrationSucceedCaseNum = 0;
        private string CurrentIntgrationXPath;

        //the needed info of current case
        private DataTable CurrentCaseDataTable;
        private DataRow CurrentCaseDataRow;
        //the saving path of the excel data for current case
        private string CurrentCaseDataSavePath;
        //the index of current case in current integration tesing case
        private static int CurrentCaseID = 0;
        //the location of current case in xml report 
        private string CurrentCaseXPath;
        //the start/end time of current case 
        private TimeSpan CurrentCaseStartTime;
        private TimeSpan CurrentCaseEndTime;
        //the result of current case
        private string CurrentCaseResult;
        private bool isLastCase = false;

        private string SearchTime = "";
        //the list of the random data using in current case
        private List<string> RandomRegularData = new List<string>();
        private int RegularDataNum = 0;
        #endregion

        #region  Constructors of BaseCase
        static BaseCase()
        {
            //initialize the case id
            CurrentID = -1;
            //creat the instance of the only selenium
            int serverPort = SuiteProvider.SeleniumServerPort;
            string weburl = SuiteProvider.TestingEnvironment_url;
            timeOutSpan = SuiteProvider.TimeOutSpan;
            // for prep   https://fmsdev.publicpartnerships.com/Portalprep/
            selenium = new DefaultSelenium("localhost", serverPort, "*chrome", weburl);
            //start the selenium
            selenium.Start();
            //write the start time of the whole test  into report
            XMLOperater.Load(SuiteProvider.TestReportSavePath);
            XmlElement myresults = (XmlElement)XMLOperater.SelectSingleNode("test-results");
            myresults.SetAttribute("Time", DateTime.Now.ToString());
            XMLOperater.Save(SuiteProvider.TestReportSavePath);
        }

        public BaseCase()
        {
            try
            {
                #region get needed information for current case
                //get the current case id ,start with zero
                CurrentID++;
                // get saving path of the excel which storged data for current case
                CurrentCaseDataSavePath = SuiteProvider.MyCasesDataTable.Rows[CurrentID]["DataPath"].ToString();
                MyExcelDataReader.MyExcelPath = CurrentCaseDataSavePath;
                //get all data for current case
                CurrentCaseDataTable = MyExcelDataReader.GetData();
                //get the row id to define which data to use
                string RowID = SuiteProvider.MyCasesDataTable.Rows[CurrentID]["dataRow"].ToString();
                //get current using data by row id
                CurrentCaseDataRow = GetRowByID(CurrentCaseDataTable, RowID);
                if (CurrentID == SuiteProvider.MyCasesDataTable.Rows.Count - 1)
                {
                    isLastCase = true;
                }
                #endregion
            }
            catch (Exception ex)
            {
                MyLogWriter.WriteLog("BaseCase: get case " + CurrentID.ToString() + " error.\r\n", ex.Message + ex.StackTrace);
            }

            #region set current integration testing case & current case
            //set the case id of current integration testing cases
            CurrentCaseID += 1;
            //get total cases of current integration testing cases
            CurrentIntgrationXPath = "test-results/test-suite[" + CurrentIntegrationID + "]";
            string CurrentIntgrationSteps = MyXMLOperater.GetNodeAttribute(SuiteProvider.TestReportSavePath, CurrentIntgrationXPath, "TotalStep");

            //initialize the test result of current case
            CurrentCaseResult = "Succeed";

            //record last integrtation testing cases's succeed number
            if (CurrentCaseID > int.Parse(CurrentIntgrationSteps) && !isLastCase)
            {
                //write down the successful case number
                Hashtable myStatisticsAttribute = new Hashtable();
                myStatisticsAttribute.Add("succeedNum", CurrentIntegrationSucceedCaseNum);
                MyXMLOperater.UpdateNode(SuiteProvider.TestReportSavePath, CurrentIntgrationXPath, myStatisticsAttribute);
                myStatisticsAttribute.Clear();
                //if the case id greater than current integration's total cases
                CurrentCaseID = 1;//reset the case num
                CurrentIntegrationID += 1;//begin next integration
                CurrentIntegrationSucceedCaseNum = 0;
            }
            //get current case
            CurrentCaseXPath = CurrentIntgrationXPath + "/test-case[" + CurrentCaseID + "]";
            #endregion

            #region   get info for current case and write them into the report
            //record start time for current case
            CurrentCaseStartTime = new TimeSpan(DateTime.Now.Ticks);

            //add the description for current case
            string caseDescription = MySuite.SuiteProvider.MyCasesDataTable.Rows[CurrentID]["Description"].ToString();
            if (caseDescription.Contains("["))
            {
                //if the description contain some random data, replace them with the real data in the list
                caseDescription = NewDescription(caseDescription);
                RegularDataNum = 0;
                RandomRegularData.Clear();//clear the list
            }
            //write the description into the report
            Hashtable myCaseAttribute = new Hashtable();
            myCaseAttribute.Add("CaseDescription", caseDescription);
            MyXMLOperater.UpdateNode(SuiteProvider.TestReportSavePath, CurrentCaseXPath, myCaseAttribute);
            myCaseAttribute.Clear();
            #endregion
        }

        #endregion

        #region Log Method
        /// <summary>
        /// write error message into the log 
        /// </summary>
        /// <param name="ErrorClass">in which class the error hanppened</param>
        /// <param name="message"></param>
        public void BaseWriteLog(string ErrorClass, string message)
        {
            MyLogWriter.WriteLog(ErrorClass, message);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="time"></param>
        public void InputSearchTime(string actionDesc, string timeCost)
        {
            this.SearchTime = timeCost;
            try
            {
                //State   Action   TimeSpan      Time    Envior

                string[] timeoutInfos = { 
                                           SuiteProvider.StateName,//State
                                            actionDesc,//Action
                                           timeCost,//TimeSpan
                                           DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"),//Time
                                           SuiteProvider.Enviorment
                                        };
                mySQL.InsertTimeOutInfo(timeoutInfos);

                //string TimeOutInfoSavePath = global::System.Environment.CurrentDirectory + @"\TestResult\Temp.xml";
                //Mutex writeMutex = new Mutex();
                //XmlDocument xmld = new XmlDocument();
                //writeMutex.WaitOne();
                //xmld.Load(TimeOutInfoSavePath);
                //XmlNode rootNode = xmld.SelectSingleNode("Recodes");
                //XmlElement xel = xmld.CreateElement("Action");
                //xel.SetAttribute("state", SuiteProvider.stateName);
                //xel.SetAttribute("timeSpan", timeCost);
                //xel.SetAttribute("time", DateTime.Now.ToString());
                //xel.InnerText = actionDesc;
                //rootNode.AppendChild(xel);
                //xmld.Save(TimeOutInfoSavePath);
                //writeMutex.ReleaseMutex();
            }
            catch
            {
                MyLogWriter.WriteLog("Enable to Input Search Time to DB");
            }
        }


        #endregion

        #region GetData Method

        /// <summary>
        /// get datarow from current datatable by row id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private DataRow GetRowByID(DataTable myData, string id)
        {
            DataTable mydata = myData;
            DataRow myRow = mydata.NewRow();
            //if (mydata.Columns[0].ColumnName.ToString().Trim() == "id")
            //{
            for (int rownum = 0; rownum < mydata.Rows.Count; rownum++)
            {
                //select the row by id
                // string RowColu = mydata.Rows[rownum]["id"].ToString();
                string RowColu = mydata.Rows[rownum][0].ToString();
                if (RowColu == id)
                {
                    myRow = mydata.Rows[rownum];
                }
            }
            //}
            return myRow;
        }

        /// <summary>
        /// get data from current datarow by columname
        /// </summary>
        /// <param name="ColumName"></param>
        /// <returns></returns>
        public string getdata(string ColumName)
        {
            // get data from current datarow by columname
            string regionResult = CurrentCaseDataRow[ColumName].ToString().Trim();
            //if data was a regular expression, generate a random new data by it 
            if (regionResult.Contains("^"))
            {
                regionResult = MyServices.CreatString(regionResult);
            }
            //add the random data to the list 
            RandomRegularData.Add(regionResult);

            return regionResult;
        }

        /// <summary>
        /// get the saving path of the excel data for current case
        /// </summary>
        /// <returns></returns>
        public string getcurrentpath()
        {
            return this.CurrentCaseDataSavePath;
        }

        public string getRole()
        {
            return MyXMLOperater.GetNodeAttribute(SuiteProvider.TestReportSavePath, CurrentIntgrationXPath, "Int_Role");
        }


        /// <summary>
        /// get the start index of the verify data in the data excel
        /// </summary>
        /// <returns>int </returns>
        private int GetPramerStart()
        {
            int StartRow = 0;
            int columnsNum = CurrentCaseDataRow.Table.Columns.Count;//?1704?
            for (int i = 0; i < columnsNum; i++)
            {
                try
                {
                    //the verify data was seperated from the input data by an empty column
                    //when the column name is combined by a "F" and a number like "F12", it was the start of verify data
                    if (CurrentCaseDataTable.Columns[i].ColumnName.Substring(0, 1) == "F" && int.Parse(CurrentCaseDataTable.Columns[i].ColumnName.Substring(1)) == i + 1)
                    {
                        StartRow = i;
                        break;
                    }
                }
                catch { }
            }
            return StartRow;
        }

        #endregion

        #region Assert Method

        public void Nunit_Assert()
        {
            Nunit_Assert("");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="CaseErrorDescription">the script error (begin with "#")</param>
        public void Nunit_Assert(string CaseErrorDescription)
        {
            //get current case
            CurrentCaseXPath = "test-results/test-suite[" + CurrentIntegrationID + "]/test-case[" + CurrentCaseID + "]";

            #region   add the total time of current case taked to the report
            //record the end time of current 
            CurrentCaseEndTime = new TimeSpan(DateTime.Now.Ticks);
            string caseExcuteTime = CurrentCaseEndTime.Subtract(CurrentCaseStartTime).Duration().TotalSeconds.ToString();

            if (SearchTime != "")
            {
                caseExcuteTime = SearchTime;
                SearchTime = "";
            }
            
            if (caseExcuteTime.Length > 5)
            {
                caseExcuteTime = caseExcuteTime.Substring(0, 5);
            }

            Hashtable myCaseAttribute = new Hashtable();
            myCaseAttribute.Add("time", caseExcuteTime);
            MyXMLOperater.UpdateNode(SuiteProvider.TestReportSavePath, CurrentCaseXPath, myCaseAttribute);
            myCaseAttribute.Clear();
            #endregion

            if (CaseErrorDescription.Length > 1 && CaseErrorDescription.Substring(0, 1) == "#")
            {
                //if their were any mistakes in the scripts, the case result should be wrong and skipt the cerify
                CurrentCaseResult = "Error";
                myCaseAttribute.Add("ScriptError", CaseErrorDescription.Substring(1, CaseErrorDescription.Length - 1));
                //myCaseAttribute.Add("ScreenShot", AssertScreenShot);
                myCaseAttribute.Add("ScreenShot", PrScrn());
            }
            else
            {
                #region prepare the information and verify the check point
                //get the start index of the verify data  in the excel
                int rowStart = GetPramerStart() + 1;//?1704?
                int sdf = CurrentCaseDataTable.Columns.Count;
                for (int i = rowStart; i < CurrentCaseDataTable.Columns.Count; i += 3)
                {
                    #region get needed info for current verify
                    //get the verify type
                    string mytype = CurrentCaseDataTable.Columns[i].ColumnName.ToString().Trim();
                    if (mytype == "" || mytype == null || mytype.Length < 3)
                    {
                        continue;
                    }
                    if (mytype.Substring(0, 1) == "F" && int.Parse(mytype.Substring(1)) == i + 1)//all the asserts were verified 
                    {
                        break;
                    }
                    //get the verify object
                    string ElemnetLocator = CurrentCaseDataRow[i].ToString();
                    //get the expected value
                    string thisExpectedValue = CurrentCaseDataRow[i + 1].ToString().Trim();
                    if (thisExpectedValue == "" || thisExpectedValue == null)
                    {
                        continue;
                    }
                    #endregion

                    #region  do the verify

                    myAssert(mytype, ElemnetLocator, thisExpectedValue, CurrentCaseDataRow[i + 2].ToString().Trim());

                    #endregion
                }
                #endregion

                if (CurrentCaseResult == "Succeed")
                {
                    CurrentIntegrationSucceedCaseNum += 1;
                }

            }

            #region   add the result to the report
            myCaseAttribute.Add("result", CurrentCaseResult);
            MyXMLOperater.UpdateNode(SuiteProvider.TestReportSavePath, CurrentCaseXPath, myCaseAttribute);
            #endregion

            if (isLastCase)
            {
                //write down the successful case number
                Hashtable myStatisticsAttribute = new Hashtable();
                myStatisticsAttribute.Add("succeedNum", CurrentIntegrationSucceedCaseNum);
                MyXMLOperater.UpdateNode(SuiteProvider.TestReportSavePath, "test-results/test-suite[" + CurrentIntegrationID + "]", myStatisticsAttribute);
                myStatisticsAttribute.Clear();
                isLastCase = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thistype">verify type</param>
        /// <param name="Locator">the element you want to check on the page</param>
        /// <param name="ExpectedValue">the expected value of the elemnet</param>
        /// <param name="assertDescription">description of current case</param>
        public void myAssert(string thistype, string Locator, string ExpectedValue, string assertDescription)
        {
            #region  do the verify according to the assert type
            //creat some temporary variable to storage current check point's info
            string AssertValueExp = "";
            string AssertValueGot = "";
            string AssertResult = "Passed";
            string AssertScreenShot = "No-Img";
            string ErrorMessage = "";

            try
            {
                switch (thistype.Substring(0, 3).ToUpper())
                {
                    case "URL"://Url://verify the location of the page is correct or not
                        string MyLocation = Regex.Split(selenium.GetLocation(), ".com/")[1].Trim();
                        try
                        {
                            AssertValueExp = ExpectedValue.Substring(ExpectedValue.IndexOf('/'));
                            AssertValueGot = MyLocation.Substring(MyLocation.IndexOf('/'));
                        }
                        catch { }
                        Assert.AreEqual(AssertValueExp, AssertValueGot);
                        break;
                    case "TIT"://Title:
                        string MyTitle = selenium.GetTitle();
                        AssertValueExp = ExpectedValue;
                        AssertValueGot = MyTitle;
                        Assert.AreEqual(ExpectedValue, MyTitle);
                        break;
                    case "TAB"://Table://verify the value of the cell in the table is correct or not
                        string TableCellTxt = selenium.GetText(GetElementId(Locator));
                        AssertValueExp = ExpectedValue;
                        AssertValueGot = TableCellTxt;
                        Assert.AreEqual(ExpectedValue, TableCellTxt);
                        break;
                    case "VAL"://Values:
                        if (Locator == "" || Locator == null)// //verify the text was appear or not
                        {
                            AssertValueExp = ExpectedValue + "  is appear";
                            bool isappear = selenium.IsTextPresent(ExpectedValue);
                            if (isappear)
                            {
                                AssertValueGot = ExpectedValue + " is appear";
                            }
                            else
                            {
                                AssertValueGot = ExpectedValue + " is not appear";
                            }
                            Assert.IsTrue(isappear);
                        }
                        else //verify the value of the element is correct or not
                        {
                            string tagValue = GetElemnetValueByID(Locator);
                            AssertValueExp = ExpectedValue;
                            AssertValueGot = tagValue;
                            Assert.AreEqual(ExpectedValue, tagValue);
                        }
                        break;
                    case "OBJ"://Object
                        //????????????????????????
                        string isenabled = IsElementEnabled(Locator);
                        AssertValueExp = "the element is " + ExpectedValue;
                        AssertValueGot = "the element is " + isenabled;
                        Assert.AreEqual(ExpectedValue, isenabled);
                        break;
                    case "ALE"://Alert
                        //#####################
                        if (selenium.IsAlertPresent())
                        {
                            string AlertTxt = selenium.GetAlert();
                            AssertValueExp = "Alert this : " + ExpectedValue;
                            AssertValueGot = "Alert this: " + AlertTxt;
                            Assert.AreEqual(ExpectedValue, AlertTxt);
                        }
                        if (selenium.IsConfirmationPresent())
                        {
                            string ConformationTxt = selenium.GetConfirmation();
                            AssertValueExp = "[Conformation this :] " + ExpectedValue;
                            AssertValueGot = "[Conformation this:] " + ConformationTxt;
                            Assert.AreEqual(ExpectedValue, ConformationTxt);
                        }

                        break;
                    case "FOR"://Format:
                        AssertValueExp = "the elemnet(s) should in this formate : " + ExpectedValue;
                        AssertValueGot = "";
                        Assert.IsTrue(IsElemnetFormatRight(Locator, ExpectedValue));
                        break;
                }
            }
            //catch (AssertionException ex)
            catch (Exception ex)
            {
                verificationErrors.AppendLine(ex.Message);
                //set the result of current case to wrong
                CurrentCaseResult = "Failed";
                //
                AssertResult = "Failed";
                AssertScreenShot = PrScrn();//get screenshot for current check point error
                //
                ErrorMessage = ex.Message;
            }
            #endregion

            #region write all the info of current assert into the report
            Hashtable myAssertAttribute = new Hashtable();
            myAssertAttribute.Add("assert_Description", assertDescription);
            myAssertAttribute.Add("assert_Type", thistype);
            myAssertAttribute.Add("value_Expected", AssertValueExp);
            myAssertAttribute.Add("value_Got", AssertValueGot);
            myAssertAttribute.Add("result", AssertResult);
            myAssertAttribute.Add("ScreenShot", AssertScreenShot);
            Hashtable myAssertError = new Hashtable();
            if (ErrorMessage != "")
            {
                myAssertError.Add("ErrorInfo", ErrorMessage);
            }
            MyXMLOperater.InsertNode(SuiteProvider.TestReportSavePath, CurrentCaseXPath, "Assert", myAssertAttribute, "Message", myAssertError);
            #endregion
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DBOperateType"></param>
        /// <param name="tableName"></param>
        /// <param name="PK"></param>
        /// <param name="ExpectedValue"></param>
        /// <param name="assertDescription"></param>
        public void myDBAssert(string DBOperateType, string tableName, string PK, string PKValue, string assertDescription)
        {
            //creat some temporary variable to storage current check point's info
            string AssertValueExp = "";
            string AssertValueGot = "";
            string AssertResult = "Passed";
            string ErrorMessage = "";

            try
            {
                switch (DBOperateType.ToUpper())
                {
                    case "DELETE"://delete
                        bool isPKExist = false;
                        AssertValueExp = "the record with " + PK + " of " + PKValue + " is deleted succfully";
                        bool isExist=MyDBOperater.isExist(tableName, PK, PKValue);
                        if (!isExist)
                        {
                            AssertValueGot = "the record with " + PK + " of " + PKValue + " is deleted succfully";
                        }
                        else
                        {
                            AssertValueGot = "the record with " + PK + " of " + PKValue + " is not deleted succfully";
                        }
                        Assert.AreEqual(isPKExist, isExist);
                        break;
                    case "ADD": //add
                        bool isAddSucceed = true;
                        AssertValueExp = "the record with " + PK + " of " + PKValue + " is added succfully";
                        bool isAdded=MyDBOperater.isExist(tableName, PK, PKValue);
                        if (!isAdded)
                        {
                            AssertValueGot = "the record with " + PK + " of " + PKValue + " is not added succfully";
                        }
                        else
                        {
                            AssertValueGot = "the record with " + PK + " of " + PKValue + " is added succfully";
                        }
                        Assert.AreEqual(isAddSucceed, isAdded);
                        break;
                    case "EDIT":  //edit
                        ////string isenabled = IsElementEnabled(Locator);
                        ////AssertValueExp = "the element is " + ExpectedValue;
                        ////AssertValueGot = "the element is " + isenabled;
                        ////Assert.AreEqual(ExpectedValue, isenabled);
                        break;
                }
            }
            //catch (AssertionException ex)
            catch (Exception ex)
            {
                verificationErrors.AppendLine(ex.Message);
                //set the result of current case to wrong
                CurrentCaseResult = "Failed";
                //
                AssertResult = "Failed";
                //
                ErrorMessage = ex.Message;
            }

            #region write all the info of current assert into the report
            Hashtable myAssertAttribute = new Hashtable();
            myAssertAttribute.Add("assert_Description", assertDescription);
            myAssertAttribute.Add("assert_Type", DBOperateType);
            myAssertAttribute.Add("value_Expected", AssertValueExp);
            myAssertAttribute.Add("value_Got", AssertValueGot);
            myAssertAttribute.Add("result", AssertResult);
            Hashtable myAssertError = new Hashtable();
            if (ErrorMessage != "")
            {
                myAssertError.Add("ErrorInfo", ErrorMessage);
            }
            MyXMLOperater.InsertNode(SuiteProvider.TestReportSavePath, CurrentCaseXPath, "Assert", myAssertAttribute, "Message", myAssertError);
            #endregion
        }


        #endregion

        #region HtmlObjectOperateMethod
        /// <summary>
        /// get html tagname of element
        /// </summary>
        /// <param name="id">the id (xpath) of the element</param>
        /// <returns></returns>
        private string GetElementTagName(string id)
        {
            string thistagName = "";
            try
            {
                string Locaterscript = "window.document.getElementById('" + id + "').tagName;";
                thistagName = selenium.GetEval(Locaterscript);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return thistagName;
        }

        /// <summary>
        /// get the xpth for the table cell/column
        /// </summary>
        /// <param name="InPutstring">cell expression: (table id)/(column name)or(column No.) /(roe No.)</param>
        /// <returns></returns>
        public string GetElementId(string InPutstring)
        {
            string MyElementID = "";
            try
            {

                #region clip the inPutstring
                string[] sArray = InPutstring.Split('/');
                int row, column = 0;
                #endregion

                #region get the column No.
                if (Regex.IsMatch(sArray[1].Trim(), "^[0-9]*$"))
                {
                    //if the column was identified by column No.
                    column = int.Parse(sArray[1].Trim());
                }
                else
                {
                    //if the column was identified by column name
                    #region convert the column name to column No.
                    //get the count of all columns in the table
                    string TotalColNumber = selenium.GetXpathCount("//table[@id='" + sArray[0].Trim() + "']/tbody//td").ToString();//计算一共多少行
                    for (int i = 1; i <= int.Parse(TotalColNumber); i++)
                    {
                        if (selenium.GetText("//table[@id='" + sArray[0].Trim() + "']/tbody/tr[1]/th[" + i.ToString() + "]").Trim() == sArray[1].Trim())
                        {
                            column = i;
                            break;
                        }
                    }
                    #endregion
                }
                #endregion

                if (sArray.Length > 2) //if the element id has a row No.
                {
                    #region if the row No. was "First", "End",convert them to Number
                    switch (sArray[2].Trim().ToUpper())
                    {
                        case "FIRST"://first row of the table
                            row = 2;//the selenium  count the table head as row 1
                            break;
                        case "END":
                            //the total rows count
                            string TotalrowNumber = selenium.GetXpathCount("//table[@id='" + sArray[0].Trim() + "']/tbody/tr").ToString();
                            row = int.Parse(TotalrowNumber);
                            break;
                        default:
                            //the row No. in the inPutstring was a number
                            row = int.Parse(sArray[2].Trim()) + 1;
                            break;
                    }
                    #endregion

                    MyElementID = "//table[@id='" + sArray[0].Trim() + "']/tbody/tr[" + row.ToString() + "]/td[" + column.ToString() + "]";
                }
                else
                {
                    //the element id was for a whole column
                    MyElementID = "//table[@id='" + sArray[0].Trim() + "']/tbody//td[" + column.ToString() + "]";
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return MyElementID;
        }

        /// <summary>
        /// get the element's status
        /// </summary>
        /// <param name="ElementId">the locator of element</param>
        /// <returns>"Enabled/Diaabled"</returns>
        private string IsElementEnabled(string ElementId)
        {
            string IsObjVisible = "Disabled";
            if (selenium.IsElementPresent(ElementId))//the element is exist
            {
                if (selenium.IsVisible(ElementId))//the element is show on the page
                {
                    IsObjVisible = "Enabled";

                    #region is some special element editable
                    try
                    {
                        string ElementtagName = GetElementTagName(ElementId);
                        if (ElementtagName == "INPUT" || ElementtagName == "SELECT" || ElementtagName == "TEXTAREA")
                        {
                            if (selenium.IsEditable(ElementId))//the element can be editabled
                            {
                                IsObjVisible = "Enabled";
                            }
                            else
                            {
                                IsObjVisible = "Disabled";
                            }
                        }
                    }
                    catch { }
                    #endregion
                }
                else
                {
                    IsObjVisible = "Disabled";
                }
            }

            return IsObjVisible;
        }

        //private string IsElementEnabled(string ElementId)
        //{
        //    string IsObjVisible = "Enabled";
        //    try
        //    {
        //        string ElementtagName = GetElementTagName(ElementId);
        //        if (selenium.IsElementPresent(ElementId))//the element is exist
        //        {
        //            if (selenium.IsVisible(ElementId))//the element is show on the page
        //            {
        //                IsObjVisible = "Enabled";
        //                if (ElementtagName == "INPUT" || ElementtagName == "SELECT" || ElementtagName == "TEXTAREA")
        //                {
        //                    if (selenium.IsEditable(ElementId))//the element can be editabled
        //                    {
        //                        IsObjVisible = "Enabled";
        //                    }
        //                    else
        //                    {
        //                        IsObjVisible = "Disabled";
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                IsObjVisible = "Disabled";
        //            }
        //        }
        //    }
        //    catch
        //    {
        //        IsObjVisible = "Disabled";
        //        //throw new Exception(ex.Message);
        //    }
        //    return IsObjVisible;
        //}


        /// <summary>
        /// get the value of element
        /// </summary>
        /// <param name="elemnetid">the locator of element</param>
        /// <returns></returns>

        private string GetElemnetValueByID(string elemnetid)
        {
            string ElementValue = "";
            string TagType = "";
            try
            {
                TagType = GetElementTagName(elemnetid);
            }
            catch
            {
            }
            if (TagType == "INPUT")
            {
                //get value for the input type
                ElementValue = selenium.GetValue(elemnetid);
            }
            else if (TagType == "SELECT")
            {
                //get the selected option's value for dropdownlist
                ElementValue = selenium.GetText("//select[@id='" + elemnetid + "']//option[@selected]");
            }
            else
            {
                ElementValue = selenium.GetText(elemnetid);
            }
            return ElementValue;
        }

        /// <summary>
        /// check wether  the element value is in a right fromat
        /// </summary>
        /// <param name="elementid">the locator of element</param>
        /// <param name="regularExpression">the right regular expression</param>
        /// <returns></returns>
        private bool IsElemnetFormatRight(string elementid, string regularExpression)
        {
            //set regular expression
            Regex myExpression = new Regex(regularExpression);
            bool isMatch = true;
            try
            {
                string[] sArray = elementid.Split('/');
                if (sArray.Length > 1)
                {
                    #region  check a column of a table
                    //get the count of the column
                    int RowNum = int.Parse(selenium.GetXpathCount("//table[@id='" + sArray[0].Trim() + "']/tbody//tr").ToString().Trim());
                    //convert the column name to column No.
                    string ColumnID = GetElementId(elementid).Split('/')[1].ToString().Trim();
                    for (int i = 1; i <= RowNum; i++)
                    {
                        string CellValue = selenium.GetText("//table[@id='" + sArray[0].Trim() + "']/tbody/tr[" + ColumnID + "]/td[" + i.ToString() + "]");
                        if (!myExpression.IsMatch(CellValue))
                        {
                            //if there were any data can't match the expression return false and break
                            isMatch = false;
                            break;
                        }
                    }
                    #endregion
                    //return myExpression.IsMatch(selenium.GetText(GetElementId(elementid)));
                }
                else
                {
                    //check the single element
                    isMatch = myExpression.IsMatch(GetElemnetValueByID(elementid));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return isMatch;
        }

        /// <summary>
        /// replace the regex data with real data
        /// </summary>
        /// <param name="Description">orginal description with "["</param>
        /// <returns></returns>
        private string NewDescription(string Description)
        {
            if (!Description.Contains("["))
            {
                return Description;
            }
            else
            {
                int CloumNameStartNum = Description.IndexOf("[") + 1;
                int CloumNameEndNum = Description.IndexOf("]");
                //get the data between "[" and "]"
                string CloumName = Description.Substring(CloumNameStartNum, CloumNameEndNum - CloumNameStartNum);
                string FullCloumName = Description.Substring(CloumNameStartNum - 1, CloumNameEndNum - CloumNameStartNum + 2);
                //       
                if (getdata(CloumName) == "" || getdata(CloumName) == null)
                {
                    //if the orgin data in the excel was empty
                    Description = Description.Replace(FullCloumName, "   null   ");
                }
                else
                {
                    //replace the data with the real data recoded in the list
                    Description = Description.Replace(FullCloumName, RandomRegularData[RegularDataNum].Trim());
                    RegularDataNum += 1;
                }
                return NewDescription(Description);
            }
        }

        #endregion

        #region SeleniumMethod

        #region PrScrnMethod
        /// <summary>
        /// get the sreenshot and save them  to a assigned directory with a special name
        /// </summary>
        public string PrScrn()
        {
            string imgName = "";
            try
            {
                imgName = MySuite.SuiteProvider.TestResult_Img_Path + "\\" + MyServices.FileName("imgName") + ".png";
                //print screen
                selenium.CaptureEntirePageScreenshot(imgName, "background=#FFFFFF");
            }
            catch (Exception ex)
            {
                MyLogWriter.WriteLog("BaseCase", logType.Error, "Please Check wether the floder" + MySuite.SuiteProvider.TestResult_Img_Path + " is exist! \n" + ex.Message + ex.StackTrace);
            }
            return imgName;
        }
        #endregion

        #region expandSleniumMethod
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="value"></param>
        /// <param name="errorMess"></param>
        public void seleniumType(string locator, string value, string errorMess)
        {
            try
            {
                selenium.Type(locator, value);
            }
            catch
            {
                throw new Exception(errorMess);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="optionLocator"></param>
        /// <param name="errorMess"></param>
        public void seleniumSelect(string locator, string optionLocator, string errorMess)
        {
            try
            {
                selenium.Select(locator, optionLocator);
            }
            catch
            {
                throw new Exception(errorMess);
            }
        }

        /// <summary>
        /// wait for the elemnet  change its' appear status
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOut">in Millisecond</param>
        /// <param name="isWantAppear">this element will. be visible or not </param>
        public void WaitForElementAppearOrNot(string locator, int timeOut, bool isWantAppear)
        {
            int waittime = 0;
            //while (isWantAppear == !selenium.IsVisible(locator))
            if (isWantAppear)//wait for appear
            {
                if (selenium.IsElementPresent(locator))//exist
                {
                    while (!selenium.IsVisible(locator))//visible
                    {
                        if (waittime > timeOut)
                        {
                            throw new AssertionException("Condition Time Out");
                        }
                        Thread.Sleep(1000);
                        waittime += 1000;
                    }
                }
                else
                {
                    while (!selenium.IsElementPresent(locator))//exist
                    {
                        if (waittime > timeOut)
                        {
                            throw new AssertionException("Condition Time Out");
                        }
                        Thread.Sleep(1000);
                        waittime += 1000;
                    }
                }
            }
            else
            {
                try
                {
                    while (selenium.IsVisible(locator))
                    {
                        //}
                        //while (isWantAppear ? !selenium.IsElementPresent(locator) : selenium.IsElementPresent(locator))
                        //{
                        if (waittime > timeOut)
                        {
                            throw new AssertionException("Condition Time Out");
                        }
                        Thread.Sleep(1000);
                        waittime += 1000;
                    }
                }
                catch//no exist , isVisible will throw a "non-exist" exception! elemnet is disappeared!
                {
                    //throw new AssertionException("OK!");
                }
            }
        }

        /// <summary>
        /// block untill the elemnet change its editable status or time out 
        /// </summary>
        /// <param name="locator"></param>
        /// <param name="timeOut">in Millisecond</param>
        /// <param name="isWantEditable">this element will be editable or not </param>
        public void WaitForElementEditableOrNot(string locator, int timeOut, bool isWantEditable)
        {
            int waittime = 0;
            while (isWantEditable == !selenium.IsEditable(locator))
            {
                //}
                //while (isWantEditable ?!selenium.IsEditable(locator) : selenium.IsEditable(locator))
                //{
                if (waittime > timeOut)
                {
                    throw new AssertionException("Condition Time Out");
                }
                Thread.Sleep(1000);
                waittime += 1000;
            }
        }

        #endregion

        #endregion
    }
}