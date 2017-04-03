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

        //[TestMethod]
        //public void Serialize()
        //{
        //    var generator = new Generator();
        //    var graph = generator.Generate(100, 0.8f);
        //    var serializer = new Serializer();
        //    var s = serializer.Serialize(graph);
        //}

        [TestMethod]
        public void MaxPossibleNodes()
        {
            var graph = new Graph(10);
            Assert.AreEqual(45, graph.MaxPossibleEdges);

            graph = new Graph(5);
            Assert.AreEqual(10, graph.MaxPossibleEdges);

            graph = new Graph(100);
            Assert.AreEqual(4950, graph.MaxPossibleEdges);
        }
    }
}
