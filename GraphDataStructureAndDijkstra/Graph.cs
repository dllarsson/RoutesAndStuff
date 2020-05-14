using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDataStructureAndDijkstra
{
    /*Holds on the information about the graph and everying that the graph needs*/
    public class Graph
    {
        public int NumberOfVertices { get; private set; }
        private Random WeightRandomizer { get; set; }
        public List<Vertex> Vertices { get; private set; }
        public int[,] AdjacenyMatrix { get; private set; }
        public int[] Edges { get; private set; }

        public Graph(int numberOfVertices)
        {
            NumberOfVertices = numberOfVertices;
            Vertices = new List<Vertex>(numberOfVertices);
            AdjacenyMatrix = new int[numberOfVertices,numberOfVertices];
            Edges = new int[numberOfVertices];
            WeightRandomizer = new Random();

            for (int i = 0; i < numberOfVertices; i++)
            {
                for (int j = 0; j < numberOfVertices; j++)
                {
                    AdjacenyMatrix[i, j] = 0;
                }
            }
        }

        private void AddVertex(string name)
        {
            Vertices.Add(new Vertex(name));
        }

        public void AddEdge(int startVertex, int endVertex)
        {
            int weight = WeightRandomizer.Next(1, 11);
            AdjacenyMatrix[startVertex, endVertex] = weight;
            AdjacenyMatrix[endVertex, startVertex] = weight;
            Edges[startVertex]++;
            Edges[endVertex]++;
        }
        
        public List<string> PrintGraph()
        {
            List<string> allVerticesWithShortestPath = new List<string>();
            for (int i = 0; i < NumberOfVertices; i++)
            {
                for (int j = 0; j < NumberOfVertices; j++)
                {
                    if (AdjacenyMatrix[i,j] > 0) // This means that there is an edge, the number indicated the weight of the edge.
                    {
                        allVerticesWithShortestPath.Add(Vertices[i].Name + "--" + Vertices[j].Name + " " + AdjacenyMatrix[i,j]);
                    }
                }
            }

            return allVerticesWithShortestPath;
        }

    }
}
