using System.Collections.Generic;

namespace Graphs
{
    public interface ITraversalAlgorithm
    {
        List<Node> Traverse(Node root);
    }
}
