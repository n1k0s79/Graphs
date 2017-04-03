using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Graphs.Tests
{
    [TestClass]
    public class Search
    {
         [TestMethod]
         public void DepthFirstSearchInSimpleTree()
         {
             var generator = new Generator();
             Graph g = generator.GetSimpleTree();
             List<Node> path;
             
             Assert.IsTrue(g.Search(g.GetNode("A"), g.GetNode("O"), new DepthFirstSearch(), out path));
             Assert.AreEqual("ABCIJKDELFGHMNO", path.AsString());

             Assert.IsTrue (g.Search(g.GetNode("N"), g.GetNode("O"), new DepthFirstSearch(), out path));
             Assert.AreEqual("NHFABCIJKDELGMO", path.AsString());

             Assert.IsTrue(g.Search(g.GetNode("L"), g.GetNode("O"), new DepthFirstSearch(), out path));
             Assert.AreEqual("LEBAFHMNO", path.AsString());

             //             A  
             //         /       \ 
             //        B         F
             //      / | \      / \
             //     C  D   E   G   H
             //   / | \    |     / | \
             //  I  J  K   L    M  N  O
         }

         [TestMethod]
         public void DepthFirstSearchInSimpleAcyclical()
         {
             var generator = new Generator();
             Graph g = generator.GetSimpleAcyclical();
             List<Node> path;
             bool found = g.Search(g.Nodes[0], g.Nodes[g.Nodes.Count - 1], new DepthFirstSearch(), out path);
             Assert.IsTrue(found);
             Assert.AreEqual("ABCIJKDELFGHMN", path.AsString());
             //          A   F
             //         / \ /
             //        B   C---G
             //       /\    
             //      D  E    
         }
    }
}