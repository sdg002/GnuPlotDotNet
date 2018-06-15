using System;
using System.Collections.Generic;
using System.Text;

namespace GnuplotDotNetLib
{
    abstract public class PlotBase
    {
        /// <summary>
        /// The implementor should return the path to the file which contains the points
        /// </summary>
        /// <returns></returns>
        public abstract string GetPlotFilePath();
    }
}
