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

        public Edge ConnectTo(Node other, double? weight = 0, bool bidirectional = true)
        {
            var connection = this.GetConnection(other);
            if (connection != null) return connection;
            connection = new Edge(this, other, bidirectional, weight);
            this.AdjacentEdges.Add(connection);
            if (bidirectional) other.AdjacentEdges.Add(connection);
            return connection;
        }

        public ICollection<Node> ConnectedNodes
        {
            get { return this.AdjacentEdges.Select(e => e.Other(this)).ToList(); }
        }

        public Edge GetConnection(Node other)
        {
            return this.AdjacentEdges.FirstOrDefault(x => x.Other(this).Equals(other));
        }

        public bool IsConnectedTo(Node other)
        {
            return this.AdjacentEdges.Any(x => x.Other(this).Equals(other));
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}