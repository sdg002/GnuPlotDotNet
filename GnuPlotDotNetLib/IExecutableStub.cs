using System;
using System.Collections.Generic;
using System.Text;

namespace GnuPlotDotNetLib
{
    /// <summary>
    /// Abstracts the passing of commands to GnuPlot executable.
    /// This helps in unit testing
    /// </summary>
    public interface IExecutableStub
    {
        void Redraw(Wrapper wrapper);
        void Clear();
    }
}
