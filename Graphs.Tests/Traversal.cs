using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.Tests
{
    [TestClass]
    public class Traversal
    {
        [TestMethod]
        public void DepthFirstTraversalOfSimpleCyclicalGraph()
        {
            var generator = new Generator();
            Graph g = generator.GetSimpleCyclical();
            List<Node> path = g.Traverse(g.Nodes[0], new DepthFirstTraversal());
            Assert.AreEqual("ABECDFGH", path.AsString());
        }

        [TestMethod]
        public void BreadthFirstTraversalOfSimpleTree()
        {
            var generator = new Generator();
            Graph g = generator.GetSimpleBinaryTree();
            List<Node> path = g.Traverse(g.Nodes[0], new BreadthFirstTraversal());
            Assert.AreEqual("ABECDFGH", path.AsString());
        }

        [TestMethod]
        public void DepthFirstTraversalOfSimpleTree()
        {
            var generator = new Generator();
            Graph g = generator.GetSimpleBinaryTree();
            List<Node> path = g.Traverse(g.Nodes[0], new DepthFirstTraversal());
            Assert.AreEqual("ABCDEFGH", path.AsString());
        }
    }
}