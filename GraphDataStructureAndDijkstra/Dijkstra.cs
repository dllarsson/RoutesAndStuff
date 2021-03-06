﻿using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace GraphDataStructureAndDijkstra
{
    public class Dijkstra
    {
        public int[] ShortestDistances { get; private set; }
        public int[] PreviousVertices { get; private set; }
        public List<int> UnvisitedVertices { get; private set; } 
        public Graph Graph { get; private set; }

        public Dijkstra(Graph graph, int startVertex)
        {
            UnvisitedVertices = new List<int>();
            Graph = graph;
            ShortestDistances = new int[graph.NumberOfVertices];
            PreviousVertices = new int[graph.NumberOfVertices];
            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                UnvisitedVertices.Add(i);
                ShortestDistances[i] = int.MaxValue;
            }
            ShortestDistances[startVertex] = 0;

            while (UnvisitedVertices.Count > 0)
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
            foreach (var value in UnvisitedVertices)
            {
                if (ShortestDistances[value] <= smallestKnownDistance)
                {
                    smallestKnownDistance = ShortestDistances[value];
                    vertex = value;
                }
            }
            UnvisitedVertices.Remove(vertex);
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