using System;
using System.Threading;
using GnuplotDotNetLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProjectFwk
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void NoSteps()
        {
            Action<GnuplotDotNetLib.Wrapper> fnCustomCode = delegate (GnuplotDotNetLib.Wrapper gnu)
            {
                gnu.Redraw();
            };
            string[] allStdout=ExecuteCustomStepsAndCaptureStdout(fnCustomCode);
            Assert.AreEqual<string>(allStdout[0], "reset");
        }
        [TestMethod]
        public void XLabel()
        {
            string axis = Guid.NewGuid().ToString();
            Action<GnuplotDotNetLib.Wrapper> fnCustomCode = delegate (GnuplotDotNetLib.Wrapper gnu)
            {
                gnu.XAxisLabel = axis;
                gnu.Redraw();
            };
            string[] allStdout = ExecuteCustomStepsAndCaptureStdout(fnCustomCode);
            Assert.AreEqual<string>(allStdout[0], "reset");
            Assert.AreEqual<string>(allStdout[1], $"set xlabel '{axis}'");
        }
        [TestMethod]
        public void YLabel()
        {
            string axis = Guid.NewGuid().ToString();
            Action<GnuplotDotNetLib.Wrapper> fnCustomCode = delegate (GnuplotDotNetLib.Wrapper gnu)
            {
                gnu.YAxisLabel = axis;
                gnu.Redraw();
            };
            string[] allStdout = ExecuteCustomStepsAndCaptureStdout(fnCustomCode);
            Assert.AreEqual<string>(allStdout[0], "reset");
            Assert.AreEqual<string>(allStdout[1], $"set ylabel '{axis}'");
        }
        [TestMethod]
        public void ChartTitle()
        {
            string charttitle = Guid.NewGuid().ToString();
            Action<GnuplotDotNetLib.Wrapper> fnCustomCode = delegate (GnuplotDotNetLib.Wrapper gnu)
            {
                gnu.ChartTitle = charttitle;
                gnu.Redraw();
            };
            string[] allStdout = ExecuteCustomStepsAndCaptureStdout(fnCustomCode);
            Assert.AreEqual<string>(allStdout[0], "reset");
            Assert.AreEqual<string>(allStdout[1], $"set title '{charttitle}'");
        }
        [TestMethod]
        public void ShowGrid()
        {
            string charttitle = Guid.NewGuid().ToString();
            Action<GnuplotDotNetLib.Wrapper> fnCustomCode = delegate (GnuplotDotNetLib.Wrapper gnu)
            {
                gnu.IsGridVisible = true;
                gnu.Redraw();
            };
            string[] allStdout = ExecuteCustomStepsAndCaptureStdout(fnCustomCode);
            Assert.AreEqual<string>(allStdout[0], "reset");
            Assert.AreEqual<string>(allStdout[1], $"set grid");
        }

        private string[] ExecuteCustomStepsAndCaptureStdout(Action<Wrapper> fnCustomCode)
        {
            string folder = this.TestContext.DeploymentDirectory;
            string pathOutput = System.IO.Path.Combine(folder, "Out.txt");
            if (System.IO.File.Exists(pathOutput))
            {
                System.IO.File.Delete(pathOutput);
            }
            Environment.SetEnvironmentVariable("unittestfolder", folder);
            string currentassembly = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string currentassemblyfolder = System.IO.Path.GetDirectoryName(currentassembly);
            string stubexe = System.IO.Path.Combine(currentassemblyfolder, "StubGnuEXE.exe");
            using (var gnu = new GnuplotDotNetLib.Wrapper(stubexe))
            {
                fnCustomCode(gnu);
                Thread.Sleep(500);//Let the child process start off.
            }
            string[] allLines = System.IO.File.ReadAllLines(pathOutput);
            return allLines;
        }
    }
}
