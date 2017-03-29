using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Graphs
{
    [DebuggerDisplay("A graph with {Nodes.Count} nodes and {Edges.Count} edges")]
    public class Graph
    {
        // a graph is nothing more than a collection of nodes
        public readonly List<Node> Nodes;
        public readonly List<Edge> Edges;
        
        public Graph()
        {
            this.Nodes = new List<Node>();
            this.Edges = new List<Edge>();
        }

        public List<Node> Traverse(Node root, ITraversalAlgorithm algorithm)
        {
            return algorithm.Traverse(root);
        }

        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary> Returns a random node </summary>
        public Node GetRandomNode()
        {
            int index = rnd.Next(this.Nodes.Count);
            return this.Nodes[index];
        }
    }
}