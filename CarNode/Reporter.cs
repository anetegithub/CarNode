using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarNode
{
    public static class Reporter
    {
        public static void Report(string Msg)
        {
            Console.WriteLine(Msg);
            Console.ReadLine();
            Environment.Exit(0);
        }
    }
}