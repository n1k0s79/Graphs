using System.Collections.Generic;
using System.Diagnostics;

namespace Trees
{
    [DebuggerDisplay("A binary tree with {Nodes.Count} nodes")]
    public class BTree
    {
        public List<BNode> Nodes { get; private set; }

        public BTree()
        {
            this.Nodes = new List<BNode>();
        }

        public BTree(params BNode[] nodes)
        {
            this.Nodes = new List<BNode>();
            this.Nodes.AddRange(nodes);
        }

        public static BTree FromArray(int[] parentRelationships)
        {
            BTree ret = new BTree();
            for (int i = 0; i < parentRelationships.Length; i++)
            {
                ret.Nodes.Add(new BNode(i.ToString()));
            }

            for (int i = 0; i < parentRelationships.Length; i++)
            {
                var parentIndex = parentRelationships[i];
                if (parentIndex == -1) continue;
                var parentNode = ret.Nodes[parentIndex];
                var childNode = ret.Nodes[i];
                parentNode.AddChild(childNode);
            }

            return ret;
        }

        public int[] ToIntArray()
        {
            var ret = new int[this.Nodes.Count];

            for (int i = 0; i < this.Nodes.Count; i++)
            {
                var node = this.Nodes[i];
                var parent = node.Parent;
                if (parent == null)
                    ret[i] = -1;
                else
                    ret[i] = this.Nodes.IndexOf(parent);
            }

            return ret;
        }

        public bool SameAs(BTree other)
        {
            if (this.Nodes.Count != other.Nodes.Count) return false;
            for (int i = 0; i < this.Nodes.Count; i++)
            {
                if (!this.Nodes[i].SameAs(other.Nodes[i])) return false;
            }

            return true;
        }
    }
}