using System.Collections.Generic;

namespace Graphs
{
    public class DepthFirstTraversal : ITraversalAlgorithm
    {
        private Dictionary<Edge, bool> exploredEdges = new Dictionary<Edge,bool>();
        private List<Node> exploredNodes = new List<Node>();

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
                if (exploredEdges.ContainsKey(edge) && exploredEdges[edge]) continue; // to handle cyclical graphs
                exploredEdges[edge] = true;
                InnerTraverse(edge.Other(node));
            }
        }
    }
}