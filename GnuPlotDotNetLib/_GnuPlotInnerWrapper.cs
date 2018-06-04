using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.Linq;
using System.IO;

namespace GnuplotDotNetLib
{
    public class _GnuPlotInnerWrapper : IExecutableStub
    {
        private string gnuPlotPath;
        Process _procGnuPlot;
        StreamWriter _GnupStdinStreamWriter;
        StreamReader _GnupStdinStreamReader;
        /*
         * We could try the following
         * redirect stdout
         * use the set print "-" command to write all output back to stdout
         * output of "print 1/2" will be written back to stdout
         * When mousing is active, clicking in the active window will set several mouse variables
         * See mousing and mouse variables
         */ 

            /*
             * Think about
             * xrange
             * yrange
             * setting origin
             * 
             * set xtics axis|border
             */
        public _GnuPlotInnerWrapper(string gnuPlotPath)
        {
            this.gnuPlotPath = gnuPlotPath;
        }

        public void Clear()
        {
            _LaunchGnuIfNotRunning();
            WriteLine("clear");
        }

        public void Redraw(Wrapper wrapper)
        {
            _LaunchGnuIfNotRunning();
            WriteLine("reset");
            WriteLine("clear");
            WriteLine($"set xlabel '{wrapper.XAxisLabel}'");
            WriteLine($"set ylabel '{wrapper.YAxisLabel}'");
            WriteLine($"set title '{wrapper.ChartTitle}'");
            if (wrapper.IsGridVisible)
            {
                WriteLine($"set grid");
            }
            else
            {
                WriteLine($"unset grid");
            }
            WriteLine("plot sin(x)");
            //you were ehre//thsi works, you will need to take this forward
        }

        private void _LaunchGnuIfNotRunning()
        {
            bool shouldLaunchNewInstanceOfGnuPlot = false;
            if (_procGnuPlot == null)
            {
                shouldLaunchNewInstanceOfGnuPlot = true;
            }
            else
            {
                Process[] processlist = Process.GetProcesses();
                shouldLaunchNewInstanceOfGnuPlot = !processlist.Any(proc => proc.Id == _procGnuPlot.Id);
            }
            if (shouldLaunchNewInstanceOfGnuPlot==false) return;//Process already exists
            _procGnuPlot = new Process();
            _procGnuPlot.StartInfo.FileName = gnuPlotPath;
            _procGnuPlot.StartInfo.UseShellExecute = false;
            _procGnuPlot.StartInfo.RedirectStandardInput = true;
            _procGnuPlot.Start();
            _GnupStdinStreamWriter = _procGnuPlot.StandardInput;
        }
        public void WriteLine(string gnuplotcommands)
        {

            _GnupStdinStreamWriter.WriteLine(gnuplotcommands);
            _GnupStdinStreamWriter.Flush();
        }
        public void Write(string gnuplotcommands)
        {
            _GnupStdinStreamWriter.Write(gnuplotcommands);
            _GnupStdinStreamWriter.Flush();
        }

    }
}
