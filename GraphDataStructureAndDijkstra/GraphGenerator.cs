using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Xml;

namespace GraphDataStructureAndDijkstra
{
    //This class generates a Graph with a number of vertices and edges
    public class GraphGenerator
    {
        private string names = "ABCDEFGHIJKLMNOPQRSTUVWXYZ"; //Each vertex get a letter as name.
        private Random random = new Random();
        private List<int> edgesCount = new List<int>();
        public int[] NumberOfEdges { get; private set; }

        public Graph Generate(int numberOfVerices)
        {
            Graph graph = new Graph(numberOfVerices);
            NumberOfEdges = new int[numberOfVerices]; // this keeps track of how many edges each vertex has.
            List<string> avaibleNames = new List<string>();

            foreach (var item in names)
            {
                avaibleNames.Add(item.ToString());
            }
            for (int i = 0; i < numberOfVerices; i++)
            {
                Vertex vertex = new Vertex(avaibleNames[0]);
                avaibleNames.RemoveAt(0);
                graph.Vertices.Add(vertex); //Sets name on vertex
            }


            List<int> avaibleVertices = new List<int>(numberOfVerices);
            for (int i = 0; i < numberOfVerices; i++)
            {
                avaibleVertices.Add(i);
            }

            bool nodesMissingEdges = true;
            for (int i = 0; i < numberOfVerices; i++)
            {
                edgesCount.Add(0);
            }

            int count = 0;
            while (nodesMissingEdges) //While true add edges
            {
                if (count == avaibleVertices.Count)
                {
                    if (edgesCount.Any(z => z < 2))
                    {
                        count = 0;
                    }
                    else
                    {
                        break;
                    }
                }

                int twoOrThree = random.Next(2, 4);
                List<int> index = new List<int>();
                List<int> currentVertex = new List<int>(avaibleVertices);
                currentVertex.RemoveAt(count);

                twoOrThree -= edgesCount[avaibleVertices[count]];
                if (twoOrThree < 0) nodesMissingEdges = false;
                for (int i = 0; i < twoOrThree; i++)
                {

                    var randomIndex = random.Next(1, currentVertex.Count);
                    index.Add(currentVertex[randomIndex]);
                    currentVertex.Remove(currentVertex[randomIndex]);

                }
                for (int i = 0; i < index.Count; i++)
                {
                    if (edgesCount[index[i]] < 3)
                    {
                        int weight = random.Next(11);
                        graph.AddEdge(avaibleVertices[count], index[i]);
                        edgesCount[avaibleVertices[count]]++;
                        edgesCount[index[i]]++;
                    }
                }
                count++;
            }

            while (true) // This means that there are still Vertices without enough neighbors.
            {
                int neighbor = 0;
                List<int> neighborsList = new List<int>();
                int[] allNeighbors = new int[graph.NumberOfVertices];
                for (int x = 0; x < graph.NumberOfVertices; x++)
                {
                    for (int y = 0; y < graph.NumberOfVertices; y++)
                    {
                        if (graph.AdjacenyMatrix[x, y] > 0) // If There is an edge
                        {
                            neighbor++;
                            allNeighbors[x]++;

                            graph.Vertices[x].Neighbors.Add(y);
                        }
                    }
                    if (neighbor < 2) //If vertex has less than two neighbors then add neigbor
                    {
                        neighborsList.Add(x);
                    }
                    neighbor = 0;
                }
                if (neighborsList.Count == 0) //If all has neighbors then break while loop.
                {
                    NumberOfEdges = allNeighbors;
                    break;
                }
                for (int j = 0; j < neighborsList.Count; j++)
                {
                    int neighborIndex = -1;
                    for (int i = 0; i < graph.NumberOfVertices; i++)
                    {
                        if (allNeighbors[i] < 3 && i != neighborsList[j] && !graph.Vertices[neighborsList[j]].Neighbors.Contains(i))
                        {
                            neighborIndex = i;
                            break;
                        }
                    }

                    if (neighborIndex < 0)
                    {
                        int weight = random.Next(11);
                        graph.AddEdge(neighborsList[j], 0);
                        for (int i = 0; i < graph.NumberOfVertices; i++)
                        {
                            if (graph.AdjacenyMatrix[0, i] > 0 && graph.AdjacenyMatrix[0, i] != neighborsList[j]) //this removes and edge
                            {
                                graph.AdjacenyMatrix[0, i] = 0;
                                graph.AdjacenyMatrix[i, 0] = 0;
                                break;
                            }
                        }
                        neighborsList.Remove(neighborsList[j]);
                    }
                    else
                    {
                        int weight = random.Next(11);
                        graph.AddEdge(neighborsList[j], neighborIndex);
                        neighborsList.Remove(neighborsList[j]);
                    }
                }
            }

            return graph;
        }

    }
}
