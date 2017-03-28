using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Graphs
{
    [DebuggerDisplay("A graph with {Nodes.Count} nodes")]
    public class Graph
    {
        // a graph is nothing more than a collection of nodes
        public readonly List<Node> Nodes;
        
        public Graph()
        {
            this.Nodes = new List<Node>();
        }

        #region Search algorithms

        public List<Node> DFS(Node n)
        {

        }

        #endregion

        #region "Generation"

        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary> Generates a graph  </summary>
        /// <param name="numberOfNodes"> The number of nodes</param>
        /// <param name="density"> The percent of other nodes a node is connected to </param>
        public static Graph Generate(int numberOfNodes = 50, int density = 20)
        {
            var ret = new Graph();
            AddNodes(ret, numberOfNodes);
            ConnectNodes(ret, density);        
            return ret;
        }

        /// <summary> Adds nodes to the graph </summary>
        private static void AddNodes(Graph g, int numberOfNodes)
        {
            for (var i = 0; i < numberOfNodes; i++)
            {
                var n = new Node(i.ToString());
                g.Nodes.Add(n);
            }
        }

        /// <summary> Randomly connects the nodes in the graph to </summary>
        private static void ConnectNodes(Graph g, int density = 20)
        {
            int connections = g.Nodes.Count * density / 100;

            foreach (var node in g.Nodes) AddRandomConnections(g, node, connections);
        }

        private static void AddRandomConnections(Graph g, Node n, int numberOfConnections)
        {
            while (n.ConnectedNodes.Count < numberOfConnections)
            {
                Node r = g.GetRandomNode();
                if (r.Equals(n) || r.ConnectedNodes.Count >= 10) continue;
                int weight = rnd.Next(0, 10);
                n.ConnectTo(r, weight);
            }
        }

        /// <summary> Returns a random node </summary>
        private Node GetRandomNode()
        {
            int index = rnd.Next(this.Nodes.Count);
            return this.Nodes[index];
        }

        #endregion
    }
}