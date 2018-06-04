using System;
using System.Collections.Generic;
using System.Text;

namespace GnuplotDotNetLib
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
        /// <summary>
        /// Empties the current state of the chart.
        /// All properties are nullified.
        /// </summary>
        public void Clear()
        {
            this.XAxisLabel = "";
            this.YAxisLabel = "";
            this.ChartTitle = "";
            this.IsGridVisible = false;
            _stub.Redraw(this);
        }
        /// <summary>
        /// Sets the label of the X axis
        /// </summary>
        public string XAxisLabel { get; set; }
        /// <summary>
        /// Sets the label of the Y axis
        /// </summary>
        public string YAxisLabel { get; set; }
        /// <summary>
        /// Sets the title of the chart
        /// </summary>
        public string ChartTitle { get; set; }
        /// <summary>
        /// When set to True , a grid is displayed
        /// </summary>
        public bool IsGridVisible { get; set; }
    }
}
