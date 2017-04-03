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

        public static bool operator ==(Edge x, Edge y)
        {
            bool xIsNull = ((object)x == null);
            bool yIsNull = ((object)y == null);
            if (xIsNull && yIsNull) return true;
            if (xIsNull || yIsNull) return false;

            if (x.Bidirectional != y.Bidirectional) return false;
            if (x.Bidirectional)
            {
                return (x.From == y.From && x.To == y.To) || (x.From == y.To && x.To == y.From);
            }
            else
            {
                return (x.From == y.From && x.To == y.To);
            }
        }

        public static bool operator !=(Edge x, Edge y)
        {
            bool xIsNull = ((object)x == null);
            bool yIsNull = ((object)y == null);
            if (xIsNull && yIsNull) return false;
            if (xIsNull || yIsNull) return true;

            if (x.Bidirectional != y.Bidirectional) return true;
            if (x.Bidirectional)
            {
                return !(x.From == y.From && x.To == y.To) || (x.From == y.To && x.To == y.From);
            }
            else
            {
                return !(x.From == y.From && x.To == y.To);
            }
        }
    }
}