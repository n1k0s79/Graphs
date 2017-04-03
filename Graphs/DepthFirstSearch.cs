using System.Collections.Generic;

namespace Graphs
{
    public class DepthFirstSearch : ISearchAlgorithm
    {
        private Dictionary<Edge, bool> exploredEdges = new Dictionary<Edge,bool>();
        private List<Node> exploredNodes = new List<Node>();
        private Node target;

        public List<Node> Traverse(Node root)
        {
            exploredEdges = new Dictionary<Edge,bool>();
            exploredNodes = new List<Node>();
            InnerTraverse(root);
            return exploredNodes;
        }

        private void InnerTraverse(Node node)
        {
            if (!exploredNodes.Contains(node)) exploredNodes.Add(node);
            foreach (var edge in node.AdjacentEdges)
            {
                if (exploredEdges.ContainsKey(edge) && exploredEdges[edge]) continue;
                exploredEdges[edge] = true;
                InnerTraverse(edge.Other(node));
            }
        }

        public bool Search(Node start, Node target, ref List<Node> path)
        {
            if (!exploredNodes.Contains(node)) exploredNodes.Add(node);
            foreach (var edge in node.AdjacentEdges)
            {
                if (exploredEdges.ContainsKey(edge) && exploredEdges[edge]) continue;
                exploredEdges[edge] = true;
                InnerTraverse(edge.Other(node));
            }
        }

        public bool InnerSearch(Node node)
        {
            if (node.Equals(target)) return true;
            if (!exploredNodes.Contains(node)) exploredNodes.Add(node);
            foreach (var edge in node.AdjacentEdges)
            {
                if (exploredEdges.ContainsKey(edge) && exploredEdges[edge]) continue;
                exploredEdges[edge] = true;
                InnerSearch(edge.Other(node));
            }
        }
    }
}