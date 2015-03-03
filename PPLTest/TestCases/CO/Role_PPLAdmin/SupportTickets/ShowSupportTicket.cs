//===============================================================================================
//HopeRun Teco.
//PPL TEST TEAM
//===============================================================================================
//Copyright@HopeRun Corporation,All rights reserved.
//This code released under the terms of the PPL
//===============================================================================================
using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;
using System.Threading;
/*
 * Author: S
 * Create time:2010/12/27
 * Last modify:2010/12/27  S
 * Description:Show the SupportTickets Page
 */
namespace PPLTest.TestCases.CO.Role_PPLAdmin.SupportTickets
{
    [TestFixture]
    public class ShowSupportTicket : BaseCase
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
        public void TheUntitledTest()
        {
            try
            {
                selenium.Click("link=Support Tickets");
                selenium.WaitForPageToLoad("30000");
            }
            catch
            {
                verificationErrors.AppendLine("Timeout\r\n");
            }
            
           
           Nunit_Assert("#" + verificationErrors.ToString());
            
        }
    }
}
