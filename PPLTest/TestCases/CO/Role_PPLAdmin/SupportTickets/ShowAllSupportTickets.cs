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
 * Description:Show the All SupportTickets Page
 */
namespace PPLTest.TestCases.CO.Role_PPLAdmin.SupportTickets
{
    [TestFixture]
    public class ShowAllSupportTickets : BaseCase
    {
        private string District_Id;
        private string Assigned_To;
        private string Show_First;
        private string Category;
        private string Sub_Category;

        [SetUp]
        public void SetupTest()
        {
            District_Id = getdata("District Id");
            Assigned_To = getdata("Assigned To");
            Show_First = getdata("Show First");
            Category = getdata("Category");
            Sub_Category = getdata("Sub-Category");
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
                selenium.Click("ctl00_MainBody_rdStatusList_2");
            }
            catch
            {
                verificationErrors.AppendLine("'All'button can't find\r\n");
            }

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

            string caseExTime1 = endTime1.Subtract(startTime1).Duration().TotalSeconds.ToString();

            InputSearchTime("Error after ticking All box in Support Ticket link", caseExTime1);
            //

            try
            {
                if (District_Id == "" || District_Id == null)
                {
                    selenium.Select("ctl00_MainBody_ddDistrictId", "label=- Select -");
                }
                else
                {
                    selenium.Select("ctl00_MainBody_ddDistrictId", "label=" + District_Id);
                }



                if (Assigned_To == "" || Assigned_To == null)
                {
                    selenium.Select("ctl00_MainBody_ddAssignedTo", "label=- Select -");
                }
                else
                {
                    selenium.Select("ctl00_MainBody_ddAssignedTo", "label=" + Assigned_To);
                }

                selenium.Type("ctl00_MainBody_txtEmployeeID", getdata("Provider ID"));
                selenium.Type("ctl00_MainBody_txtEmployeeName", getdata("Provider Name"));
                selenium.Type("ctl00_MainBody_txtTicketID1", getdata("Ticket ID"));
                selenium.Type("ctl00_MainBody_txtConsumerLastName", getdata("Participant Last Name"));
                selenium.Type("ctl00_MainBody_txtConsumerFirstName", getdata("Participant First Name"));

                if (Show_First == "" || Show_First == null)
                {
                    selenium.Select("ctl00_MainBody_ddRecords", "label=100");
                }
                else
                {
                    selenium.Select("ctl00_MainBody_ddRecords", "label=" + Show_First);
                }

                selenium.Type("ctl00_MainBody_txtCaseManagerLastName", getdata("Case Manager Last Name"));

                if (Category == "" || Category == null)
                {
                    selenium.Select("ctl00_MainBody_ddCategory", "label=- Select -");
                }
                else
                {
                    if (Category != "- Select -")
                    {
                        selenium.Select("ctl00_MainBody_ddCategory", "label=" + Category);
                        selenium.WaitForPageToLoad("30000");
                    }
                    else
                    {
                        selenium.Select("ctl00_MainBody_ddCategory", "label=- Select -");
                    }
                }

                if (Sub_Category == "" || Sub_Category == null)
                {
                    selenium.Select("ctl00_MainBody_ddSubCategory", "label=- Select -");
                }
                else
                {
                    selenium.Select("ctl00_MainBody_ddSubCategory", "label=" + Sub_Category);
                }

                selenium.Type("ctl00_MainBody_txtStartDate1", getdata("Start Date From"));
                selenium.Type("ctl00_MainBody_txtStartDateTo", getdata("Start To"));

                selenium.Type("ctl00_MainBody_txtNote", getdata("Note"));

                selenium.Type("ctl00_MainBody_txtEndDate1", getdata("Close Date From"));
                selenium.Type("ctl00_MainBody_txtEndDateTo", getdata("Close To"));
            }
            catch
            {
                verificationErrors.AppendLine("Can't enter search criteria!\r\n");
            }

            try
            {
                selenium.Click("ctl00_MainBody_btnSubmit");
            }
            catch
            {
                verificationErrors.AppendLine("Filter button can't find\r\n");
            }


            //
            TimeSpan startTime2 = new TimeSpan(DateTime.Now.Ticks);
            try
            {
                selenium.WaitForPageToLoad(timeOutSpan);
            }
            catch
            {
                verificationErrors.AppendLine("Timeout!\r\n");
            }
            TimeSpan endTime2 = new TimeSpan(DateTime.Now.Ticks);

            string caseExTime2 = endTime2.Subtract(startTime2).Duration().TotalSeconds.ToString();

            InputSearchTime("Error after clicking Search button on All page in Support Tickets link", caseExTime2);
            //

            try
            {
                Nunit_Assert("#" + verificationErrors.ToString());
            }
            catch (AssertionException e)
            {
                verificationErrors.AppendLine(e.Message);
            }

        }
    }
}
