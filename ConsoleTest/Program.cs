using ConsoleTest.classes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string authKey = CommonUtil.makeAuthKey();
            //Console.ReadLine();

            OpenWithStartInfo();
        }
        static void OpenWithStartInfo()
        {
            string appPath = @"C:\Users\summy\source\repos\EFMON\EFORMWIN\bin\Debug\";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName= appPath + "EFORMWIN.exe",
                Arguments = "eformwin://JSESSIONID/76D2AE2844254512C0CC3ADCE6081BDA.node21",
                UseShellExecute = false
            };
            startInfo.RedirectStandardInput = true;
            Process.Start(startInfo);

           /*
            Process process;
            process = new Process();
            process.StartInfo.FileName = appPath + "EFORMWIN.exe";
            process.StartInfo.Arguments = "eformwin://JSESSIONID/50DAB784B5C5F3BB27CD9EB126ACB94F.node11";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.CreateNoWindow = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.OutputDataReceived += new
            DataReceivedEventHandler(OutputHandler);
            process.StartInfo.RedirectStandardInput = true;
            process.Start();
            process.BeginOutputReadLine();
            process.WaitForExit();
            process.Close();
           */

        }

        private static void OutputHandler(object sendingProcess,
DataReceivedEventArgs outLine)
        {
            string line;
            line = (outLine.Data.ToString());
            Console.WriteLine(line);
        }
    }
}
