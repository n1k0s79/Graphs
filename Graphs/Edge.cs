namespace Graphs
{
    public class Edge
    {
        public readonly Node From;
        public readonly Node To;
        public readonly bool Bidirectional;
        public readonly double? Weight;

        public Edge(Node from, Node to, bool bidirectional, double? weight)
        {
            this.From = from;
            this.To = to;
            this.Bidirectional = bidirectional;
            this.Weight = weight;
        }

        public Node Other(Node node)
        {
            return this.From.Equals(node) ? this.To : this.From;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}{2}", this.From, this.Bidirectional ? "<->" : "->", this.To);
        }
    }
}