using System;
using System.Collections.Generic;
using System.Text;

namespace GnuplotDotNetLib
{
    public class PhysicalFilePlot : PlotBase
    {
        /// <summary>
        /// Path to the file with data points
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// The file delimiter
        /// </summary>
        public string Separator { get; set; }

        public override string GetPlotFilePath()
        {
            return Path;
        }
    }
}
