using System.Diagnostics;

namespace Graphs
{
    [DebuggerDisplay("{Node.Name}")]
    public class Edge
    {
        public readonly Node Node;

        public readonly double? Weight;

        public Edge(Node node, double? weight)
        {
            this.Node = node;
            this.Weight = weight;
        }
    }
}