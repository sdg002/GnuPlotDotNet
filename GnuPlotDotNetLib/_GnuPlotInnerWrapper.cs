using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.IO;

namespace GnuPlotDotNetLib
{
    public class _GnuPlotInnerWrapper : IExecutableStub
    {
        private string gnuPlotPath;
        Process ExtPro;
        StreamWriter GnupStWr;
        public _GnuPlotInnerWrapper(string gnuPlotPath)
        {
            this.gnuPlotPath = gnuPlotPath;
        }

        public void Clear()
        {
            //throw new NotImplementedException();
        }

        public void Redraw(Wrapper wrapper)
        {
            _LaunchGnuIfNotRunning();
            WriteLine("reset");
            WriteLine("clear");
            //you were ehre//thsi works, you will need to take this forward
        }

        private void _LaunchGnuIfNotRunning()
        {
            bool launchNewProc = false;
            if (ExtPro == null)
            {
                launchNewProc = true;
            }
            else
            {
                Process[] processlist = Process.GetProcesses();
                launchNewProc = processlist.Any(proc => proc.Id == ExtPro.Id);
            }
            if (launchNewProc==false) return;
            ExtPro = new Process();
            ExtPro.StartInfo.FileName = gnuPlotPath;
            ExtPro.StartInfo.UseShellExecute = false;
            ExtPro.StartInfo.RedirectStandardInput = true;
            ExtPro.Start();
            GnupStWr = ExtPro.StandardInput;
        }
        public void WriteLine(string gnuplotcommands)
        {

            GnupStWr.WriteLine(gnuplotcommands);
            GnupStWr.Flush();
        }
        public void Write(string gnuplotcommands)
        {
            GnupStWr.Write(gnuplotcommands);
            GnupStWr.Flush();
        }

    }
}
