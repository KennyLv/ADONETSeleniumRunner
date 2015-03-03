using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading;
using System.Diagnostics;
using System.IO;
using PPLTest.ClassLib;
using System.Collections;
using PPLTest.MySuite;


namespace PPLTest.TestCases
{
    [TestFixture]
    public class EndTest
    {
        #region Declare the global variables
        private Log MyLog = new Log();
        private XmlHelper myXmlOperater = new XmlHelper();

        #endregion

        #region  Constructor of EndTest
        public EndTest()
        {
            try
            {
                //stop the selenium ,the test was over
                BaseCase.selenium.Stop();
                Hashtable myEndAttribute = new Hashtable();
                myEndAttribute.Add("AllEndTime", DateTime.Now.ToString());
                myXmlOperater.UpdateNode(SuiteProvider.TestReportSavePath, "test-results", myEndAttribute);
                myEndAttribute.Clear();
            }
            catch (Exception ex)
            {
                MyLog.WriteLog(ex.Message + ex.TargetSite);
            }

            #region if the test is running on NUnit-Gui,creat a thread to generate the report
            //ThreadStart dasfdas = new ThreadStart(CreatXmlResult);
            //Thread asdf = new Thread(dasfdas);
            //asdf.Start();
            #endregion
        }
        #endregion

        /// <summary>
        /// Destructor of EndTest
        /// </summary>
        ~EndTest()
        {
            #region  if the test is running on NUnit-Console, generate the report when destructor
            Thread.Sleep(500);
            CreatXmlResult();
            Thread.Sleep(500);
            #endregion
        }

        #region Creat the test report
        /// <summary>
        /// 生成XML结果
        /// </summary>
        private void CreatXmlResult()
        {
            try
            {
                //get the test result created by Nunit
                string sourceFile = global::System.Environment.CurrentDirectory + @"\TestResult.xml";
                while (!File.Exists(sourceFile))
                {
                    Thread.Sleep(100);
                }

                #region select some valueable info from the nunit result and add it to the report
                List<string> copynodes=new List<string>();
                copynodes.Add("test-results/environment");
                copynodes.Add("test-results/culture-info");
                myXmlOperater.CopyNode(sourceFile, PPLTest.MySuite.SuiteProvider.TestReportSavePath, copynodes, "test-results");
                #endregion

                Thread.Sleep(200);

                #region  open the report by IE
                try
                {
                    ProcessStartInfo startReport = new ProcessStartInfo();
                    startReport.FileName = "IEXPLORE.EXE";
                    startReport.Arguments = PPLTest.MySuite.SuiteProvider.TestReportSavePath;
                    Process.Start(startReport);
                }
                catch (Exception ex)                
                {
                    MyLog.WriteLog("EndTest: You must open the repote on IE . \r\n", ex.Message + ex.StackTrace);
                }
                #endregion

                //delete the result created by Nunit     
                //File.Delete(sourceFile);
            }
            catch (Exception ex)
            {
                MyLog.WriteLog("EndTest", ex.Message + ex.StackTrace);
            }
        }
        #endregion
    }
}