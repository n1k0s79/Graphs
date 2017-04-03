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
        public Graph Generate(int numberOfNodes = 50, int connectionsPerNode = 5)
        {
            graph = new Graph();
            AddNodes(numberOfNodes);
            ConnectNodes(connectionsPerNode);
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

        /// <summary> Randomly connects the nodes in the graph to other nodes</summary>
        private void ConnectNodes(int connectionsPerNode)
        {
            foreach (var node in graph.Nodes) graph.Edges.AddRange(AddRandomConnections(node, connectionsPerNode));
        }

        private List<Edge> AddRandomConnections(Node n, int numberOfConnections)
        {
            var ret = new List<Edge>();
            while (n.ConnectedNodes.Count < numberOfConnections)
            {
                var uncongestedNodes = graph.Nodes.Where(node => node.ConnectedNodes.Count < numberOfConnections && !node.Equals(n)).ToList();
                var index = rnd.Next(uncongestedNodes.Count);
                var other = uncongestedNodes[index];
                int weight = rnd.Next(0, 10);
                while (other.IsConnectedTo(n))
                {
                    index = rnd.Next(uncongestedNodes.Count);
                    other = graph.Nodes[index];
                }

                var edge = new Edge(n, other, true, weight);
                n.AdjacentEdges.Add(edge);
                other.AdjacentEdges.Add(edge);
                ret.Add(edge);
            }

            return ret;
        }

        private List<Edge> GetAllPossibleEdges(Graph g)
        {
            
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

            Connect(A, B, E);
            Connect(B, C, D);
            Connect(E, F, G);
            Connect(G, H);

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

            this.graph = new Graph();

            Connect(A, B, F);
            Connect(B, C, D, E);

            Connect(F, G, H);
            Connect(C, I, J, K);

            Connect(E, L);
            Connect(H, M, N, O);

            return graph;
        }

        public Graph GetSimpleCyclical()
        {
            //          A   F
            //         / \ /
            //        B---C---G
            //       /\    
            //      D--E    

            this.graph = new Graph();
 
            Connect(A, B, C);
            Connect(B, A, C, E, D);
            Connect(C, F, G);
 
            return graph;
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

        private Node A
        {
            get { return graph.GetAddNode("A"); }
        }

        private Node B
        {
            get { return graph.GetAddNode("B"); }
        }

        private Node C
        {
            get { return graph.GetAddNode("C"); }
        }

        private Node D
        {
            get { return graph.GetAddNode("D"); }
        }

        private Node E
        {
            get { return graph.GetAddNode("E"); }
        }

        private Node F
        {
            get { return graph.GetAddNode("F"); }
        }

        private Node G
        {
            get { return graph.GetAddNode("G"); }
        }

        private Node H
        {
            get { return graph.GetAddNode("H"); }
        }

        private Node I
        {
            get { return graph.GetAddNode("I"); }
        }

        private Node J
        {
            get { return graph.GetAddNode("J"); }
        }

        private Node K
        {
            get { return graph.GetAddNode("K"); }
        }

        private Node L
        {
            get { return graph.GetAddNode("L"); }
        }

        private Node M
        {
            get { return graph.GetAddNode("M"); }
        }

        private Node N
        {
            get { return graph.GetAddNode("N"); }
        }

        private Node O
        {
            get { return graph.GetAddNode("O"); }
        }

        private Node P
        {
            get { return graph.GetAddNode("P"); }
        }

        private Node Q
        {
            get { return graph.GetAddNode("Q"); }
        }

        #endregion
    }
}