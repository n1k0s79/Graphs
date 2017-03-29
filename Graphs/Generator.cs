using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    public class Generator
    {
        private static Random rnd = new Random(Guid.NewGuid().GetHashCode());

        /// <summary> Generates a graph  </summary>
        /// <param name="numberOfNodes"> The number of nodes</param>
        /// <param name="density"> The percent of other nodes a node is connected to </param>
        public Graph Generate(int numberOfNodes = 50, int density = 20)
        {
            var ret = new Graph();
            AddNodes(ret, numberOfNodes);
            ConnectNodes(ret, density);
            return ret;
        }

        /// <summary> Adds nodes to the graph </summary>
        private void AddNodes(Graph g, int numberOfNodes)
        {
            for (var i = 0; i < numberOfNodes; i++)
            {
                var n = new Node(i.ToString());
                g.Nodes.Add(n);
            }
        }

        /// <summary> Randomly connects the nodes in the graph to </summary>
        private void ConnectNodes(Graph g, int density = 20)
        {
            int connections = g.Nodes.Count * density / 100;

            foreach (var node in g.Nodes) AddRandomConnections(g, node, connections);
        }

        private void AddRandomConnections(Graph g, Node n, int numberOfConnections)
        {
            while (n.ConnectedNodes.Count < numberOfConnections)
            {
                Node r = g.GetRandomNode();
                if (r.Equals(n)) continue;
                int weight = rnd.Next(0, 10);
                n.ConnectTo(r, weight);
            }
        }

        public Graph GetSimple()
        {
            //          A   F
            //         / \ /
            //        B---C---G
            //       /\    
            //      D--E    

            Graph ret = new Graph();
            Node a = new Node("A");
            Node b = new Node("B");
            Node c = new Node("C");
            Node d = new Node("D");
            Node e = new Node("E");
            Node f = new Node("F");
            Node g = new Node("G");

            Connect(a, b);
            Connect(a, c);
            Connect(b, c);
            Connect(b, d);
            Connect(b, e);
            Connect(d, e);
            Connect(c, f);
            Connect(c, g);

            ret.Nodes.AddRange(new Node[] { a, b, c, d, e, f, g });

            return ret;
        }

        private bool Connect(Node a, Node b)
        {
            bool ret = a.ConnectTo(b);
            if (!ret) throw new Exception(string.Format("Nodes {0} and {1} already connected!", a, b));
            return ret;
        }
    }
}