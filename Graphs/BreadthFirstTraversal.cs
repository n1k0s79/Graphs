using System.Collections.Generic;

namespace Graphs
{
    public class BreadthFirstTraversal : ITraversalAlgorithm
    {
        private Dictionary<Edge, bool> exploredEdges = new Dictionary<Edge,bool>();
        private List<Node> exploredNodes = new List<Node>();
                
        public List<Node> Traverse(Node root)
        {
 	        var q = new Queue<Node>();
            q.Enqueue(root);
            exploredNodes = new List<Node>();
            while (q.Count > 0)
            {
                Node t = q.Dequeue();
                exploredNodes.Add(t);
                foreach (var n in t.ConnectedNodes)
                {
                    if (!exploredNodes.Contains(n) && !q.Contains(n)) q.Enqueue(n);
                }
            }

            return exploredNodes;
        }
    }
}