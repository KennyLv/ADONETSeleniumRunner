using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using Selenium;

namespace PPLTest.TestCases.CO.Role_PPLAdmin.Timesheets
{
    [TestFixture]
    public class TimeInOut : BaseCase
    {
        private string Service;
        #region define timein and timeout
        private string TimeInClock1;
        private string TimeInMin1;
        //private string TimeOutClock1;
        //private string TimeOutMin1;
        private string TimeInClock2;
        private string TimeInMin2;
        //private string TimeOutClock2;
        //private string TimeOutMin2;
        private string TimeInClock3;
        private string TimeInMin3;
        //private string TimeOutClock3;
        //private string TimeOutMin3;
        private string TimeInClock4;
        private string TimeInMin4;
        //private string TimeOutClock4;
        //private string TimeOutMin4;
        private string TimeInClock5;
        private string TimeInMin5;
        //private string TimeOutClock5;
        //private string TimeOutMin5;
        private string TimeInClock6;
        private string TimeInMin6;
        //private string TimeOutClock6;
        //private string TimeOutMin6;
        private string TimeInClock7;
        private string TimeInMin7;
        //private string TimeOutClock7;
        //private string TimeOutMin7;
        private string TimeInClock8;
        private string TimeInMin8;
        //private string TimeOutClock8;
        //private string TimeOutMin8;
        private string TimeInClock9;
        private string TimeInMin9;
        //private string TimeOutClock9;
        //private string TimeOutMin9;
        private string TimeInClock10;
        private string TimeInMin10;
        //private string TimeOutClock10;
        //private string TimeOutMin10;
        private string TimeInClock11;
        private string TimeInMin11;
        //private string TimeOutClock11;
        //private string TimeOutMin11;
        private string TimeInClock12;
        private string TimeInMin12;
        //private string TimeOutClock12;
        //private string TimeOutMin12;
        private string TimeInClock13;
        private string TimeInMin13;
        //private string TimeOutClock13;
        //private string TimeOutMin13;
        private string TimeInClock14;
        private string TimeInMin14;
        //private string TimeOutClock14;
        //private string TimeOutMin14;
        private string TimeInClock15;
        private string TimeInMin15;
        //private string TimeOutClock15;
        //private string TimeOutMin15;
        private string TimeInClock16;
        private string TimeInMin16;
        //private string TimeOutClock16;
        //private string TimeOutMin16;
        private string TimeInClock17;
        private string TimeInMin17;
        //private string TimeOutClock17;
        //private string TimeOutMin17;
        private string TimeInClock18;
        private string TimeInMin18;
        //private string TimeOutClock18;
        //private string TimeOutMin18;
        private string TimeInClock19;
        private string TimeInMin19;
        //private string TimeOutClock19;
        //private string TimeOutMin19;
        private string TimeInClock20;
        private string TimeInMin20;
        //private string TimeOutClock20;
        //private string TimeOutMin20;
        private string TimeInClock21;
        private string TimeInMin21;
        //private string TimeOutClock21;
        //private string TimeOutMin21;
        private string TimeInClock22;
        private string TimeInMin22;
        //private string TimeOutClock22;
        //private string TimeOutMin22;
        private string TimeInClock23;
        private string TimeInMin23;
        //private string TimeOutClock23;
        //private string TimeOutMin23;
        private string TimeInClock24;
        private string TimeInMin24;
        //private string TimeOutClock24;
        //private string TimeOutMin24;
        private string TimeInClock25;
        private string TimeInMin25;
        //private string TimeOutClock25;
        //private string TimeOutMin25;
        private string TimeInClock26;
        private string TimeInMin26;
        //private string TimeOutClock26;
        //private string TimeOutMin26;
        private string TimeInClock27;
        private string TimeInMin27;
        //private string TimeOutClock27;
        //private string TimeOutMin27;
        private string TimeInClock28;
        private string TimeInMin28;
        //private string TimeOutClock28;
        //private string TimeOutMin28;
        private string TimeInClock29;
        private string TimeInMin29;
        //private string TimeOutClock29;
        //private string TimeOutMin29;
        private string TimeInClock30;
        private string TimeInMin30;
        //private string TimeOutClock30;
        //private string TimeOutMin30;
        private string TimeInClock31;
        private string TimeInMin31;
        //private string TimeOutClock31;
        //private string TimeOutMin31;
        #endregion 

        [SetUp]
        public void SetupTest()
        {
            verificationErrors = new StringBuilder();
            Service = getdata("Service").Trim();
            #region gatdata of timein and timeout
            TimeInClock1 = getdata("TimeInClock1").Trim();
            TimeInMin1 = getdata("TimeInMin1").Trim();
            //TimeOutClock1 = getdata("TimeOutClock1").Trim();
            //TimeOutMin1 = getdata("TimeOutMin1").Trim();
            TimeInClock2 = getdata("TimeInClock2").Trim();
            TimeInMin2 = getdata("TimeInMin2").Trim();
            //TimeOutClock2 = getdata("TimeOutClock2").Trim();
            //TimeOutMin2 = getdata("TimeOutMin2").Trim();
            TimeInClock3 = getdata("TimeInClock3").Trim();
            TimeInMin3 = getdata("TimeInMin3").Trim();
            //TimeOutClock3 = getdata("TimeOutClock3").Trim();
            //TimeOutMin3 = getdata("TimeOutMin3").Trim();
            TimeInClock4 = getdata("TimeInClock4").Trim();
            TimeInMin4 = getdata("TimeInMin4").Trim();
            //TimeOutClock4 = getdata("TimeOutClock4").Trim();
            //TimeOutMin4 = getdata("TimeOutMin4").Trim();
            TimeInClock5 = getdata("TimeInClock5").Trim();
            TimeInMin5 = getdata("TimeInMin5").Trim();
            //TimeOutClock5 = getdata("TimeOutClock5").Trim();
            //TimeOutMin5 = getdata("TimeOutMin5").Trim();
            TimeInClock6 = getdata("TimeInClock6").Trim();
            TimeInMin6 = getdata("TimeInMin6").Trim();
            //TimeOutClock6 = getdata("TimeOutClock6").Trim();
            //TimeOutMin6 = getdata("TimeOutMin6").Trim();
            TimeInClock7 = getdata("TimeInClock7").Trim();
            TimeInMin7 = getdata("TimeInMin7").Trim();
            //TimeOutClock7 = getdata("TimeOutClock7").Trim();
            //TimeOutMin7 = getdata("TimeOutMin7").Trim();
            TimeInClock8 = getdata("TimeInClock8").Trim();
            TimeInMin8 = getdata("TimeInMin8").Trim();
            //TimeOutClock8 = getdata("TimeOutClock8").Trim();
            //TimeOutMin8 = getdata("TimeOutMin8").Trim();
            TimeInClock9 = getdata("TimeInClock9").Trim();
            TimeInMin9 = getdata("TimeInMin9").Trim();
            //TimeOutClock9 = getdata("TimeOutClock9").Trim();
            //TimeOutMin9 = getdata("TimeOutMin9").Trim();
            TimeInClock10 = getdata("TimeInClock10").Trim();
            TimeInMin10 = getdata("TimeInMin10").Trim();
            //TimeOutClock10 = getdata("TimeOutClock10").Trim();
            //TimeOutMin10 = getdata("TimeOutMin10").Trim();
            TimeInClock11 = getdata("TimeInClock11").Trim();
            TimeInMin11 = getdata("TimeInMin11").Trim();
            //TimeOutClock11 = getdata("TimeOutClock11").Trim();
            //TimeOutMin11 = getdata("TimeOutMin11").Trim();
            TimeInClock12 = getdata("TimeInClock12").Trim();
            TimeInMin12 = getdata("TimeInMin12").Trim();
            //TimeOutClock12 = getdata("TimeOutClock12").Trim();
            //TimeOutMin12 = getdata("TimeOutMin12").Trim();
            TimeInClock13 = getdata("TimeInClock13").Trim();
            TimeInMin13 = getdata("TimeInMin13").Trim();
            //TimeOutClock13 = getdata("TimeOutClock13").Trim();
            //TimeOutMin13 = getdata("TimeOutMin13").Trim();
            TimeInClock14 = getdata("TimeInClock14").Trim();
            TimeInMin14 = getdata("TimeInMin14").Trim();
            //TimeOutClock14 = getdata("TimeOutClock14").Trim();
            //TimeOutMin14 = getdata("TimeOutMin14").Trim();
            TimeInClock15 = getdata("TimeInClock15").Trim();
            TimeInMin15 = getdata("TimeInMin15").Trim();
            //TimeOutClock15 = getdata("TimeOutClock15").Trim();
            //TimeOutMin15 = getdata("TimeOutMin15").Trim();
            TimeInClock16 = getdata("TimeInClock16").Trim();
            TimeInMin16 = getdata("TimeInMin16").Trim();
            //TimeOutClock16 = getdata("TimeOutClock16").Trim();
            //TimeOutMin16 = getdata("TimeOutMin16").Trim();
            TimeInClock17 = getdata("TimeInClock17").Trim();
            TimeInMin17 = getdata("TimeInMin17").Trim();
            //TimeOutClock17 = getdata("TimeOutClock17").Trim();
            //TimeOutMin17 = getdata("TimeOutMin17").Trim();
            TimeInClock18 = getdata("TimeInClock18").Trim();
            TimeInMin18 = getdata("TimeInMin18").Trim();
            //TimeOutClock18 = getdata("TimeOutClock18").Trim();
            //TimeOutMin18 = getdata("TimeOutMin18").Trim();
            TimeInClock19 = getdata("TimeInClock19").Trim();
            TimeInMin19 = getdata("TimeInMin19").Trim();
            //TimeOutClock19 = getdata("TimeOutClock19").Trim();
            //TimeOutMin19 = getdata("TimeOutMin19").Trim();
            TimeInClock20 = getdata("TimeInClock20").Trim();
            TimeInMin20 = getdata("TimeInMin20").Trim();
            //TimeOutClock20 = getdata("TimeOutClock20").Trim();
            //TimeOutMin20 = getdata("TimeOutMin20").Trim();
            TimeInClock21 = getdata("TimeInClock21").Trim();
            TimeInMin21 = getdata("TimeInMin21").Trim();
            //TimeOutClock21 = getdata("TimeOutClock21").Trim();
            //TimeOutMin21 = getdata("TimeOutMin21").Trim();
            TimeInClock22 = getdata("TimeInClock22").Trim();
            TimeInMin22 = getdata("TimeInMin22").Trim();
            //TimeOutClock22 = getdata("TimeOutClock22").Trim();
            //TimeOutMin22 = getdata("TimeOutMin22").Trim();
            TimeInClock23 = getdata("TimeInClock23").Trim();
            TimeInMin23 = getdata("TimeInMin23").Trim();
            //TimeOutClock23 = getdata("TimeOutClock23").Trim();
            //TimeOutMin23 = getdata("TimeOutMin23").Trim();
            TimeInClock24 = getdata("TimeInClock24").Trim();
            TimeInMin24 = getdata("TimeInMin24").Trim();
            //TimeOutClock24 = getdata("TimeOutClock24").Trim();
            //TimeOutMin24 = getdata("TimeOutMin24").Trim();
            TimeInClock25 = getdata("TimeInClock25").Trim();
            TimeInMin25 = getdata("TimeInMin25").Trim();
            //TimeOutClock25 = getdata("TimeOutClock25").Trim();
            //TimeOutMin25 = getdata("TimeOutMin25").Trim();
            TimeInClock26 = getdata("TimeInClock26").Trim();
            TimeInMin26 = getdata("TimeInMin26").Trim();
            //TimeOutClock26 = getdata("TimeOutClock26").Trim();
            //TimeOutMin26 = getdata("TimeOutMin26").Trim();
            TimeInClock27 = getdata("TimeInClock27").Trim();
            TimeInMin27 = getdata("TimeInMin27").Trim();
            //TimeOutClock27 = getdata("TimeOutClock27").Trim();
            //TimeOutMin27 = getdata("TimeOutMin27").Trim();
            TimeInClock28 = getdata("TimeInClock28").Trim();
            TimeInMin28 = getdata("TimeInMin28").Trim();
            //TimeOutClock28 = getdata("TimeOutClock28").Trim();
            //TimeOutMin28 = getdata("TimeOutMin28").Trim();
            TimeInClock29 = getdata("TimeInClock29").Trim();
            TimeInMin29 = getdata("TimeInMin29").Trim();
            //TimeOutClock29 = getdata("TimeOutClock29").Trim();
            //TimeOutMin29 = getdata("TimeOutMin29").Trim();
            TimeInClock30 = getdata("TimeInClock30").Trim();
            TimeInMin30 = getdata("TimeInMin30").Trim();
            //TimeOutClock30 = getdata("TimeOutClock30").Trim();
            //TimeOutMin30 = getdata("TimeOutMin30").Trim();
            TimeInClock31 = getdata("TimeInClock31").Trim();
            TimeInMin31 = getdata("TimeInMin31").Trim();
            //TimeOutClock31 = getdata("TimeOutClock31").Trim();
            //TimeOutMin31 = getdata("TimeOutMin31").Trim();
            #endregion 
        }

        [TearDown]
        public void TeardownTest()
        {
        }

        [Test]
        public void TimeInOutTest()
        {
            //Select a service
            if (Service == "" || Service == null)
            {
            }
            else
            {
                selenium.Select("ctl00_MainBody_ddServicesMulti", "label=" + Service);
            }
            try
            {
                selenium.WaitForPageToLoad("30000");
            }
            catch
            {
                verificationErrors.AppendLine("Cannot load service type or Timeout!\r\n");
            }

            string Month = getdata("Month").Trim();
            int Day = Convert.ToInt32(getdata("Day"));
            int Year = Convert.ToInt32(getdata("Year"));
            try
            {
                #region Odd months
                if ( Month =="1" || Month =="3" || Month =="5" || Month =="7" || Month =="8" || Month == "10" || Month == "12" || Month == "" || Month == null)
                {
                    if (Day <= 15)
                    {
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock1);
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin1);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock1);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label="+TimeOutMin1);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock2);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin2);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock2);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock3);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin3);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock4);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin4);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock5);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin5);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock6);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin6);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock7);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin7);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock8);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin8);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock9);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin9);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock10);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin10);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock11);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin11);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock12);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin12);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock13);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin13);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock14);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin14);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock14);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin14);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock15);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin15);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock15);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin15);
                    }
                    else
                    {
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock16);
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin16);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock1);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label="+TimeOutMin1);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock17);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin17);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock2);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock18);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin18);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock19);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin19);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock20);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin20);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock21);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin21);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock22);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin22);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock23);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin23);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock24);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin24);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock25);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin25);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock26);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin26);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock27);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin27);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock28);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin28);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock29);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin29);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock14);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin14);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock30);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin30);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock15);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin15);
                        selenium.Select("ctl00_MainBody_dgDays_ctl17_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock31);
                        selenium.Select("ctl00_MainBody_dgDays_ctl17_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin31);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl17_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock15);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl17_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin15);
                    }

                }
                #endregion

                #region Even months
                if (Month == "4" || Month == "6" || Month == "9" || Month == "11")
                {
                    if (Day <= 15)
                    {
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock1);
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin1);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock1);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin1);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock2);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin2);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock2);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock3);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin3);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock4);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin4);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock5);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin5);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock6);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin6);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock7);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin7);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock8);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin8);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock9);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin9);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock10);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin10);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock11);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin11);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock12);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin12);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock13);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin13);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock14);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin14);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock14);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin14);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock15);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin15);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock15);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin15);
                    }
                    else
                    {
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock16);
                        selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin16);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock1);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label="+TimeOutMin1);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock17);
                        selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin17);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock2);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock18);
                        selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin18);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock19);
                        selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin19);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock20);
                        selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin20);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock21);
                        selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin21);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock22);
                        selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin22);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock23);
                        selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin23);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock24);
                        selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin24);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock25);
                        selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin25);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock26);
                        selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin26);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock27);
                        selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin27);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock28);
                        selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin28);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock29);
                        selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin29);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock14);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin14);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock30);
                        selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin30);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock15);
                        //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin15);
                    }
                }
                #endregion

                #region February
                if (Month == "2")
                {
                    if (Year % 400 == 0 || Year % 4 == 0 && Year % 100 != 0)
                    {
                        #region Leap year
                        if (Day <= 15)
                        {
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock1);
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin1);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock1);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin1);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock2);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin2);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock2);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock3);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin3);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock4);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin4);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock5);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin5);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock6);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin6);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock7);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin7);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock8);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin8);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock9);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin9);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock10);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin10);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock11);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin11);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock12);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin12);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock13);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin13);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                            selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock14);
                            selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin14);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock14);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin14);
                            selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock15);
                            selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin15);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock15);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin15);
                        }
                        else
                        {
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock16);
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin16);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock1);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label="+TimeOutMin1);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock17);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin17);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock2);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock18);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin18);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock19);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin19);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock20);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin20);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock21);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin21);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock22);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin22);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock23);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin23);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock24);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin24);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock25);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin25);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock26);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin26);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock27);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin27);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock28);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin28);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                            selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock29);
                            selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin29);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock14);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin14);
                        }
                        #endregion
                    }
                    else
                    {
                        #region Average year
                        if (Day <= 15)
                        {
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock1);
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin1);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock1);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin1);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock2);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin2);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock2);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock3);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin3);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock4);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin4);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock5);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin5);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock6);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin6);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock7);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin7);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock8);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin8);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock9);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin9);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock10);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin10);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock11);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin11);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock12);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin12);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock13);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin13);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                            selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock14);
                            selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin14);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock14);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl15_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin14);
                            selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock15);
                            selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin15);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock15);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl16_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin15);
                        }
                        else
                        {
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock16);
                            selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin16);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock1);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl02_dgHourPeriods_ctl02_ddEndMinute", "label="+TimeOutMin1);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock17);
                            selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin17);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndHour", "label="+TimeOutClock2);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl03_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin2);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock18);
                            selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin18);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock3);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl04_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin3);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock19);
                            selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin19);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock4);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl05_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin4);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock20);
                            selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin20);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock5);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl06_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin5);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock21);
                            selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin21);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock6);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl07_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin6);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock22);
                            selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin22);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock7);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl08_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin7);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock23);
                            selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin23);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock8);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl09_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin8);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock24);
                            selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin24);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock9);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl10_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin9);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock25);
                            selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin25);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock10);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl11_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin10);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock26);
                            selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin26);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock11);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl12_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin11);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock27);
                            selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin27);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock12);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl13_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin12);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddHoursWorked", "label=" + TimeInClock28);
                            selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddMinutesWorked", "label=" + TimeInMin28);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndHour", "label=" + TimeOutClock13);
                            //selenium.Select("ctl00_MainBody_dgDays_ctl14_dgHourPeriods_ctl02_ddEndMinute", "label=" + TimeOutMin13);
                        }
                        #endregion
                    }
                 }
                #endregion

                selenium.Click("ctl00_MainBody_bSubmit");
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
