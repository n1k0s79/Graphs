using System;
using System.Collections.Generic;
using System.Linq;

namespace Graphs
{
    public class Generator
    {
        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        public Graph graph { get; private set; }

        /// <summary> Generates a graph  </summary>
        /// <param name="numberOfNodes"> The number of nodes</param>
        /// <param name="density"> The percent of other nodes a node is connected to </param>
        public Graph Generate(int numberOfNodes = 50, int density = 20)
        {
            graph = new Graph();
            AddNodes(numberOfNodes);
            ConnectNodes(density);
            return graph;
        }

        /// <summary> Adds nodes to the graph </summary>
        private void AddNodes(int numberOfNodes)
        {
            for (var i = 0; i < numberOfNodes; i++)
            {
                var n = new Node(i.ToString());
                graph.Nodes.Add(n);
            }
        }

        /// <summary> Randomly connects the nodes in the graph to </summary>
        private void ConnectNodes(int density = 20)
        {
            int connections = graph.Nodes.Count * density / 100;

            foreach (var node in graph.Nodes) AddRandomConnections(node, connections);
        }

        private void AddRandomConnections(Node n, int numberOfConnections)
        {
            while (n.ConnectedNodes.Count < numberOfConnections)
            {
                Node r = graph.GetRandomNode();
                if (r.Equals(n)) continue;
                int weight = rnd.Next(0, 10);
                n.ConnectTo(r, weight);
            }
        }

        private void Connect(Node a, params Node[] other)
        {
            foreach (var o in other) graph.Edges.Add(a.ConnectTo(o));
        }

        #region Simple graphs

        public Graph GetSimpleBinaryTree()
        {
            //           A  
            //         /   \ 
            //        B     E
            //       /\    / \
            //      C  D  F   G
            //                 \
            //                  H

            var ret = new Graph();
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");
            var f = new Node("F");
            var g = new Node("G");
            var h = new Node("H");

            Connect(a, b, e);
            Connect(b, c, d);
            Connect(e, f, g);
            Connect(g, h);

            ret.Nodes.AddRange(new [] { a, b, c, d, e, f, g, h });

            return ret;
        }

        public Graph GetSimpleTree()
        {
            //             A  
            //         /       \ 
            //        B         F
            //      / | \      / \
            //     C  D   E   G   H
            //   / | \    |     / | \
            //  I  J  K   L    M  N  O

            var ret = new Graph();
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");
            var f = new Node("F");
            var g = new Node("G");
            var h = new Node("H");
            var i = new Node("I");
            var j = new Node("J");
            var k = new Node("K");
            var l = new Node("L");
            var m = new Node("M");
            var n = new Node("N");
            var o = new Node("O");

            Connect(a, b, f);
            Connect(b, c, d, e);

            Connect(f, g, h);
            Connect(c, i, j, k);

            Connect(e, l);
            Connect(h, m, n, o);

            ret.Nodes.AddRange(new [] { a, b, c, d, e, f, g, h, i, j, k, l, m, n, o });

            return ret;
        }

        public Graph GetSimpleCyclical()
        {
            //          A   F
            //         / \ /
            //        B---C---G
            //       /\    
            //      D--E    

            var ret = new Graph();
            var a = new Node("A");
            var b = new Node("B");
            var c = new Node("C");
            var d = new Node("D");
            var e = new Node("E");
            var f = new Node("F");
            var g = new Node("G");

            Connect(a, b, c);
            Connect(b, a, c, e, d);
            Connect(c, f, g);
 
            ret.Nodes.AddRange(new [] { a, b, c, d, e, f, g });

            return ret;
        }

        public Graph GetSimpleAcyclical()
        {
            //          A   F
            //         / \ /
            //        B   C---G
            //       /\    
            //      D  E    

            graph = new Graph();

            Connect(A, B, C);
            Connect(B, D, E);
            Connect(C, F, G);

            return graph;
        }

        private Node GetAddNode(string nodeName)
        {
            var ret = graph.Nodes.FirstOrDefault(x => x.Name == nodeName);
            if (ret == null)
            {
                ret = new Node(nodeName);
                graph.Nodes.Add(ret);
            }

            return ret;
        }

        private Node A
        {
            get { return GetAddNode("A"); }
        }

        private Node B
        {
            get { return GetAddNode("B"); }
        }

        private Node C
        {
            get { return GetAddNode("C"); }
        }

        private Node D
        {
            get { return GetAddNode("D"); }
        }

        private Node E
        {
            get { return GetAddNode("E"); }
        }

        private Node F
        {
            get { return GetAddNode("F"); }
        }

        private Node G
        {
            get { return GetAddNode("G"); }
        }

        private Node H
        {
            get { return GetAddNode("H"); }
        }

        private Node I
        {
            get { return GetAddNode("I"); }
        }

        private Node J
        {
            get { return GetAddNode("J"); }
        }

        private Node K
        {
            get { return GetAddNode("K"); }
        }

        private Node L
        {
            get { return GetAddNode("L"); }
        }

        private Node M
        {
            get { return GetAddNode("M"); }
        }

        private Node N
        {
            get { return GetAddNode("N"); }
        }

        private Node O
        {
            get { return GetAddNode("O"); }
        }

        private Node P
        {
            get { return GetAddNode("Q"); }
        }

        #endregion
    }
}