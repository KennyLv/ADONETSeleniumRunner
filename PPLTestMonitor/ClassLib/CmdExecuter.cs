using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Collections;

namespace PPLTestMonitor.ClassLib
{
    public class CmdExecuter
    {
        public CmdExecuter()
        {
 
        }
        /// <summary>
        /// 运行CMD命令
        /// </summary>
        /// <param name="cmd">命令</param>
        /// <returns></returns>
        public  void ExecuteCMD(string[] cmd)
        {
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.RedirectStandardError = true;
            p.StartInfo.CreateNoWindow = false;
            p.Start();
            p.StandardInput.AutoFlush = true;
            for (int i = 0; i < cmd.Length; i++)
            {
                p.StandardInput.WriteLine(cmd[i].ToString());

            }
            //p.StandardInput.WriteLine("exit");
            ////string strRst = p.StandardOutput.ReadToEnd();
            //p.WaitForExit();
            //p.Close();
           // return strRst;
        }

        /// <summary>
        /// 关闭进程
        /// </summary>
        /// <param name="ProcName">进程名称</param>
        /// <returns></returns>
        public void CloseProcess(string ProcName)
        {
            string tempName = "";
            int begpos;
            int endpos;
            #region select the process with the procName wanted
            foreach (Process thisProc in Process.GetProcesses())
            {
                tempName = thisProc.ToString();
                begpos = tempName.IndexOf("(") + 1;
                endpos = tempName.IndexOf(")");
                tempName = tempName.Substring(begpos, endpos - begpos);

                if (tempName == ProcName)
                {
                    try
                    {
                        if (!thisProc.CloseMainWindow())
                        {
                            thisProc.Kill(); // 当发送关闭窗口命令无效时强行结束进程
                        }
                    }
                    catch { }
                }
            }
            #endregion
        }

    }
}
