using System;
using System.Collections.Generic;

namespace GraphDataStructureAndDijkstra
{
    /*Holds the information about node and their connections*/
    public class Vertex 
    {
        public string Name { get; private set; }
        public List<int> Neighbors { get; private set; } 
        public Vertex(string name)
        {
            Neighbors = new List<int>();
            Name = name;
        }
    }
}
