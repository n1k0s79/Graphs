using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;

namespace Graphs
{
    
    /// <summary> Represents a node in a graph. The node is connected to other nodes via weighted edges. </summary>
    [DebuggerDisplay("{Name}")]
    public class Node
    {
        public readonly string Name;

        public readonly ICollection<Edge> AdjacentEdges;

        public Node(string name)
        {
            this.Name = name;
            this.AdjacentEdges = new List<Edge>();
        }

        public void ConnectTo(Node other, double? weight = 0, bool bidirectional = true)
        {
            this.AdjacentEdges.Add(new Edge(other, weight));
            if (bidirectional) other.AdjacentEdges.Add(new Edge(this, weight));
        }

        public ICollection<Node> ConnectedNodes
        {
            get { return this.AdjacentEdges.Select(e => e.Node).ToList(); }
        }
    }
}