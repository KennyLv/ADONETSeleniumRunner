using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{

/* Find a client by its last name
 * 2011-01-12 Peter
 * 
 */

    [TestFixture]
    public class SelectParticipant : BaseCase
    {
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
        public void SelectParticipantTest()
        {
            //Use client's last name as the only selection condition
            try
            {
                selenium.Type("ctl00_MainBody_txtClientLastName", getdata("LastName"));
            }
            catch
            {
                verificationErrors.AppendLine("Use ClientLastName label cannot find a client\r\n");
            }

            //Click Search button 
            try
            {
                selenium.Click("ctl00_MainBody_btnSubmit");
            }
            catch
            {
                verificationErrors.AppendLine("No such a client or Time out\r\n");
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

            InputSearchTime("Error after clicking Search button in Timesheets link", caseExTime1);
            //

            
            //Click the Create Timesheet link locating behind the target client
            //Default the first row. When there are several rows ,please chang the click id.
            try
            {
                selenium.Click("ctl00_MainBody_gvConsumers1_ctl02_lblTimesheets");
            }
            catch
            {
                verificationErrors.AppendLine("Cannot leave the Clent Profile List page\r\n");
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

            InputSearchTime("Error when showing Client Profile List page in Timesheets link", caseExTime2);
            //

            //try
            //{
            //    selenium.Click("ctl00_MainBody_gvReferralList_ctl02_lnkSubmitInvoice");
            //}
            //catch
            //{
            //    verificationErrors.AppendLine("Submit TimesheetTemplate Link can't find\r\n");
            //}

            //try
            //{
            //    selenium.WaitForPageToLoad("30000");
            //}
            //catch
            //{
            //    verificationErrors.AppendLine("Time Out\r\n");
            //}
           
           Nunit_Assert("#"+verificationErrors.ToString());
            
        }
    }
}
