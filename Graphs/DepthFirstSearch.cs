using System;
using System.Collections.Generic;

namespace Graphs
{
    public class DepthFirstSearch : ISearchAlgorithm
    {
        private Dictionary<Edge, bool> exploredEdges = new Dictionary<Edge,bool>();
        private List<Node> exploredNodes = new List<Node>();
        private Node target;

        public bool Search(Node start, Node target, out List<Node> path)
        {
            this.target = target;
            var ret = this.InnerSearch(start);
            path = exploredNodes;
            return ret;
        }

        public bool InnerSearch(Node node)
        {
            if (node.Equals(target))
            {
                exploredNodes.Add(node);
                return true;
            }

            if (!exploredNodes.Contains(node)) exploredNodes.Add(node);
            foreach (var edge in node.AdjacentEdges)
            {
                if (exploredEdges.ContainsKey(edge) && exploredEdges[edge]) continue;
                exploredEdges[edge] = true;
                if (InnerSearch(edge.Other(node))) return true;
            }
            return false;
        }
    }
}