using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class TimesheetLookUp : BaseCase
    {
/*
 * Look up timesheet after clicking Faxes Received link in the Timesheets link
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
        public void TimesheetLookUpTest()
        {
            try
            {
                selenium.Click("link=Timesheets");
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

                string caseExTime1 = endTime1.Subtract(startTime1).Duration().TotalSeconds.ToString();

                InputSearchTime("Error after clicking Timesheets link", caseExTime1);
                //
                selenium.Click("//ul[@id='sub-menu']/li[3]/a");
                //
                TimeSpan startTime2 = new TimeSpan(DateTime.Now.Ticks);
                try
                {
                    selenium.WaitForPageToLoad(timeOutSpan);
                }
                catch
                {
                    verificationErrors.AppendLine("Time Out\r\n");
                }
                TimeSpan endTime2 = new TimeSpan(DateTime.Now.Ticks);

                string caseExTime2 = endTime2.Subtract(startTime2).Duration().TotalSeconds.ToString();

                InputSearchTime("Error after clicking Search Timesheet link in Timesheets link", caseExTime2);
                //
                //selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange1", "12/9/2010");
                //selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange2", "12/9/2010");
                selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange1", getdata("Date1"));
                selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange2", getdata("Date2"));
                selenium.Type("ctl00_MainBody_txtProviderID", getdata("ProviderID"));
                selenium.Type("ctl00_MainBody_txtConsumerID", getdata("ConsumerID"));
                selenium.Type("ctl00_MainBody_txtBatchNumber", getdata("BatchNumber"));
                selenium.Click("ctl00_MainBody_btnSubmit1");
                //
                TimeSpan startTime3 = new TimeSpan(DateTime.Now.Ticks);
                try
                {
                    selenium.WaitForPageToLoad(timeOutSpan);
                }
                catch
                {
                    verificationErrors.AppendLine("Time Out\r\n");
                }
                TimeSpan endTime3 = new TimeSpan(DateTime.Now.Ticks);

                string caseExTime3 = endTime3.Subtract(startTime3).Duration().TotalSeconds.ToString();

                InputSearchTime("Error after clicking Search button in Timesheets link", caseExTime3);
                //
            }
            catch (Exception e)
            {
                verificationErrors.AppendLine(e.Message);
            }
            Nunit_Assert("#" + verificationErrors);
        }
    }
}