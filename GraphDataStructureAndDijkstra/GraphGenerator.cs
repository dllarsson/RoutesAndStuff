using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Xml;

namespace GraphDataStructureAndDijkstra
{
    public class GraphGenerator
    {
        private string names = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        Random r = new Random();
        public List<int> edgesCount = new List<int>();

        public int[] numberOfEdges;

        public Graph Generate(int numberOfVerices)
        {
            Graph g = new Graph(numberOfVerices);
            numberOfEdges = new int[numberOfVerices]; // this keeps track of how many edges each vertex has.
            List<string> avaibleNames = new List<string>();

            foreach (var item in names)
            {
                avaibleNames.Add(item.ToString());
            }
            for (int i = 0; i < numberOfVerices; i++)
            {
                Vertex vertex = new Vertex(avaibleNames[0]);
                avaibleNames.RemoveAt(0);
                g.Vertices.Add(vertex);
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

                int twoOrThree = r.Next(2, 4);
                List<int> index = new List<int>();
                List<int> currentVertex = new List<int>(avaibleVertices);
                currentVertex.RemoveAt(count);

                twoOrThree -= edgesCount[avaibleVertices[count]];
                if (twoOrThree < 0) nodesMissingEdges = false;
                for (int i = 0; i < twoOrThree; i++)
                {

                    var randomIndex = r.Next(1, currentVertex.Count);
                    index.Add(currentVertex[randomIndex]);
                    currentVertex.Remove(currentVertex[randomIndex]);

                }
                for (int i = 0; i < index.Count; i++)
                {
                    if (edgesCount[index[i]] < 3)
                    {
                        int weight = r.Next(11);
                        g.AddEdge(avaibleVertices[count], index[i], weight);
                        g.AddEdge(index[i], avaibleVertices[count], weight);



                        edgesCount[avaibleVertices[count]]++;
                        edgesCount[index[i]]++;
                    }
                }

                count++;
            }
            while (true) // This means that there are still Vertices without enough neighbors.
            {
                int neighbors = 0;
                List<int> neighborsArr = new List<int>();
                int[] allNeighbors = new int[g.NumberOfVertices];
                for (int x = 0; x < g.NumberOfVertices; x++)
                {
                    for (int y = 0; y < g.NumberOfVertices; y++)
                    {
                        if (g.AdjacenyMatrix[x, y] > 0)
                        {
                            neighbors++;
                            allNeighbors[x]++;

                            g.Vertices[x].Neighbors.Add(y);
                        }
                    }
                    if (neighbors < 2)
                    {
                        neighborsArr.Add(x);
                    }
                    neighbors = 0;
                }
                if (neighborsArr.Count == 0)
                {
                    numberOfEdges = allNeighbors;
                    break;
                }
                for (int j = 0; j < neighborsArr.Count; j++)
                {
                    int neighborIndex = -1;
                    for (int i = 0; i < g.NumberOfVertices; i++)
                    {
                        if (allNeighbors[i] < 3 && i != neighborsArr[j] && !g.Vertices[neighborsArr[j]].Neighbors.Contains(i))
                        {
                            neighborIndex = i;
                            break;
                        }
                    }

                    if (neighborIndex < 0)
                    {
                        int weight = r.Next(11);
                        g.AddEdge(neighborsArr[j], 0, weight);
                        g.AddEdge(0, neighborsArr[j], weight);
                        Console.WriteLine("Special BUT all are 3 but one");
                        for (int i = 0; i < g.NumberOfVertices; i++)
                        {
                            if (g.AdjacenyMatrix[0, i] > 0 && g.AdjacenyMatrix[0, i] != neighborsArr[j])
                            {
                                g.AdjacenyMatrix[0, i] = 0;
                                g.AdjacenyMatrix[i, 0] = 0;
                                break;
                            }
                        }
                        neighborsArr.Remove(neighborsArr[j]);
                    }
                    else
                    {
                        int weight = r.Next(11);
                        g.AddEdge(neighborsArr[j], neighborIndex, weight);
                        g.AddEdge(neighborIndex, neighborsArr[j], weight);
                        neighborsArr.Remove(neighborsArr[j]);
                        Console.WriteLine("Special");
                    }
                }
            }

            return g;
        }

    }
}
