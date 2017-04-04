using System;
using System.Collections.Generic;

namespace Trees
{
    public class Generator
    {
        public BTree GenerateBinaryTree(int numberOfNodes)
        {
            this.nodeCounter = 0;
            var root = new BNode(this.GetNewNodeName());
            var ret = new BTree(root);
            var q = new Queue<BNode>(new List<BNode> { root });

            while (q.Count > 0 && ret.Nodes.Count < numberOfNodes)
            {
                var node = q.Dequeue();
                foreach (var child in this.AddRandomNodes(node, ret.Nodes.Count >= numberOfNodes))
                {
                    if (ret.Nodes.Count >= numberOfNodes) break;
                    ret.Nodes.Add(child);
                    q.Enqueue(child);
                }

                if (ret.Nodes.Count >= numberOfNodes) break;
            }

            this.nodeCounter = 0;
            return ret;
        }
        
        private List<BNode> AddRandomNodes(BNode parent, bool allowZeroAdditions)
        {
            var ret = new List<BNode>();
            int numberOfNodes = this.GetNumberOfNodes(allowZeroAdditions);
            for (int i = 0; i < numberOfNodes; i++)
            {
                var node = new BNode(this.GetNewNodeName());
                ret.Add(node);
                parent.AddChild(node);
            }

            return ret;
        }

        private int GetNumberOfNodes(bool allowZero)
        {
            int low = allowZero ? 0 : 1;
            return rnd.Next(low, 3);  // 0, 1, or 2 (uper bound is exclusive)
        }

        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        private string GetNewNodeName()
        {
            var ret = this.nodeCounter.ToString();
            this.nodeCounter++;
            return ret;
        }

        private int nodeCounter = 0;
    }
}