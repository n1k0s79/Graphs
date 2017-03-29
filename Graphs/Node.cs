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

        public bool ConnectTo(Node other, double? weight = 0, bool bidirectional = true)
        {
            if (this.IsConnectedTo(other)) return false;
            var edge = new Edge(this, other, bidirectional, weight);
            this.AdjacentEdges.Add(edge);
            if (bidirectional) other.AdjacentEdges.Add(edge);
            return true;
        }

        public ICollection<Node> ConnectedNodes
        {
            get { return this.AdjacentEdges.Select(e => e.Other(this)).ToList(); }
        }

        public bool IsConnectedTo(Node other)
        {
            return this.AdjacentEdges.Any(x => x.Other(this).Equals(other));
        }
    }
}