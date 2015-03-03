/*
 * Author: Leo Song
 * Create time:2010/12/28
 * Last modify:2010/12/28 Leo Song
 * Description:After enter time period, click the 'Save' button
 */
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class SaveTimesheet : BaseCase
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
        public void SaveTimesheetTest()
        {
            try
            {
                selenium.Click("ctl00_MainBody_bSaveMyWork");
                selenium.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                verificationErrors.AppendLine(e.Message);
            }
            Nunit_Assert("#" + verificationErrors);
        }
    }
}