using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class GotoSelectParticipant : BaseCase
    {
/*
 * Enter the Create Timesheets page whatever page it is
 * 2011-01-12 Peter
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
        public void GotoSelectParticipantTest()
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
                verificationErrors.AppendLine("Cannot enter Timesheets page or Time Out\r\n");
            }
            TimeSpan endTime1 = new TimeSpan(DateTime.Now.Ticks);

            string caseExTime1 = endTime1.Subtract(startTime1).Duration().TotalSeconds.ToString();

            InputSearchTime("Error after clicking Timesheets link", caseExTime1);
            //

            selenium.Click("link=Create Timesheet");

            //
            TimeSpan startTime2 = new TimeSpan(DateTime.Now.Ticks);
            try
            {
                selenium.WaitForPageToLoad(timeOutSpan);
            }
            catch
            {
                verificationErrors.AppendLine("Cannot enter Client Profile List page or Time Out\r\n");
            }
            TimeSpan endTime2 = new TimeSpan(DateTime.Now.Ticks);

            string caseExTime2 = endTime2.Subtract(startTime2).Duration().TotalSeconds.ToString();

            InputSearchTime("Error after clicking Create Timesheet link in Timesheets link", caseExTime2);
            //

            Nunit_Assert("#" + verificationErrors.ToString());
        }
    }
}
