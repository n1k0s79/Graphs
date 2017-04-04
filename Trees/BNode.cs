using System.Collections.Generic;

namespace Trees
{
    public class BNode
    {
        public string Name { get; private set; }
        public BNode Parent { get; private set; }
        public BNode Left { get; private set; }
        public BNode Right { get; private set; }

        public BNode(string name, BNode left = null, BNode right = null)
        {
            this.Name = name;
            this.Left = left;
            this.Right = right;
        }

        public override string ToString()
        {
            return this.Name;
        }

        public bool AddChild(BNode child)
        {
            if (this.Left == null)
            {
                this.Left = child;
                child.Parent = this;
                return true;
            }

            if (this.Right == null)
            {
                this.Right = child;
                child.Parent = this;
                return true;
            }

            return false;
        }

        public static bool operator ==(BNode x, BNode y)
        {
            bool xIsNull = ((object)x == null);
            bool yIsNull = ((object)y == null);
            if (xIsNull && yIsNull) return true;
            if (xIsNull || yIsNull) return false;
            return x.Name == y.Name;
        }

        public static bool operator !=(BNode x, BNode y)
        {
            bool xIsNull = ((object)x == null);
            bool yIsNull = ((object)y == null);
            if (xIsNull && yIsNull) return false;
            if (xIsNull || yIsNull) return true;
            return x.Name != y.Name;
        }

        public bool SameAs(BNode other)
        {
            if (this != other) return false;
            if (this.Parent != other.Parent) return false;
            if (this.Left != other.Left) return false;
            if (this.Right != other.Right) return false;
            return true;
        }
    }
}