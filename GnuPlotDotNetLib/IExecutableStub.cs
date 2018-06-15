using System;
using System.Collections.Generic;
using System.Text;

namespace GnuplotDotNetLib
{
    /// <summary>
    /// Abstracts the passing of commands to GnuPlot executable.
    /// This helps in unit testing
    /// </summary>
    public interface IExecutableStub
    {
        /// <summary>
        /// Refreshes the Gnuplot display with current state
        /// </summary>
        /// <param name="wrapper"></param>
        void Redraw(Wrapper wrapper);
        /// <summary>
        /// Clears the UI - This mehtod may not be needed
        /// Why? We clear the state of the outer wrapper and just invoke Redraw()
        /// </summary>
        void Clear();
        void Cleanup();
    }
}
