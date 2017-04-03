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
            Graph g = generator.GetSimpleTree();
            List<Node> path = g.Traverse(g.Nodes[0], new BreadthFirstTraversal());
            Assert.AreEqual("ABFCDEGHIJKLMNO", path.AsString());
        }

        [TestMethod]
        public void DepthFirstTraversalOfSimpleTree()
        {
            var generator = new Generator();
            Graph g = generator.GetSimpleTree();
            List<Node> path = g.Traverse(g.Nodes[0], new DepthFirstTraversal());
            Assert.AreEqual("ABCIJKDELFGHMNO", path.AsString());
        }

        [TestMethod]
        public void DepthFirstTraversalOfSimpleBinaryTree()
        {
            var generator = new Generator();
            Graph g = generator.GetSimpleBinaryTree();
            List<Node> path = g.Traverse(g.Nodes[0], new DepthFirstTraversal());
            Assert.AreEqual("ABCDEFGH", path.AsString());
        }

        [TestMethod]
        public void BreadthFirstTraversalOfSimpleBinaryTree()
        {
            var generator = new Generator();
            Graph g = generator.GetSimpleBinaryTree();
            List<Node> path = g.Traverse(g.Nodes[0], new BreadthFirstTraversal());
            Assert.AreEqual("ABECDFGH", path.AsString());
        }

        [TestMethod]
        public void TraversalLarge()
        {
            var generator = new Generator();
            for (int i = 0; i < 100; i++)
            {
                Graph g = generator.Generate(100, 0.8f);
                Node a = g.GetRandomNode();
                List<Node> path = g.Traverse(a, new BreadthFirstTraversal());
                Assert.AreEqual(100, path.Count);
            }
        }
    }
}