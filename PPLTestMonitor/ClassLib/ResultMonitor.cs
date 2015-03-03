using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Xml;
using System.Data;
using PPLTestMonitor.Entity;
using System.IO;
using System.Text.RegularExpressions;
using MySqlOperator;

namespace PPLTestMonitor.ClassLib
{
    public class ResultMonitor:IDisposable
    {
        private MailServer myMail;
        //private List<ActionObj> actions = new List<ActionObj>();

        //xml文件地址
        //private string dataPath;
        //private XmlDocument myXmlDoc = new XmlDocument();
        //private Mutex readMutex = new Mutex();
        //int actionIndex=-1;

        //开始时间
        private DateTime myStartTime;
        public DateTime MyStartTime
        {
            get { return myStartTime; }
            set { myStartTime = value; }
        }

        private AutoResetEvent DataTableUpdateNotify = null;
        private Thread th_GetData = null;
        private Thread th_MonitorData = null;


        private DBHelper mySqlHelper;
        private DataTable CurrentAddedData;
        private DataSet FilterDataTablesCollection;
        private DataTable allStateFilterData;
        private string sqlConnectString;

        //是否邮件
        private bool sendMail;


        //所有大于多少算超时
        private int timeOutFilter_inSecond_all;
        //所有超时个数条件
        private int maxTimeOutNum_int_all;
        //所有超时时间范围
        private int timeOutSpan_inMinute_all;

        //单个大于多少算超时
        private int timeOutFilter_inSecond_funtion;
        //单个超时个数条件
        private int maxTimeOutNum_int_funtion;
        //单个超时时间范围
        private int timeOutSpan_inMinute_funtion;

        //private string enviorment;
        //public string Enviorment
        //{
        //    get { return enviorment; }
        //    set { enviorment = value; }
        //}

        private string alertMailSubject = "Performance/Monitoring Timeout Alert";


        public ResultMonitor()
        {

        }
        ~ResultMonitor()
        {
            //删除数据
        }
        public void Dispose()
        {
            if (th_GetData != null)
            {
                th_GetData.Abort();
            }
            if (th_MonitorData != null)
            {
                th_MonitorData.Abort();
            }
            if (CurrentAddedData != null)
            {
                CurrentAddedData.Dispose();
            }
            FilterDataTablesCollection.Dispose();
            allStateFilterData.Dispose();

            // this object will be cleaned up by the dispose method ..
            GC.SuppressFinalize(this);
        }

        public void BeginMonitor()
        {
            //CurrentAddedData = new DataTable();
            FilterDataTablesCollection = new DataSet();
            //allStateFilterData = new DataTable();

            sqlConnectString = Properties.mySettings.Default.ConnectionString;
            mySqlHelper = new DBHelper(sqlConnectString);


            timeOutFilter_inSecond_all = Properties.mySettings.Default.TimeOutFilter_all;
            maxTimeOutNum_int_all = Properties.mySettings.Default.MaxTimeOutNum_all;
            timeOutSpan_inMinute_all = Properties.mySettings.Default.TimeOutSpan_all;

            timeOutFilter_inSecond_funtion = Properties.mySettings.Default.TimeOutFilter_fun;
            maxTimeOutNum_int_funtion = Properties.mySettings.Default.MaxTimeOutNum_fun;
            timeOutSpan_inMinute_funtion = Properties.mySettings.Default.TimeOutSpan_fun;

            this.DataTableUpdateNotify = new AutoResetEvent(true);
            th_GetData = new Thread(new ThreadStart(this.GetData));
            th_GetData.Start();

            Thread.Sleep(2000);

            th_MonitorData = new Thread(new ThreadStart(this.MonitorData));
            th_MonitorData.Start();
        }

        private void GetData()
        {
            do
            {
                #region
                /*
                dataPath = Properties.mySettings.Default.FilePath + "\\TestResult\\Temp.xml";
                if (File.Exists(dataPath))
                {
                    ////尝试锁定，读取数据（州、操作名、花费时间、发生时间、测试环境）
                    readMutex.WaitOne();
                    myXmlDoc.Load(dataPath);
                    string selectXpath = "Recodes/Action[position()>" + actionIndex + "]";
                    XmlNodeList myNodeList = myXmlDoc.SelectNodes(selectXpath);
                    myXmlDoc.Save(dataPath);
                    readMutex.ReleaseMutex();///取消锁定

                    #region 遍历后继结点
                    foreach (XmlNode myNode in myNodeList)
                    {
                        ////维护列表（包含筛选条件（什么类大于多少秒））
                        if (Convert.ToDouble(myNode.Attributes["timeSpan"].InnerText.Trim()) > timeOutFilter_inSecond_all)
                        {
                            //<Action state="ME" timeSpan="35" time="2011/3/10 9:34:03">edit IP</Action>
                            ActionObj myAction = new ActionObj();
                            myAction.Action = myNode.InnerText.Trim();
                            myAction.State = myNode.Attributes["state"].InnerText.Trim();
                            myAction.Time = DateTime.Parse(myNode.Attributes["time"].InnerText.Trim());
                            myAction.TimeSpan = myNode.Attributes["timeSpan"].InnerText.Trim();
                            actions.Add(myAction);

                            #region 前后6个在40分钟内发邮件，清除列表（先进先出）
                            if (actions.Count > maxTimeOutNum_int_all - 1)
                            {
                                if (new TimeSpan(actions[maxTimeOutNum_int_all - 1].Time.Ticks - actions[0].Time.Ticks).Duration().Minutes < timeOutSpan_inMinute_all)
                                {
                                    if (this.sendMail)
                                    {
                                        string subject = maxTimeOutNum_int_all.ToString() + "timeouts within " + timeOutSpan_inMinute_all.ToString() + " minutes";
                                        string content = "<div><span>Time Out Define: takes more then " + timeOutFilter_inSecond_all.ToString() + " seconds</span><br/>";
                                        content += "<table style=\"border:1px solid blue;background-color:#CCCCCC;\"><tr><th>State</th><th>Action</th><th>TimeCost(S)</th><th>Time</th><th>Enviornment</th></tr>";
                                        for (int s = 0; s < actions.Count; s++)
                                        {
                                            content += "<tr><td>" + actions[s].State + "</td><td>" + actions[s].Action
                                                + "</td><td>" + actions[s].TimeSpan + "</td><td>" + actions[s].Time.ToString()
                                                + "</td><td>" + this.enviorment + "</td></tr>";
                                        }
                                        content += "</table></div>";
                                        myMail.sendMail(subject, content);
                                    }
                                    actions.Clear();
                                }
                                else
                                {
                                    actions.RemoveAt(0);
                                }
                            }
                            #endregion


                        }
                        ////更新UI


                        //移动指针
                        actionIndex += 1;
                    }
                    #endregion
                }*/
                #endregion

                DataTableUpdateNotify.WaitOne();

                //按最小的条件来筛选
                double timeSpanFilter = Convert.ToDouble((timeOutFilter_inSecond_funtion > timeOutFilter_inSecond_all) ? timeOutFilter_inSecond_all : timeOutFilter_inSecond_funtion);
                this.CurrentAddedData = mySqlHelper.GetAllTimeOutInfo(this.myStartTime, timeSpanFilter);

                if (CurrentAddedData.Rows.Count > 0)
                {
                    #region 分解结果
                    //获得表结构
                    lock (this.CurrentAddedData)
                    {
                        for (int r = 0; r < CurrentAddedData.Rows.Count; r++)
                        {
                            try
                            {
                                double timespan = Convert.ToDouble(CurrentAddedData.Rows[r]["TimeSpan"].ToString());
                                ////从所有的结果中筛选单个动作（有可能全部都是）
                                if (timespan >= Convert.ToDouble(timeOutFilter_inSecond_funtion))
                                {
                                    //取得各州的操作，并分别创建临时表
                                    string f = CurrentAddedData.Rows[r]["State"].ToString() + CurrentAddedData.Rows[r]["Action"].ToString();
                                    string myFunction = Regex.Replace(f, @"\s", "");//去掉所有空格，"MAProviderSearch"
                                    if (!FilterDataTablesCollection.Tables.Contains(myFunction))
                                    {
                                        DataTable functionTable = CurrentAddedData.Clone();
                                        functionTable.TableName = myFunction;
                                        FilterDataTablesCollection.Tables.Add(functionTable);
                                    }
                                    //添加数据到对应的表()
                                    FilterDataTablesCollection.Tables[myFunction].ImportRow(CurrentAddedData.Rows[r]);
                                    //DataRow r = FilterDataTablesCollection.Tables[myFunction].NewRow();
                                    //r.ItemArray = CurrentAddedData.Rows[r].ItemArray;
                                    //FilterDataTablesCollection.Tables[myFunction].Rows.Add(r);
                                }

                                //筛选所有
                                if (timespan >= Convert.ToDouble(timeOutFilter_inSecond_all))
                                {
                                    if (allStateFilterData == null)
                                    {
                                        allStateFilterData = CurrentAddedData.Clone();
                                    }
                                    //添加到所有
                                    allStateFilterData.ImportRow(CurrentAddedData.Rows[r]);
                                }

                               
                            }
                            catch
                            {
                                //
                            }

                            if (r == CurrentAddedData.Rows.Count - 1)
                            {
                                //如果是最后一条记录，记下时间，并更新下次查询的条件
                                this.myStartTime = Convert.ToDateTime(CurrentAddedData.Rows[r]["Time"]);
                            }
                        }
                    }
                    #endregion
                    this.CurrentAddedData.Clear();
                }
                //立即通知另一线程进行表分析！！
                DataTableUpdateNotify.Set();
                //
                Thread.Sleep(5000);
            } while (true); 
        }

        private void MonitorData()
        {
            myMail = new MailServer();
            do
            {
                DataTableUpdateNotify.WaitOne();

                //支持运行时更改
                sendMail = Properties.mySettings.Default.Send;

                #region 遍历每个表进行条件判定
                for (int t = 0; t < FilterDataTablesCollection.Tables.Count; t++)
                {
                    DataTable currentTable = FilterDataTablesCollection.Tables[t];
                    if (currentTable.Rows.Count > maxTimeOutNum_int_funtion)
                    {
                        //如果在时间范围内
                        //new TimeSpan(actions[maxTimeOutNum_int_all - 1].Time.Ticks 
                        //- actions[0].Time.Ticks).Duration().Minutes < timeOutSpan_inMinute_all

                        DateTime latestTime = DateTime.Parse(currentTable.Rows[currentTable.Rows.Count - 1]["Time"].ToString());
                        DateTime oldTime = DateTime.Parse(currentTable.Rows[0]["Time"].ToString());
                        if (new TimeSpan(latestTime.Ticks - oldTime.Ticks).Duration().Minutes < timeOutSpan_inMinute_funtion)
                        {
                            string action = currentTable.Rows[0]["Action"].ToString();
                            string state = currentTable.Rows[0]["State"].ToString();
                            string envior = currentTable.Rows[0]["Envior"].ToString();
                            int timeout = currentTable.Rows.Count;

                            //发送邮件Time        Envior   TimeSpan   Action   State
                            string mailContent = "<div><span> " + maxTimeOutNum_int_funtion.ToString() + action
                                +" actions take more then " + timeOutFilter_inSecond_funtion.ToString()
                                + " seconds within " + timeOutSpan_inMinute_funtion.ToString() + " minutes</span><br/>";
                            mailContent += "<table style=\"border:1px solid blue;background-color:#CCCCCC;\"><tr><th>State</th><th>Action</th><th colspan=\""
                                + (timeout * 2).ToString() + "\">TimeOutInfo</th><th>Enviornment</th></tr>";

                            mailContent += "<tr><td>" + state + "</td><td>" + action + "</td>";

                            for (int i = 0; i < currentTable.Rows.Count; i++)
                            {
                                mailContent += "<td>" + currentTable.Rows[i]["TimeSpan"].ToString() + "</td><td>" + currentTable.Rows[i]["Time"].ToString() + "</td>";
                            }

                            mailContent += "<td>" + envior + "</td></tr></table></div>";

                            //清空！！
                            currentTable.Clear();
                            myMail.sendMail(this.alertMailSubject, mailContent);
                        }
                        else
                        {
                            currentTable.Rows.RemoveAt(0);
                        }
                    }
                }
                #endregion


                #region  对全部内容进行条件判定
                if (allStateFilterData != null && allStateFilterData.Rows.Count > maxTimeOutNum_int_all)
                {
                    //如果在时间范围内
                    DateTime latestTime = DateTime.Parse(allStateFilterData.Rows[allStateFilterData.Rows.Count - 1]["Time"].ToString());
                    DateTime oldTime = DateTime.Parse(allStateFilterData.Rows[0]["Time"].ToString());
                    if (new TimeSpan(latestTime.Ticks - oldTime.Ticks).Duration().Minutes < timeOutSpan_inMinute_all)
                    {
                        //发送邮件Time        Envior   TimeSpan   Action   State
                        string allMailContent = "<div><span> "
                            + maxTimeOutNum_int_all.ToString() + " actions that take more then "
                            + timeOutFilter_inSecond_all.ToString() + " seconds within "
                            + timeOutSpan_inMinute_all.ToString() + " minutes</span><br/>"
                            + "<table style=\"border:1px solid blue;background-color:#CCCCCC;\">"
                            + "<tr><th>State</th><th>Action</th><th>TimeSpan</th><th>Time</th><th>Enviornment</th></tr>";

                        for (int j = 0; j < allStateFilterData.Rows.Count; j++)
                        {
                            allMailContent += "<tr><td>"
                                + allStateFilterData.Rows[j]["State"].ToString() + "</td><td>"
                                + allStateFilterData.Rows[j]["Action"].ToString() + "</td><td>"
                                + allStateFilterData.Rows[j]["TimeSpan"].ToString() + "</td><td>"
                                + allStateFilterData.Rows[j]["Time"].ToString() + "</td><td>"
                                + allStateFilterData.Rows[j]["Envior"].ToString() + "</td></tr>";
                        }

                        allMailContent += "</table></div>";

                        //清空！！
                        allStateFilterData.Clear();
                        myMail.sendMail(this.alertMailSubject, allMailContent);
                    }
                    else
                    {
                        allStateFilterData.Rows.RemoveAt(0);
                    }
                }
                #endregion

                Thread.Sleep(5000);//长时间占据资源
                DataTableUpdateNotify.Set();
            } while (true);
        }

    }
}
