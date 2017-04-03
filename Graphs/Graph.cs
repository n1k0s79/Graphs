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

        public Graph(int nrOfNodes)
        {
            this.Nodes = new List<Node>();
            this.Edges = new List<Edge>();

            for (int i = 0; i < nrOfNodes; i++)
            {
                this.Nodes.Add(new Node(i.ToString()));
            }
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

        public long MaxPossibleEdges
        {
            get
            {
                return (this.Nodes.Count - 1)*(this.Nodes.Count) /2 ;
                //for (int i = 0; i < 100; i++)
                //{
                //    var f = this.Factorial(i);
                //    if (f < 0)
                //    {
                //        int k = 1;
                //    }
                //}

                //var a = this.Factorial(this.Nodes.Count);
                //var b = this.Factorial(this.Nodes.Count - 2);
                //long ret = a/(2*b);
                //return ret;
            }
        }

        private long Factorial(int n)
        {
            long ret = n;
            while (n > 1) ret *= --n;

            return ret;
        }
    }
}