using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    public class MockDijkstra
    {
        public int[] ShortestDistances { get; set; }
        public int[] PreviousVertices { get; set; }
        public List<int> unvisitedVertices { get; set; } = new List<int>();
        public MockGraph Graph { get; set; }

        public MockDijkstra(MockGraph graph, int startVertex, int endVertex)
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

        public List<int> SearchFromTo(int start, int end)
        {
            var currentVertex = end;
            List<int> path = new List<int>();
            path.Add(end);
            while (currentVertex != start)
            {
                path.Add(PreviousVertices[currentVertex]);

                currentVertex = Graph.Vertices.IndexOf(Graph.Vertices[PreviousVertices[currentVertex]]);
            }

            return path;
        }

    }
}
