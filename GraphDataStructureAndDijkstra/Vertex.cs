using System;
using System.Collections.Generic;

namespace GraphDataStructureAndDijkstra
{
    public class Vertex //Vertex class
    {
        public string Name { get; set; }
        public List<int> Neighbors { get; set; } = new List<int>();
        public Vertex(string name)
        {
            Name = name;
        }
    }
}
