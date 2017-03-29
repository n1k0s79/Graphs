using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.Tests
{
    [TestClass]
    public class Generation
    {
        [TestMethod]
        public void Generate()
        {
            Stopwatch sw = Stopwatch.StartNew();
            sw.Start();
            var generator = new Generator();
            var graph = generator.GetSimpleAcyclical();
            double elapsed = sw.Elapsed.TotalMilliseconds;
            string s = elapsed.ToString();
        }
    }
}
