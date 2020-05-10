using System;
using System.Collections.Generic;
using System.Text;

namespace GraphDataStructureAndDijkstra
{
    public class Graph
    {
        public int NumberOfVertices { get; private set; }
       
        public List<Vertex> Vertices { get; private set; }
        public int[,] AdjacenyMatrix { get; private set; }


        public Graph(int numberOfVertices)
        {
            NumberOfVertices = numberOfVertices;
            Vertices = new List<Vertex>(numberOfVertices);
            AdjacenyMatrix = new int[numberOfVertices,numberOfVertices];
            for (int i = 0; i < numberOfVertices; i++)
            {
                for (int j = 0; j < numberOfVertices; j++)
                {
                    AdjacenyMatrix[i, j] = 0;
                }
            }
        }

        public void AddVertex(string name)
        {
            Vertices.Add(new Vertex(name));
        }
        public void AddEdge(int startVertex, int endVertex, int weight)
        {
            AdjacenyMatrix[startVertex, endVertex] = weight;
        }
        public string ShowVertex(int vertex)
        {
            return Vertices[vertex].Name;
        }
        
        public List<String> PrintGraph()
        {
            List<string> graphString = new List<string>();
            for (int i = 0; i < NumberOfVertices; i++)
            {
                for (int j = 0; j < NumberOfVertices; j++)
                {
                    if (AdjacenyMatrix[i,j] > 0) // This means that there is an edge, the number indicated the weight of the edge.
                    {
                        graphString.Add(Vertices[i].Name + "--" + Vertices[j].Name + " " + AdjacenyMatrix[i,j]);
                    }
                }
            }

            return graphString;
        }

    }
}
