using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GnuplotDotNetLib;

namespace UnitTestProjectFwk.util
{
    /// <summary>
    /// This is a stub implementation used for unit testing the outer GnuPlot wrapper class
    /// </summary>
    public class StubExecutable : GnuplotDotNetLib.IExecutableStub
    {
        public void Cleanup()
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public void Redraw(Wrapper wrapper)
        {
            throw new NotImplementedException();
        }
    }
}
