using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Net;
using System.Configuration;
using System.Xml;
using PPLTestMonitor.ClassLib;
using System.IO;
using System.Threading;

namespace PPLTestMonitor
{
    public partial class Monitor : Form
    {
        #region global variables
        private TestRunner myTester;
        private ResultMonitor myMonitor;

        private List<string> myStates;
        private string loadUrl = "";
        private string envior = "";

        private Thread th_StartTest = null;
        private Thread th_StartMonitor = null;
        private Thread th_RunningTimer = null;

        #endregion

        #region Constructor

        public Monitor()
        {
            InitializeComponent();
        }
        ~Monitor()
        {
            // clean all resource ..
            this.Dispose(true);
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
        #endregion  

        #region loading & closing
        private void Monitor_Load(object sender, EventArgs e)
        {
            //所有州的设定
            this.Config_txt_All_timeoutNum.Text = Properties.mySettings.Default.MaxTimeOutNum_all.ToString();
            this.Config_txt_All_maxTime.Text = Properties.mySettings.Default.TimeOutFilter_all.ToString();
            this.Config_txt_All_timeSpan.Text = Properties.mySettings.Default.TimeOutSpan_all.ToString();
            //单个操作的设定
            this.Config_txt_fun_timeoutNum.Text = Properties.mySettings.Default.MaxTimeOutNum_fun.ToString();
            this.Config_txt_fun_maxTime.Text = Properties.mySettings.Default.TimeOutFilter_fun.ToString();
            this.Config_txt_fun_timeSpan.Text = Properties.mySettings.Default.TimeOutSpan_fun.ToString();
            //脚本路径的设定
            this.Run_lab_scriptFilePath.Text = Properties.mySettings.Default.FilePath;
            //运行环境的设定（包含写入Config的动作）
            this.Run_combin_chooseEnvior.SelectedIndex = 0;

            #region 获得的州信息
            string strFileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "States.xml";
            XmlDocument doc = new XmlDocument();
            if (!File.Exists(strFileName))
            {
                XmlDeclaration declare = doc.CreateXmlDeclaration("1.0", "utf-8", null);
                doc.AppendChild(declare);
                //add the root node
                XmlElement Root = doc.CreateElement("States");
                doc.AppendChild(Root);
                //save the info to the file
                doc.Save(strFileName);
            }
            //获得配置文件的全路径
            doc.Load(strFileName);
            XmlNodeList allStates = doc.SelectNodes("States/State");
            foreach (XmlNode state in allStates)
            {
                Run_CheckList_checkStates.Items.Add(state.InnerText);
            }
            #endregion

            //州间启动间隔
            this.Run_txt_StateStartTime.Text = Properties.mySettings.Default.StatesStartTimeSpan.ToString();
            //单个州间隔启动的时间
            this.Run_txt_singleStateRunTime.Text = Properties.mySettings.Default.SingleStateRunTime.ToString();

            //是否邮件的设定
            this.Run_checkBox_WetherSend.Checked = Properties.mySettings.Default.Send;
            //总运行时间的设定
            this.Run_txt_totalTime.Text = Properties.mySettings.Default.TotalRunTime.ToString();
        }

        private void Monitor_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show(this,
                "关闭本窗口将会结束所有正在运行的测试！\n确定要关闭吗？",
                this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                #region Kill the thread
                stopAll();
                #endregion
            }
            else
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

        #endregion

        #region Configuration
        private void Config_but_Cancel_Click(object sender, EventArgs e)
        {
            this.tabControl1.SelectedIndex += 1;
        }

        private void Config_but_OK_Click(object sender, EventArgs e)
        {
            //针对所有州的设定
            Properties.mySettings.Default.MaxTimeOutNum_all = int.Parse(this.Config_txt_All_timeoutNum.Text.Trim());
            Properties.mySettings.Default.TimeOutFilter_all = int.Parse(this.Config_txt_All_maxTime.Text.Trim());
            Properties.mySettings.Default.TimeOutSpan_all = int.Parse(this.Config_txt_All_timeSpan.Text.Trim());
            //针对单个操作的设定
            Properties.mySettings.Default.MaxTimeOutNum_fun = int.Parse(this.Config_txt_fun_timeoutNum.Text.Trim());
            Properties.mySettings.Default.TimeOutFilter_fun = int.Parse(this.Config_txt_fun_maxTime.Text.Trim());
            Properties.mySettings.Default.TimeOutSpan_fun = int.Parse(this.Config_txt_fun_timeSpan.Text.Trim());

            Properties.mySettings.Default.Save();
            this.tabControl1.SelectedIndex += 1;
        }
        #endregion

        #region Run
        private void Run_but_changeFilePath_Click(object sender, EventArgs e)
        {
            OpenFileDialog myDialog = new OpenFileDialog();
            if (myDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName=myDialog.FileName;
                this.Run_lab_scriptFilePath.Text = fileName.Substring(0, fileName.LastIndexOf('\\'));
            }
            myDialog.Dispose();
        }

        private void Run_combin_chooseEnvior_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (this.Run_combin_chooseEnvior.SelectedIndex)
            {
                case 0:
                    //<!--Prep:  https://fmsdev.publicpartnerships.com/Portalprep/-->
                    this.loadUrl = "https://fmsdev.publicpartnerships.com/Portalprep";
                    this.envior = "Prep";
                    break;
                case 1:
                    //<!--Production:https://fms.publicpartnerships.com/PPLPortal/-->
                    this.loadUrl = "https://fms.publicpartnerships.com/PPLPortal";
                    this.envior = "Product";
                    break;
                case 2:
                    //<!--test:http://fmsdev.publicpartnerships.com/PortalManagement/-->
                    this.loadUrl = "http://fmsdev.publicpartnerships.com/PortalManagement";
                    this.envior = "Test";
                    break;
            }
            string configXML = this.Run_lab_scriptFilePath.Text + "\\Config.xml";
            if (File.Exists(configXML))
            {
                XmlDocument xmld = new XmlDocument();
                xmld.Load(configXML);
                xmld.SelectSingleNode("Settings/URL").InnerText = this.loadUrl;
                xmld.SelectSingleNode("Settings/Envior").InnerText = this.envior;
                xmld.Save(configXML);
            }
            else
            {
                MessageBox.Show(configXML + "不存在！！");
            }
        }

        private void Run_but_deleteState_Click(object sender, EventArgs e)
        {
            if (Run_CheckList_checkStates.CheckedItems.Count < 1)
            {
                return;
            }
            //从后向前排查，防止减掉后INDEX错误
            for (int i = Run_CheckList_checkStates.Items.Count-1; i >= 0; i--)
            {
                if (Run_CheckList_checkStates.GetItemChecked(i))
                {
                    Run_CheckList_checkStates.Items.RemoveAt(i);
                }
            }
            SaveStateItems(Run_CheckList_checkStates);
        }

        private void Run_but_addState_Click(object sender, EventArgs e)
        {
            string addState = "null";
            AddState addForm = new AddState();
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                addForm.Dispose();
                addState = AddState.newState;
                if (addState != "" && addState != null)
                {
                    Run_CheckList_checkStates.Items.Add(addState);
                }
            }
            SaveStateItems(Run_CheckList_checkStates);
        }

        private void SaveStateItems(CheckedListBox cb)
        {
            XmlDocument doc = new XmlDocument();
            //获得配置文件的全路径
            string strFileName = AppDomain.CurrentDomain.BaseDirectory.ToString() + "States.xml";
            doc.Load(strFileName);
            XmlNode allStates = doc.SelectSingleNode("States");
            if (allStates.HasChildNodes)
            {
                allStates.RemoveAll();
            }
            foreach (string state in Run_CheckList_checkStates.Items)
            {
                XmlElement myState = doc.CreateElement("State");
                myState.InnerText = state;
                allStates.AppendChild(myState);
            }
            doc.Save(strFileName);
        }

        private void Run_radio_startInParallel_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Run_radio_startInParallel.Checked)
            {
                this.Run_txt_StateStartTime.Enabled = false;
                this.label2.Enabled = false;
            }
        }

        private void Run_radio_startInOrder_CheckedChanged(object sender, EventArgs e)
        {
            if (Run_radio_startInOrder.Checked)
            {
                this.Run_txt_StateStartTime.Enabled = true;
                this.label2.Enabled = true;
            }
        }

        private void Run_checkBox_WetherSend_CheckedChanged(object sender, EventArgs e)
        {
            Properties.mySettings.Default.Send = this.Run_checkBox_WetherSend.Checked;
            Properties.mySettings.Default.Save();
        }

        private void Run_but_Click(object sender, EventArgs e)
        {
            #region check the environment setting
            if (this.Run_CheckList_checkStates.CheckedItems.Count < 1)
            {
                MessageBox.Show("请选择要运行的州！");
                return;
            }

            if (this.Run_radio_startInParallel.Checked)
            {
                Properties.mySettings.Default.StatesStartTimeSpan = 0;
            }
            else
            {
                try
                {
                    Properties.mySettings.Default.StatesStartTimeSpan = int.Parse(this.Run_txt_StateStartTime.Text.Trim());
                }
                catch
                {
                    MessageBox.Show("请正确填入各州启动时间间隔！\n   1:必须为数字\n   2:必须大于0");
                    return;
                }
            }


            try
            {
                Properties.mySettings.Default.SingleStateRunTime = int.Parse(this.Run_txt_singleStateRunTime.Text.Trim());
            }
            catch
            {
                MessageBox.Show("请正确填入各州运行时间！\n   1:必须为数字\n   2:必须大于0");
                return;
            }

            try
            {
                Properties.mySettings.Default.TotalRunTime =Convert.ToDouble(this.Run_txt_totalTime.Text.Trim());
            }
            catch
            {
                MessageBox.Show("请正确填入总运行时间！\n   1:必须为数字\n   2:必须大于0");
                return;
            }

            #endregion

            DialogResult result = MessageBox.Show(this, EnvironmentConfirmation(), this.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            
            #region Running
            if (result == DialogResult.OK)
            {
                #region save the settings
                Properties.mySettings.Default.Save();
                #endregion


                this.Run_but_RUN.Enabled = false;

                this.Run_combin_chooseEnvior.Enabled = false;

                th_StartTest = new Thread(new ThreadStart(this.StartTester));
                th_StartTest.Start();

                Thread.Sleep(10000);

                th_StartMonitor = new Thread(new ThreadStart(this.StartMonitor));
                th_StartMonitor.Start();

                th_RunningTimer = new Thread(new ThreadStart(this.StopTimer));
                th_RunningTimer.Start();


            }
            #endregion
        }

        private void StartTester()
        {
            myTester = new TestRunner();
            myTester.ScriptFilePath = this.Run_lab_scriptFilePath.Text.Trim();
            myTester.TestStates = this.myStates;
            myTester.LoadURL = this.loadUrl;
            myTester.BeginTest();
        }
        private void StartMonitor()
        {
            myMonitor = new ResultMonitor();
            myMonitor.MyStartTime = DateTime.Now;
            myMonitor.BeginMonitor(); 
        }
        private void StopTimer()
        {
            DateTime endTime = 
                DateTime.Now.AddMinutes(Convert.ToDouble(this.Run_txt_totalTime.Text.Trim()));
            do
            {
                Thread.Sleep(6000);//10分钟
            } while (DateTime.Now < endTime);
            stopAll();
        }

        #endregion

        private string EnvironmentConfirmation()
        {
            myStates = new List<string>();

            string ConformMessage = "相关环境设置如下：\n";
            #region Confirm
            ConformMessage += "脚本路径为：" + this.Run_lab_scriptFilePath.Text + "\n";
            ConformMessage += "运行环境为" + this.Run_combin_chooseEnvior.SelectedItem + ":\n" + this.loadUrl + "\n测试的州为：";

            foreach (string checkedItem in this.Run_CheckList_checkStates.CheckedItems)
            {
                ConformMessage += checkedItem + "\\";
                myStates.Add(checkedItem);
            }
            if (this.Run_radio_startInOrder.Checked)
            {
                ConformMessage += "\n\n各州启动间隔" + this.Run_txt_StateStartTime.Text.ToString() + "秒\n";
            }
            else
            {
                ConformMessage += "\n\n各州同时启动\n";
            }
            ConformMessage += "各州重复测试间隔：" + this.Run_txt_singleStateRunTime.Text.ToString() + "分钟\n";
            ConformMessage += "\n是否发送邮件：" + this.Run_checkBox_WetherSend.Checked.ToString() + "\n";
            ConformMessage += "\n总共运行：" + this.Run_txt_totalTime.Text.ToString() + "分钟\n";
            ConformMessage += "\n确认无误？";
            #endregion
            return ConformMessage;
        }


        private void stopAll()
        {
            if (myTester != null)
            {
                myTester.EndTest();
                myTester.Dispose();
            }
            if (myMonitor != null)
            {
                myMonitor.Dispose();
            }


            if (th_StartTest != null && th_StartTest.IsAlive)
            {
                th_StartTest.Abort();
            }
            if (th_StartMonitor != null && th_StartMonitor.IsAlive)
            {
                th_StartMonitor.Abort();
            }
            if (th_RunningTimer != null && th_RunningTimer.IsAlive)
            {
                th_RunningTimer.Abort();
            }
        }

    }
}
