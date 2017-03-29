using System.Collections.Generic;
using System.Text;

namespace Graphs
{
    public static class PathExtensions
    {
        /// <summary> Renders a string representation of a path of nodes by simply concatenating the node names </summary>
        public static string AsString(this List<Node> path)
        {
            var b = new StringBuilder();
            path.ForEach(node => b.Append(node.ToString()));
            return b.ToString();
        }
    }
}