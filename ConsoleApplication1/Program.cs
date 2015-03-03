using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
            Console.WriteLine(DateTime.Now.ToString("yyyy/mm/dd HH:mm:ss"));
            Console.ReadLine();
        }
    }
}
