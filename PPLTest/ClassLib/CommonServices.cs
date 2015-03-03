using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Rex;
using System.Net.Sockets;
using System.Net;

namespace PPLTest.ClassLib
{
    public class CommonServices
    {
        /// <summary>
        /// Constructor of CommonServices
        /// </summary>
        public CommonServices()
        { }

        /// <summary>
        /// generate data from the regular expression
        /// </summary>
        /// <param name="regex"></param>
        /// <returns></returns>
        public string CreatString(string regex)
        {
            string newresult = "";
            //creat instance
            RexSettings settings = new RexSettings(regex);
            settings.encoding = CharacterEncoding.ASCII;
            //
            IEnumerable<string> sdf = RexEngine.GenerateMembers(settings);
            foreach (string result in sdf)
            {
                newresult = result;
                break;
            }
            return newresult;
        }
     
        /// <summary>
        /// creat name with datetime
        /// </summary>
        /// <param name="returnType">should be "TestReport", "imgName"... </param>
        /// <returns>return "ymdhmsm","ymdhs",or "yms" according to the return type</returns>
        public string FileName(string returnType)
        {
            string NewFleName = "";
            string
                year = DateTime.Now.Year.ToString(),
                month = DateTime.Now.Month.ToString().PadLeft(2, '0'),
                day = DateTime.Now.Day.ToString().PadLeft(2, '0'),
                hour = DateTime.Now.Hour.ToString(),
                minute = DateTime.Now.Minute.ToString(),
                second = DateTime.Now.Second.ToString(),
                millis = DateTime.Now.Millisecond.ToString();
            switch(returnType)
            {
                case "TestReport":
                    NewFleName = year + "-" + month + "-" + day + "   " + hour + "'" + minute + "'" + second + "'" + millis;
                    break;
                case "imgName":
                    NewFleName = day + "-" + hour + "-" + minute + "-" + second + "-" + millis;
                    break;
                default:
                    NewFleName = year + month + day;
                    break;
            }
            return NewFleName;
        }
 
        /// <summary>
        /// Clip the string character and numeric character
        /// </summary>
        /// <param name="orgionName">should be combined by string and numbers like "User6"</param>
        /// <returns></returns>
        public string[] ClipName(string orgionName)
        {
            string[] MultiRow=new string[2];
            //get the length of the string characters
            int charlength = getCharEnd(orgionName);
            string rowname = orgionName.Substring(0, charlength);
            MultiRow.SetValue(rowname, 0);
            //get the number behind the strings
            int startNum = 0;
            try
            {
                startNum = int.Parse(orgionName.Substring(charlength, orgionName.Length - charlength));
            }
            catch{}
            MultiRow.SetValue(startNum.ToString(), 1);
            return MultiRow;
        }

        /// <summary>
        /// get the index of first numeric char
        /// </summary>
        /// <param name="s"></param>
        /// <returns>the location of the character first app</returns>
        private int getCharEnd(string s)
        {
            int count = 0;
            foreach (char character in s)
            {
                count += 1;
                if (char.IsDigit(character))//got it
                {
                    break;
                }
            }
            return count - 1;
        }
    }
}