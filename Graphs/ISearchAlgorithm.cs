﻿using System.Collections.Generic;

namespace Graphs
{
    public interface ISearchAlgorithm
    {
        bool Search(Node start, Node target, out List<Node> path);
    }
}