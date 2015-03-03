using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Xml;

namespace PPLTestMonitor.ClassLib
{
    public class TestRunner:IDisposable
    {
        private CmdExecuter myCMD;
        private Mutex writeMutex;
        private Thread runNewState = null;

        private string loadURL;
        public string LoadURL
        {
            get { return loadURL; }
            set { loadURL = value; }
        }

        private List<string> testStates;
        public List<string> TestStates
        {
            get { return testStates; }
            set { testStates = value; }
        }

        private string scriptFilePath;
        public string ScriptFilePath
        {
            get { return scriptFilePath; }
            set { scriptFilePath = value; }
        }

        private int stateStartTimespan;
        private int singleRunTime;
        private string runningCommand;

        public TestRunner()
        {
            
        }
        ~TestRunner()
        {

        }

        public void Dispose()
        {
            if (runNewState != null)
            {
                runNewState.Abort();
            }
            GC.SuppressFinalize(this);
        }



        public void BeginTest()
        {
            this.stateStartTimespan = Properties.mySettings.Default.StatesStartTimeSpan;
            this.singleRunTime = Properties.mySettings.Default.SingleStateRunTime;
            this.myCMD = new CmdExecuter();

            this.runningCommand = "nunit-console /fixture:PPLTest.MySuite.Suites " + this.scriptFilePath + "\\PPLTest.dll"
                + " /xml:" + this.scriptFilePath + "\\TestResult.xml";


            if (PrepareTest(this.scriptFilePath, this.testStates.Count))
            {
                int i=0;
                foreach (string state in testStates)
                {
                    //
                    i++;
                    runNewState = new Thread(new ParameterizedThreadStart(newStateTest));
                    myParameterStruct myParameters = new myParameterStruct();
                    myParameters.state = state;
                    myParameters.port = 4444 + i;
                    runNewState.Start(myParameters);

                    //set the timespan
                    Thread.Sleep(stateStartTimespan * 1000);
                }
            }
        }

        /// <summary>
        ///     
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="portNum"></param>
        /// <returns></returns>
        private bool PrepareTest(string filePath, int portNum)
        {
            /*实现如下代码：
     * start .\PPLTest\Start_Grid.bat
     * 
     * cd .\PPLTest\SeleniumGrid
     * ant launch-hub*/

            /*start .\PPLTest\Start_RemoteControl.bat 4445
             * 
             * cd C:\PPL\SeleniumGrid
             * ant -Dport=4445 launch-remote-control*/
            try
            {
                string setSeleniumGrid = "cd " + filePath + "\\SeleniumGrid";
                myCMD.ExecuteCMD(new string[] {
                    setSeleniumGrid,
                    "ant launch-hub"
                });
                Thread.Sleep(500);
                for (int i = 1; i <= portNum; i++)
                {
                    string lanchPort = "ant -Dport=" + (4444 + i).ToString() + " launch-remote-control";
                    myCMD.ExecuteCMD(new string[] {
                        setSeleniumGrid,
                        lanchPort
                    });//
                }
                Thread.Sleep(500);
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        private void newStateTest(object obj)
        {
            myParameterStruct myParameters = (myParameterStruct)obj;
            string currentState = myParameters.state;
            int currentPort = myParameters.port;
            this.writeMutex = new Mutex();
            do
            {
                try
                {
                    writeMutex.WaitOne();
                    //锁定设定config.xml
                    string configXML = this.scriptFilePath + "\\Config.xml";
                    /*ping -n 15 127.1>nul
                     * start .\PPLTest\Set_Config.bat config_ME.xlsx config_OK.xlsx 4445 4446*/
                    XmlDocument xmld = new XmlDocument();
                    xmld.Load(configXML);
                    xmld.SelectSingleNode("Settings/Config").InnerText = "\\Config_" + currentState + ".xlsx";
                    xmld.SelectSingleNode("Settings/RC_Port").InnerText = currentPort.ToString();
                    xmld.Save(configXML);
                    /*nunit-console /fixture:PPLTest.MySuite.Suites .\PPLTest\PPLTest\PPLTest.dll /xml:.\TestResult.xml  
                     * exit*/
                    myCMD.ExecuteCMD(new string[] { runningCommand, "exit" });

                }
                catch
                {
 
                }
                writeMutex.ReleaseMutex();
                Thread.Sleep(this.singleRunTime * 60000);
            } while (true);
        }

        public void EndTest()
        {
            if (runNewState != null && runNewState.IsAlive)
            {
                runNewState.Abort();
            }
            myCMD.CloseProcess("cmd");
            myCMD.CloseProcess("java");
        }

    }

    /// <summary>
    /// 更改Config的参数结构体
    /// </summary>
    public struct myParameterStruct
    {
        public string state;
        public int port;
    }
}
