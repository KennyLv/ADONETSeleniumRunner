using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class SearchTimesheet : BaseCase
    {
/*
 * Search a timesheet after clicking Search Timesheet link in the Timesheets link
 * 2011-01-16 Peter
 */
        private string TimesheetStatus;

        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
            TimesheetStatus = getdata("TimesheetStatus").Trim();
        }

        [TearDown]
        public void TeardownTest()
        {
        }

        [Test]
        public void SearchTimesheetTest()
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

                if (TimesheetStatus == "" || TimesheetStatus == null)
                {
                    //selenium.Select("ctl00_MainBody_ddTimesheetStatus", "label=All"); Edit by song leo 2011/1/5
                    selenium.Select("ctl00_MainBody_ddTimesheetStatus", "label=Unpaid");
                }
                else
                {
                    selenium.Select("ctl00_MainBody_ddTimesheetStatus", "label=" + TimesheetStatus);
                }
                
                selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange1",getdata("StartDateBegin"));
                
                selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange2", getdata("StartDateEnd"));
                
                selenium.Type("ctl00_MainBody_txtTimesheetSubmittedDateRange1", getdata("SubmitDateBegin"));
                
                selenium.Type("ctl00_MainBody_txtTimesheetSubmittedDateRange2", getdata("SubmitDateEnd"));
                selenium.Type("ctl00_MainBody_tbProviderID", getdata("ProviderID"));
                //selenium.Type("ctl00_MainBody_tbProviderExternalID", getdata("ProviderID2"));
                //selenium.Click("ctl00_MainBody_lblProviderSearchTxt");
                //selenium.Type("ctl00_MainBody_tbProviderFirstName", getdata("ProviderFirstName"));
                //selenium.Type("ctl00_MainBody_tbProviderLastName", getdata("ProviderLastName"));
			    selenium.Click("ctl00_MainBody_btnSubmit1");
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

                InputSearchTime("Error after clicking Create Timesheet link in Timesheets link", caseExTime2);
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