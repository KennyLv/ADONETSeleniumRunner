using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.TimesheetList
{
    [TestFixture]
    public class SearchTimesheetList : BaseCase
    {
/*
 * Search timesheets after clicking Timesheet List link
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
        public void SearchTimesheetListTest()
        {  
            //selenium.Open("/PortalManagement/Consumer/ConsumerProfileList.aspx");
            selenium.Click("link=Timesheet List");
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

            InputSearchTime("Error after clicking Timesheet List link", caseExTime);
            //

            try
            {
                if (TimesheetStatus == "" || TimesheetStatus == null)
                {
                    //selenium.Select("ctl00_MainBody_ddTimesheetStatus", "label=All"); Edit by song leo 2011/1/5
                    selenium.Select("ctl00_MainBody_ddTimesheetStatus", "label=Submitted");

                }
                else
                {
                    selenium.Select("ctl00_MainBody_ddTimesheetStatus", "label=" + TimesheetStatus);
                }

                selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange1", getdata("StartDateBegin"));

                selenium.Type("ctl00_MainBody_txtTimesheetBeginDateRange2", getdata("StartDateEnd"));

                selenium.Type("ctl00_MainBody_txtTimesheetSubmittedDateRange1", getdata("SubmitDateBegin"));

                selenium.Type("ctl00_MainBody_txtTimesheetSubmittedDateRange2", getdata("SubmitDateEnd"));

                if (getRole() == "PPL Admin")
                {
                    //selenium.Type("ctl00_MainBody_tbConsumerSystemID", getdata("ParticipantID"));
                    seleniumType("ctl00_MainBody_tbConsumerSystemID", getdata("ParticipantID"), "ParticipantID can not find.");
                    //selenium.Type("ctl00_MainBody_tbConsumerExternalID", getdata("ParticipantID2"));
                    //seleniumType("ctl00_MainBody_tbConsumerExternalID", getdata("ParticipantID2"), "ParticipantID2 can not find.");
                }


                selenium.Click("ctl00_MainBody_lblProviderSearchTxt");
                selenium.Type("ctl00_MainBody_tbProviderFirstName", getdata("ProviderFirstName"));
                selenium.Type("ctl00_MainBody_tbProviderLastName", getdata("ProviderLastName"));
                selenium.Click("ctl00_MainBody_btnSubmit1");
                //
                TimeSpan startTime2 = new TimeSpan(DateTime.Now.Ticks);
                try
                {
                    selenium.WaitForPageToLoad(timeOutSpan);
                }
                catch
                {
                    verificationErrors.AppendLine("Timeout!\r\n");
                }
                TimeSpan endTime2 = new TimeSpan(DateTime.Now.Ticks);

                string caseExTime2 = endTime2.Subtract(startTime2).Duration().TotalSeconds.ToString();

                InputSearchTime("Error after clicking Search button in Timesheet List link", caseExTime2);
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