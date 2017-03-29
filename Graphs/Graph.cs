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