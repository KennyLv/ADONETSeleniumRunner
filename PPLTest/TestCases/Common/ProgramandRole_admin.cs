using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Threading;

namespace PPLTest.TestCases.Common
{
    [TestFixture]
    public class ProgramandRole_admin:BaseCase
    {
        //private StringBuilder verificationErrors;
        private string Programs;
        private string Roles;

        [SetUp]
        public void SetupTest()
        {
            Programs = getdata("Program");
            Roles = getdata("Role");
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
        }

        [Test]
        public void RoleSelectTest()
        {
            //selenium.Open("/PortalManagement/UserProgramRoleSelect.aspx");
            //selenium.Select("ctl00_MainBody_ddUserPrograms", "label=" + Programs);

            try
            {
                selenium.Select("ctl00_MainBody_ddUserPrograms", "label=" + Programs);
            }
            catch
            {
                verificationErrors.Append("Program with [" + Programs + "] can't find\r\n");
            }
            Thread.Sleep(5000);
            //selenium.SetSpeed("2500");
            //selenium.Select("ctl00_MainBody_ddUserProgramRoles", "label=" + Roles);
            try
            {
                selenium.Select("ctl00_MainBody_ddUserProgramRoles", "label=" + Roles);
            }
            catch
            {
                verificationErrors.Append("Role [" + Roles + "] can't find\r\n");
            }
            //selenium.SetSpeed("0");
            try
            {
                selenium.Click("ctl00_MainBody_Button1");
            }
            catch
            {
                verificationErrors.Append("Can't find button 'GO' \r\n");
            }
            try
            {
                selenium.WaitForPageToLoad("30000");
            }
            catch
            {
                verificationErrors.Append("Page load time out \r\n");
            }

            Nunit_Assert("#" + verificationErrors.ToString());
        }

    }
}
