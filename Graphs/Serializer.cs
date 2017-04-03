using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Graphs
{
    public class Serializer
    {
        public string Serialize(Graph g)
        {
            var b = new StringBuilder();
            foreach (var e in g.Edges) b.AppendLine(e.ToString());
            return b.ToString();
        }

        public Graph Deserialize(string s)
        {
            var ret = new Graph();
            var lines = s.Split(new string[] {System.Environment.NewLine}, System.StringSplitOptions.RemoveEmptyEntries);
            foreach (var l in lines) this.AddEdge(l, ret);
            return ret;
        }

        private Edge AddEdge(string edgeString, Graph g)
        {
            string arrow, fromName, toName;
            this.GetNodeNamesFromEdgeString(edgeString, out fromName, out toName, out arrow);
            var from = g.GetAddNode(fromName);
            var to = g.GetAddNode(toName);
            if (arrow == LeftArrow) SwapNodes(from, to);
            var ret = new Edge(from, to, arrow == BiArrow, null);
            return ret;
        }

        private void GetNodeNamesFromEdgeString(string edgeString, out string fromName, out string toName, out string arrow)
        {
            arrow = fromName = toName = string.Empty;

            foreach (var r in this.EdgeArrows)
            {
                if (edgeString.Contains(r))
                {
                    arrow = r;
                    var names = edgeString.Split(new [] { r }, StringSplitOptions.RemoveEmptyEntries);
                    fromName = names[0];
                    toName = names[1];
                    return;
                }
            }
        }

        private List<string> EdgeArrows
        {
            get { return new List<string> { BiArrow , RightArrow, LeftArrow }; }
        }

        private const string BiArrow = "<->";
        private const string RightArrow = "->";
        private const string LeftArrow = "<-";

        private static void SwapNodes(Node a, Node b)
        {
            Node temp = a;
            a = b;
            b = temp;
        }
    }
}