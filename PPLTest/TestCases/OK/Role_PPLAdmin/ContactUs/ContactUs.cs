using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace PPLTest.TestCases.OK.Role_PPLAdmin.ContactUs
{
    [TestFixture]
    public class ContactUs : BaseCase
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
        public void ContactUsTest()
        {
            try
            {
                selenium.Click("link=Contact Us");
            }
            catch
            {
                verificationErrors.AppendLine("Cannot click Contact Us link!\r\n");
            }

            try
            {
                selenium.WaitForPageToLoad("30000");
            }
            catch
            {
                verificationErrors.AppendLine("Timeout!\r\n");
            }

            try
            {
                selenium.Type("ctl00_MainBody_txtName1", getdata("Name"));
                selenium.Type("ctl00_MainBody_txtPhone1", getdata("ContactPhone"));
                selenium.Type("ctl00_MainBody_txtEmail1", getdata("Email"));
                selenium.Type("ctl00_MainBody_txtSubject1", getdata("Subject"));
                selenium.Type("ctl00_MainBody_txtComments1", getdata("Comments"));
                selenium.Click("ctl00_MainBody_btnSubmit");
            }
            catch
            {
                verificationErrors.AppendLine("Cannot enter information!\r\n");
            }

            try
            {
                selenium.WaitForPageToLoad("30000");
            }
            catch
            {
                verificationErrors.AppendLine("Timeout!\r\n");
            }

            Nunit_Assert("#" + verificationErrors.ToString());

        }
    }
}

