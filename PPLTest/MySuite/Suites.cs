using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using System.Collections;
using System.Threading;
using Selenium;

namespace PPLTest.MySuite
{
    [TestFixture]
    class Suites
    {
        [Suite]
        public static IEnumerable Suite
        {
          
            get
            {
                SuiteProvider mySuite = new SuiteProvider();
                return mySuite.GetConfigSuite();
            }
        }
    }
}