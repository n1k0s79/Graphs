using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.Tests
{
    [TestClass]
    public class Traversal
    {
        [TestMethod]
        public void DepthFirstSearch()
        {
            var generator = new Graphs.Generator();
            Graph g = generator.GetSimple();
            g.Traverse(g.Nodes[0], new Graphs.DepthFirstTraversal(g));
        }
    }
}