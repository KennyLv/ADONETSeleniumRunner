using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;
using System.Threading;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class CreateTimesheetSubmitSuc : BaseCase
    {
/*
 * Confirm a timesheet and Submit it
 * 2011-01-16 Peter
 */
        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
        }

        [Test]
        public void CreateTimesheetSubmitSucTest()
        {
            try
            {
                selenium.Click("ctl00_MainBody_bSubmit");
                //
                TimeSpan startTime1 = new TimeSpan(DateTime.Now.Ticks);
                try
                {
                    selenium.WaitForPageToLoad(timeOutSpan);
                }
                catch
                {
                    verificationErrors.AppendLine("Timeout!\r\n");
                }
                TimeSpan endTime1 = new TimeSpan(DateTime.Now.Ticks);

                string caseExTime = endTime1.Subtract(startTime1).Duration().TotalSeconds.ToString();

                InputSearchTime("Error when confirming a timesheet in Timesheets link", caseExTime);
                //
                Thread.Sleep(5000);
         //There is bug here on the web site,if it is modified ,this can be used.
                //selenium.Click("ctl00_MainBody_bShowPDF");
                //selenium.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                verificationErrors.AppendLine(e.Message);
            }
            Nunit_Assert("#" + verificationErrors);
        }
    }
}