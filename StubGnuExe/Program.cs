using GnuplotDotNetLib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StubGnuExe
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Trace.WriteLine("StubGnuExe.Main");
                var proc = Process.GetCurrentProcess();
                proc.OutputDataReceived += Proc_OutputDataReceived;
                //_DumpAllEnvironment();
                while (true)
                {
                    Trace.WriteLine("Waiting for Console.Readline");
                    string input = Console.ReadLine();
                    Console.WriteLine(input);
                    Thread.Sleep(100);
                    Trace.WriteLine($"STDIN={input}");
                    AppendToOutputFile(input);
                    if (string.IsNullOrWhiteSpace(input)) break;
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLine(ex.ToString());
            }
        }

        private static void AppendToOutputFile(string line)
        {
            Trace.WriteLine($"AppendToOutputFile, line='{line}'");
            string folderDeployment = GetDeploymentFolderFromEnv();
            string outputfile = System.IO.Path.Combine(folderDeployment, "out.txt");
            System.IO.File.AppendAllLines(outputfile, new string[] { line });
        }

        private static void Proc_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            Trace.WriteLine($"Proc_OutputDataReceived , data={e.Data}");
        }

        private static void _DumpAllEnvironment()
        {
            string folderDeployment = GetDeploymentFolderFromEnv();
            string outputfile = System.IO.Path.Combine(folderDeployment, "out.txt");
            var allvariables=System.Environment.GetEnvironmentVariables();
            List<string> results = new List<string>();
            foreach(string variable in allvariables.Keys)
            {
                string value = System.Environment.GetEnvironmentVariable(variable);
                Trace.WriteLine($"Name={variable}    Value={value}");
                results.Add(value);
            }
            System.IO.File.WriteAllLines(outputfile, results.ToArray());
        }

        private static string GetDeploymentFolderFromEnv()
        {
            string folder = Environment.GetEnvironmentVariable(Constants.VARIABLE_DEPLOYMENTFOLDER);
            if (string.IsNullOrWhiteSpace(folder)) throw new Exception("The deployment folder has not bee specified");
            return folder;
        }
    }
}
