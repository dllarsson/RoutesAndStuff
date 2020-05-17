using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Xml;

namespace GraphDataStructureAndDijkstra
{
    //This class generates a Graph with a number of vertices and edges
    public class GraphGenerator
    {
        private string names = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Each vertex get a letter as name.
        private Random random = new Random();
        private Graph graph { get; set; }
        private int loopCounter = 0; // Keeps track of how many loops were needed to add edges to all vertices.

        private void AddVerticesAndSetNames()
        {
            List<string> avaibleNames = new List<string>();

            foreach (var item in names)
            {
                avaibleNames.Add(item.ToString());
            }
            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                Vertex vertex = new Vertex(avaibleNames[0]);
                avaibleNames.RemoveAt(0);
                graph.Vertices.Add(vertex); //Sets name on vertex
            }
        }

        //Returns true if all vertices has 2-3 edges.
        private bool CheckIfAllVerticesHasMoraThanOneEdgeAndNotMoreThanThree()
        {
            var result = graph.Edges.Where(e => e < 2 || e > 3);
            if (result.Count() > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        //Returns a list of indices of vertices with not enough edges.
        private List<int> GetAvaibleIndices(int current)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                if (graph.Edges[i] < 3 && i != current)
                {
                    indices.Add(i);
                }
            }
            if (indices.Count() == 0)
            {
                if (!CheckIfAllVerticesHasMoraThanOneEdgeAndNotMoreThanThree())
                {
                    for (int i = 0; i < graph.NumberOfVertices; i++)
                    {
                        for (int j = 0; j < graph.NumberOfVertices; j++)
                        {
                            if (graph.AdjacenyMatrix[i, j] > 0 && j != current && graph.Edges[j] == 3)
                            {
                                graph.AdjacenyMatrix[i, j] = 0;
                                graph.AdjacenyMatrix[j, i] = 0;
                                graph.Edges[0]--;
                                graph.Edges[j]--;
                                graph.AddEdge(0, current);
                                return indices;
                            }
                        }
                    }
                }
            }
            return indices;
        }

        //Returns a list of random indices to add edges to.
        private List<int> GetRandomIndicies(List<int> input, int numberOfIndices)
        {
            List<int> indices = new List<int>();
            for (int i = 0; i < numberOfIndices; i++)
            {
                if (input.Count() == 1)
                {
                    indices.Add(input[0]);
                    return indices;
                }
                else if (input.Count() > 1)
                {
                    indices.Add(input[random.Next(1, input.Count)]);
                    input.Remove(indices[i]);
                }
            }
            return indices;
        }

        //Sets edges to all vertices, stops while loop when all vertices has 2-3 edges.
        private void SetEdges()
        {
            while (!CheckIfAllVerticesHasMoraThanOneEdgeAndNotMoreThanThree()) //While not true keep adding edges.
            {
                for (int i = 0; i < graph.NumberOfVertices; i++)
                {
                    var oneOrTwo = random.Next(2, 4) - graph.Edges[i];

                    var indices = GetRandomIndicies(GetAvaibleIndices(i), oneOrTwo);
                    for (int j = 0; j < indices.Count; j++)
                    {
                        if (graph.Edges[i] == 3 || graph.Edges[indices[j]] == 3)
                        {

                        }
                        else
                        {
                            graph.AddEdge(i, indices[j]);
                        }
                    }
                }
                loopCounter++;
            }
        }

        //Generates and returns the graph.
        public Graph Generate(int numberOfVertices)
        {
            graph = new Graph(numberOfVertices);
            AddVerticesAndSetNames();
            SetEdges();
            List<int> avaibleVertices = new List<int>(graph.NumberOfVertices);
            return graph;
        }

    }
}
