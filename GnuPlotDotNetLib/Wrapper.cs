using System;
using System.Collections.Generic;
using System.Text;

namespace GnuPlotDotNetLib
{
    public class Wrapper
    {
        IExecutableStub _stub;
        public Wrapper()
        {
            this.GnuPlotPath = @"C:\Program Files\gnuplot\bin\gnuplot.exe";
            _stub = new _GnuPlotInnerWrapper(this.GnuPlotPath);
        }
        /// <summary>
        /// Complete path to the GnuPlot executable
        /// </summary>
        public string GnuPlotPath { get; set; }
        public void Redraw()
        {
            //TODO
            _stub.Redraw(this);
        }
        public void Clear()
        {
            _stub.Clear();
        }

        public string XAxisTitle { get; set; }

        public string YAxisTitle { get; set; }
    }
}
