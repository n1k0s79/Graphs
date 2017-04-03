using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

        public bool Search(Node start, Node target, ISearchAlgorithm algorithm, out List<Node> path)
        {
            return algorithm.Search(start, target, out path);
        }

        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary> Returns a random node </summary>
        public Node GetRandomNode()
        {
            int index = rnd.Next(this.Nodes.Count);
            return this.Nodes[index];
        }

        public Node GetNode(string name)
        {
            return this.Nodes.FirstOrDefault(n => n.Name == name);
        }

        /// <summary> Gets the node with name nodeName. If such a node does not exist then it creates it, adds it to the graph and then returns it. </summary>
        public Node GetAddNode(string nodeName)
        {
            var ret = this.GetNode(nodeName);
            if (ret != null) return ret;
            ret = new Node(nodeName);
            this.Nodes.Add(ret);
            return ret;
        }
    }
}