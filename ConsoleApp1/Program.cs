using GraphDataStructureAndDijkstra;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                GraphGenerator gg = new GraphGenerator();
                Graph g = gg.Generate(5);

                foreach (var item in g.PrintGraph())
                {
                    Console.WriteLine(item);
                }
                foreach (var item in gg.edgesCount)
                {
                    Console.WriteLine(item);
                }

                Console.ReadLine();
            }
        }
    }
}
