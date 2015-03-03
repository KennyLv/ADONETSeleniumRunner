using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class ViewOfTimesheet : BaseCase
    {
/*
 * View a timesheet after searching timesheets in the Timesheets link
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
        public void ViewOfTimesheetTest()
        {
            try
            {
                selenium.Click("ctl00_MainBody_gvInvoiceListProvider_ctl02_bView");
                //
                TimeSpan startTime1 = new TimeSpan(DateTime.Now.Ticks);
                try
                {
                    selenium.WaitForPageToLoad(timeOutSpan);
                }
                catch
                {
                    verificationErrors.AppendLine("Time Out\r\n");
                }
                TimeSpan endTime1 = new TimeSpan(DateTime.Now.Ticks);

                string caseExTime = endTime1.Subtract(startTime1).Duration().TotalSeconds.ToString();

                InputSearchTime("Error after clicking View button in Timesheets link", caseExTime);
                //
                string status = selenium.GetText("ctl00_MainBody_txTimesheetStatus");
                //PDF download has a bug,when modified it,this can be used
                if (status == "SUBMITTED" || status == "APPROVED")
                {
                    //selenium.Click("ctl00_MainBody_bShowPDF");
                    //selenium.WaitForPageToLoad("30000");
                }
           }
            catch (Exception e)
            {
                verificationErrors.AppendLine(e.Message);
            }
            Nunit_Assert("#" + verificationErrors);
        }
    }
}