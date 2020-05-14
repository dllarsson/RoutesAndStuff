using GraphDataStructureAndDijkstra;
using System;
using System.Collections.Generic;
using System.Text;

namespace NUnitTestProject
{
    
    public class MockGraph
    {
        public int NumberOfVertices { get; private set; }
        private Random r { get; set; }

        public List<Vertex> Vertices { get; private set; }
        public int[,] AdjacenyMatrix { get; private set; }
        public int[] Edges { get; private set; }



        public MockGraph()
        {
            NumberOfVertices = 5;
            Vertices = new List<Vertex>(5);
            AdjacenyMatrix = new int[5, 5];
            Edges = new int[5];
            r = new Random();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
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
            AdjacenyMatrix[endVertex, startVertex] = weight;
            Edges[startVertex]++;
            Edges[endVertex]++;
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
                    if (AdjacenyMatrix[i, j] > 0) // This means that there is an edge, the number indicated the weight of the edge.
                    {
                        graphString.Add(Vertices[i].Name + "--" + Vertices[j].Name + " " + AdjacenyMatrix[i, j]);
                    }
                }
            }

            return graphString;
        }

        public void AddMockData()
        {

            AddVertex("A");
            AddVertex("B");
            AddVertex("C");
            AddVertex("D");
            AddVertex("E");
            AddEdge(0, 1, 6);
            AddEdge(0, 3, 1);
            AddEdge(1, 0, 6);
            AddEdge(1, 2, 5);
            AddEdge(1, 3, 2);
            AddEdge(2, 1, 5);
            AddEdge(2, 4, 5);
            AddEdge(3, 0, 1);
            AddEdge(3, 1, 2);
            AddEdge(3, 4, 1);
            AddEdge(4, 2, 5);
            AddEdge(4, 3, 1);
        }

    }
}


