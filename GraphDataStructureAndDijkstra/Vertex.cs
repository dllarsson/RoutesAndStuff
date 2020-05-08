using System;

namespace GraphDataStructureAndDijkstra
{
    public class Vertex
    {
        public bool Visited { get; set; }
        public string Name { get; set; }

        public Vertex(string name)
        {
            Name = name;
            Visited = false;
        }
    }
}
