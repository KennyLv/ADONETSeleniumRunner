using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;


namespace PPLTest.ClassLib
{
    //define types for the log
    public enum logType
    {
        Information,
        Alert,
        Error
    }

    public class Log
    {
        private object thisObject = new object();

        #region Constructors of Log
        public Log() { }

        private string CustomDateTime
        {
            get
            {
                return DateTime.Now.ToString();
            }
        }
        #endregion

        #region Overloads for wrie log method

        public void WriteLog(string Message)
        {
            this.WriteLog("", logType.Error, Message);
        }

        public void WriteLog(string className, string Message)
        {
            this.WriteLog(className, logType.Error, Message);
        }

        public void WriteLog(string ClassName, logType thisType, string Message)
        {
            //creat floder
            //string LogFloder = string.Format(@"{0}\{1}",
            //    global::System.Environment.CurrentDirectory, "Log");

            string LogFloder = string.Format(@"{0}", MySuite.SuiteProvider.TestResult_log_Path);

            if (!Directory.Exists(LogFloder))
            {
                Directory.CreateDirectory(LogFloder);
            }

            //creat file
            string RecordFile = string.Format(@"{0}\{1}", LogFloder,
                this.FileStyle(LogNum(LogFloder)) + ".log");


            //composite log content
            string[] ContentArgs = new string[] {
                ClassName,
                thisType.ToString(),
                this.CustomDateTime,
                Message
            };
            string ContentString = string.Format("{0}-{1}:{2}\r\n{3}\r\n", ContentArgs);

            //
            try
            {
                // write or append to target file ..
                using (StreamWriter sw = new StreamWriter(RecordFile, true, Encoding.UTF8))
                {
                    // writing ..
                    sw.WriteLine(ContentString);
                    // registry to trace event class ..
                    //Trace.WriteLine(ContentString, ClassName);
                    // flush buffer ..
                    sw.Flush();
                }
            }
            catch
            { }
        }

        #endregion

        #region Pirvate method for generate log name
        private int LogNum(string LogFloder)
        {
            int CurrentLogNum = 0;
            //
            if (Directory.Exists(LogFloder))
            {
                string pattern = string.Format("*{0}*.log", DateTime.Now.Day);
                //
                string[] files = Directory.GetFiles(LogFloder, pattern, SearchOption.TopDirectoryOnly);

                if (files.Length > 0)
                {
                    CurrentLogNum = files.Length;

                    //？？？？？？？？？？？？？？？？？

                    //            foreach (string s in files.OrderByDescending(s => s))
                    //            {
                    //                FileInfo info = new FileInfo(s);
                    //                if (info.Exists && info.Length < 1048576)
                    //
                    //                    return int.Parse(s.Substring(((s.Length) - 8), 4));//如果小于8？？？？
                    //
                    //                result = s.Substring(((s.Length) - 8), 4);
                    //
                    //                break;
                    //            }
                    //        }
                    //        else
                    //            result = "0000";
                    //    }
                    //    return int.Parse(result) + 1;
                    //}


                }
            }

            return CurrentLogNum + 1;
        }

        private string FileStyle(int num)
        {
            string
             year = DateTime.Now.Year.ToString(),
             month = DateTime.Now.Month.ToString().PadLeft(2, '0'),
             day = DateTime.Now.Day.ToString().PadLeft(2, '0');
            //
            return year + month + day + " (" + num.ToString() + ")";
        }
        #endregion
    }
}
