using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace KillAllWordProcess
{
    class Program
    {
        static void Main(string[] args)
        {
            Process[] ps = Process.GetProcesses();
            foreach (Process var in ps)
            {
                if (var.ProcessName.ToLower().Contains("winword"))
                {
                    var.Kill();
                }
            }
        }
    }
}
