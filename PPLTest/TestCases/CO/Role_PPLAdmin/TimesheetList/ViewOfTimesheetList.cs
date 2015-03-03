using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.TimesheetList
{
    [TestFixture]
    public class ViewOfTimesheetList : BaseCase
    {
/*
 * View a timesheet after searching timesheets in the Timesheet List link
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
        public void ViewOfTimesheetListTest()
        {
            try
            {
                selenium.Click("ctl00_MainBody_gvInvoiceListConsumer_ctl02_bView");
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

                InputSearchTime("Error after clicking View button in Timesheet List link", caseExTime);
                //
            //PDF download has a bug , when modified it ,this can be used
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