using GraphDataStructureAndDijkstra;
using System;
using System.Diagnostics;
using System.Text;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static Random r = new Random();
        static void Main(string[] args)
        {
            while (true)
            {

                for (int i = 0; i < 20000; i++) {
                    int random = r.Next(1, 11);
                    Console.WriteLine(random);
                    
                //{
                //    Stopwatch stopwatch2 = new Stopwatch();
                //    stopwatch2.Start();
                //    GraphGenerator gg2 = new GraphGenerator();
                //    Graph g2 = gg2.Generate(10);

                //    stopwatch2.Stop();
                //    Console.WriteLine(stopwatch2.Elapsed.TotalMilliseconds);
                }
                Stopwatch stopwatch = new Stopwatch();
                stopwatch.Start();
                GraphGenerator gg = new GraphGenerator();
                Graph g = gg.Generate(10);

                stopwatch.Stop();
                Console.WriteLine(stopwatch.Elapsed.TotalMilliseconds);



                foreach (var item in g.PrintGraph())
                {
                    Console.WriteLine(item);
                }

                var startVertex = int.Parse(Console.ReadLine());
                var endVertex = int.Parse(Console.ReadLine());
                Dijkstra d = new Dijkstra(g, startVertex);

                var path = d.SearchFromTo(startVertex, endVertex);
                StringBuilder sb = new StringBuilder("Path: ");
                for (int i = path.Count - 1; i > -1; i--)
                {
                    sb.Append(" - " + g.Vertices[path[i]].Name);
                }
                sb.Append("  Total cost: " + d.ShortestDistances[endVertex]);
                Console.WriteLine(sb);
                for (int i = 0; i < d.ShortestDistances.Length; i++)
                {
                    Console.WriteLine("vertex: " + g.Vertices[i].Name + "  Distance: " + d.ShortestDistances[i] + "    via vertex: + " + g.Vertices[d.PreviousVertices[i]].Name);
                }


                Console.ReadLine();
            }

        }
    }
}












//Graph g = new Graph(5);

//g.AddVertex("A");
//g.AddVertex("B");
//g.AddVertex("C");
//g.AddVertex("D");
//g.AddVertex("E");
//g.AddEdge(0, 1, 6);
//g.AddEdge(0, 3, 1);
//g.AddEdge(1, 0, 6);
//g.AddEdge(1, 2, 5);
//g.AddEdge(1, 3, 2);
//g.AddEdge(1, 4, 2);
//g.AddEdge(2, 1, 5);
//g.AddEdge(2, 4,5);
//g.AddEdge(3, 0, 1);
//g.AddEdge(3, 1, 2);
//g.AddEdge(3, 4, 1);
//g.AddEdge(4, 1, 2);
//g.AddEdge(4, 2, 5);
//g.AddEdge(4, 3, 1);

