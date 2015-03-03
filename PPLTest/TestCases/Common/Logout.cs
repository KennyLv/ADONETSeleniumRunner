using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PPLTest.TestCases.Common
{
    [TestFixture]
    public class Logout : BaseCase
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
        public void LogoutTest()
        {
            try
            {
                // click the linkbutton of logout
                selenium.Click("link=Logout");
                //wait for the page to turn
                selenium.WaitForPageToLoad("30000");
            }
            catch (Exception e)
            {
                verificationErrors.AppendLine("Error at this page: " + selenium.GetLocation() + "\r\n" + e.Message);
            }
            Nunit_Assert("#" + verificationErrors);//?1704?
        }
    }
}