/*
 * Author: Leo Song
 * Create time:2010/12/28
 * Last modify:2010/12/28 Leo Song
 * Description:Click the 'Delete' button in the searched timesheet result table
 */
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class DeleteTimesheet : BaseCase
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
        public void DeleteTimesheetTest()
        {
            try
            {
                selenium.Click("ctl00_MainBody_gvInvoiceListProvider_ctl02_bDelete");
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

                InputSearchTime("Error after clicking Delete link in Timesheets link", caseExTime);
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