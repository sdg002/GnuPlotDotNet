using System;
using System.Collections.Generic;
using System.Text;

namespace GnuplotDotNetLib
{
    public class Wrapper : IDisposable
    {
        IExecutableStub _stub;
        public Wrapper()
        {
            this.GnuPlotPath = @"C:\Program Files\gnuplot\bin\gnuplot.exe";
            _stub = new _GnuPlotInnerWrapper(this.GnuPlotPath);
        }
        public Wrapper(IExecutableStub stub)
        {
            _stub = stub;
        }
        /// <summary>
        /// Use this ctor for passing a stub executable
        /// </summary>
        /// <param name="exepath"></param>
        public Wrapper(string exepath)
        {
            this.GnuPlotPath = exepath;
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

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                    _stub.Cleanup();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
        // ~Wrapper() {
        //   // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
        //   Dispose(false);
        // }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            // Do not change this code. Put cleanup code in Dispose(bool disposing) above.
            Dispose(true);
            // TODO: uncomment the following line if the finalizer is overridden above.
            // GC.SuppressFinalize(this);
        }
        #endregion
    }
}
