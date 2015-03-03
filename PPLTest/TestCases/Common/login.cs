using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;
using PPLTest.MySuite;

namespace PPLTest.TestCases.Common
{
    [TestFixture]
    public class login : BaseCase
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
        public void LoginTest()
        {
            try
            {
                //open the login page
                string url_login = SuiteProvider.TestingEnvironment_login;
                selenium.Open(url_login);
               // selenium.Open("/PortalManagement/");
                //get username from the excel and type into the textbox which has a id valued 'ctl00_MainBody_txtUserName1'
                selenium.Type("ctl00_MainBody_txtUserName1", getdata("UseName"));
                selenium.Type("ctl00_MainBody_txtPassword1", getdata("PassWord"));
                //click the Login(has a id valued 'ctl00_MainBody_btnLogin1') button
                selenium.Click("ctl00_MainBody_btnLogin1");
                //wait for the page load ,set the timeout to 30 seconds
                selenium.WaitForPageToLoad("30000");
            }
            catch (Exception ex)
            {
                verificationErrors.Append(ex.Message);
            }
            //check the result
            Nunit_Assert("#" + verificationErrors);
        }
    }
 }