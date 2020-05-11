using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GraphDataStructureAndDijkstra
{
    public class Dijkstra
    {
        public int[] ShortestDistances { get; set; }
        public int[] PreviousVertices { get; set; }
        public List<int> unvisitedVertices { get; set; } = new List<int>();
        public Graph Graph { get; set; }

        public Dijkstra(Graph graph, int startVertex, int endVertex)
        {
            Graph = graph;
            ShortestDistances = new int[graph.NumberOfVertices];
            PreviousVertices = new int[graph.NumberOfVertices];
            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                unvisitedVertices.Add(i);
                ShortestDistances[i] = int.MaxValue;
            }
            ShortestDistances[startVertex] = 0;

            while (unvisitedVertices.Count > 0)
            {
                var currentVertex = GetNextVertex();
                for (int i = 0; i < graph.NumberOfVertices; i++)
                {
                    if (graph.AdjacenyMatrix[currentVertex, i] > 0)
                    {
                        if (ShortestDistances[i] > ShortestDistances[currentVertex] + graph.AdjacenyMatrix[currentVertex, i])
                        {
                            ShortestDistances[i] = ShortestDistances[currentVertex] + graph.AdjacenyMatrix[currentVertex, i];
                            PreviousVertices[i] = currentVertex;
                        }
                    }
                }
            }
        }

        private int GetNextVertex()
        {
            var smallestKnownDistance = int.MaxValue;
            var vertex = -1;
            foreach (var value in unvisitedVertices)
            {
                if (ShortestDistances[value] <= smallestKnownDistance)
                {
                    smallestKnownDistance = ShortestDistances[value];
                    vertex = value;
                }
            }
            unvisitedVertices.Remove(vertex);
            return vertex;
        }

        public StringBuilder SearchFromTo(int start, int end)
        {
            // Console.WriteLine("vertex: " + g.Vertices[i].Name + "  Distance: " + d.ShortestDistances[i] + "    via vertex: + " + g.Vertices[d.PreviousVertices[i]].Name);
            var currentVertex = end;
            List<string> path = new List<string>();
            StringBuilder sb = new StringBuilder("Path: ");
            path.Add(Graph.Vertices[end].Name);
            while (currentVertex != start)
            {
                path.Add(Graph.Vertices[PreviousVertices[currentVertex]].Name);

                currentVertex = Graph.Vertices.IndexOf(Graph.Vertices[PreviousVertices[currentVertex]]);
            }
            for (int i = path.Count -1; i > -1; i--)
            {
                sb.Append(" - " + path[i]);
            }
            sb.Append("  Total cost: " + ShortestDistances[end]);
            return sb;
        }

    }
}