using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;
using System.Threading;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{

/*
 * Steps 1:select an employee;
 * Steps 2:choose the time period
 * 2011-01-12 Peter
 */

    [TestFixture]
    public class SubmitTimesheet : BaseCase
    {
        private string Service;

        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
            //Service = getdata("Service").Trim();
        }

        [TearDown]
        public void TeardownTest()
        {
        }

        [Test]
        public void SubmitTimesheetTest()
        {
            //Steps 1
            //Click Employee ID on the timesheet page
            //Default the first row,when there are several rows ,please chang the clicked id
            try
            {
                selenium.Click("ctl00_MainBody_gvProviders_ctl02_linkProviderID");
            }
            catch
            {
                verificationErrors.AppendLine("Something is wrong with ProviderID link\r\n");
            }
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

            InputSearchTime("Error after clicking Employee ID in Timesheets link", caseExTime1);
            //

            //if (Service == "" || Service == null)
            //{
            //}
            //else
            //{
            //    selenium.Select("ctl00_MainBody_ddServicesSingle", "label=" + Service);
            //}

            //Steps 2
            try
            {
                //selenium.Click("ctl00_MainBody_imgCalendar");
                //selenium.Click("ctl00_MainBody_calendarExtender1_day_2_5");
                selenium.Type("ctl00_MainBody_tbInvisibleDateBox", getdata("Date"));
                selenium.Click("ctl00_MainBody_bSubmitCalendar");
            }
            catch
            {
                verificationErrors.AppendLine("Date format is wrong or Time out\r\n");
            }

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

            InputSearchTime("Error after choosing Date in Timesheets link", caseExTime2);
            //

            Nunit_Assert("#" + verificationErrors.ToString());
        }
    }
}
