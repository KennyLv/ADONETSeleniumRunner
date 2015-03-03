using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PPLTestMonitor.Entity
{
    public class ActionObj
    {
        //州、操作名、花费时间、发生时间、测试环境
        //<Action state="WE" timeSpan="35" time="2011/3/10 9:34:03">Edit IP	</Action>
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }

        private string action;
        public string Action
        {
            get { return action; }
            set { action = value; }
        }

        private string timeSpan;
        public string TimeSpan
        {
            get { return timeSpan; }
            set { timeSpan = value; }
        }

        private DateTime time;
        public DateTime Time
        {
            get { return time; }
            set { time = value; }
        }

        public ActionObj()
        {

        }
    }
}
