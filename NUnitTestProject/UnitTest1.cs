using GraphDataStructureAndDijkstra;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using System;
using System.Collections.Generic;

namespace NUnitTestProject
{
    /*Testing the edges so that the functionality that includes them work as planed*/
    public class TestEdges
    {
        [Test]
        public void TestThatEdgeIsAdded()
        {
            Graph graph = new Graph(2);
            graph.AddEdge(0, 1);

            Assert.IsTrue(graph.AdjacenyMatrix[0, 1] > 0 && graph.AdjacenyMatrix[1, 0] > 0);
        }

        [Test]
        public void TestThatEdgeIsAddedToList()
        {
            Graph graph = new Graph(3);

            graph.AddEdge(0, 1);
            graph.AddEdge(0, 2);

            Assert.AreEqual(graph.Edges[0], 2);
        }

        [Test]
        public void TestThatEdgeGetsRandomWeight()
        {
            Graph graph = new Graph(3);
            graph.AddEdge(0, 1);

            Assert.Greater(graph.AdjacenyMatrix[0, 1], 0);
            Assert.Less(graph.AdjacenyMatrix[0, 1], 11);
        }
        [Test]
        public void TestIfEdgeHasSameWeight()
        {
            Graph graph = new Graph(4);
            graph.AddEdge(0, 1);
            graph.AddEdge(1, 0);

            Assert.IsTrue(graph.AdjacenyMatrix[0, 1] == graph.AdjacenyMatrix[1, 0]);
        }
    }
    /*This class will test the graf generator so that the outcome of generation of edges are right*/
    public class TestGraphGenerator
    {
        [Test]
        public void TestThatVerticesHasEdges()
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            Graph graph = graphGenerator.Generate(5);

            for (int i = 0; i < 5; i++)
            {
                if (graph.Edges[i] == 0)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

        [Test]
        public void TestThatThereAreTenVertices()
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            Graph graph = graphGenerator.Generate(10);

            Assert.IsTrue(graph.Vertices.Count == 10);
        }

        [Test]
        public void TestThatEachVertexHasTwoToThreeConnections()
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            Graph graph = graphGenerator.Generate(10);

            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                if (graph.Edges[i] < 2)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }
        [Test]
        public void TestIfAVertexHasAConnectionToItSelf()
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            Graph graph = graphGenerator.Generate(10);

            for (int i = 0; i < graph.NumberOfVertices; i++)
            {
                if (graph.AdjacenyMatrix[i, i] > 0)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }


        //Generates a million different graphs and tests if there are any graph with less than 2 or more than 3 edges.
        [Test]
        public void TestThatThereAreNoVerticesWithLessThanTwoAndNotMoreThanTreeEdges()
        {
            GraphGenerator graphGenerator = new GraphGenerator();

            List<int[]> numberOfTimesWithLessThanTwoOrMoreThanTreeEdges = new List<int[]>();

            for (int i = 0; i < 1000000; i++)
            {
                Graph graph = graphGenerator.Generate(10);
                numberOfTimesWithLessThanTwoOrMoreThanTreeEdges.Add(Array.FindAll(graph.Edges, (a => a < 2 || a > 3)));
                var t = Array.FindAll(graph.Edges, (a => a < 2 || a > 3));
                if (t.Length > 0)
                {

                }
            }
            int count = 0;
            foreach (var item in numberOfTimesWithLessThanTwoOrMoreThanTreeEdges)
            {
                if (item.Length > 0)
                {
                    Assert.Fail();
                }
                count++;
            }
            Assert.Pass("Succes!");
        }
    }

    /*This class test the diffrent cases the can happend when you are searching for the shortest path.
     * We are useing a mock object to test these diffrent cases so the the outcome will be the same 
     everytime we test our methods*/
    public class TestRoutCalculator
    {
        [Test]
        public void TestThatShortestPathIsCalculatedCorrectly()
        {
            MockGraph mockGraph = new MockGraph();

            mockGraph.AddMockData();

            MockDijkstra dijkstra = new MockDijkstra(mockGraph, 0, 2);
            var shortestPath = dijkstra.SearchFromTo(0, 2);

            Assert.IsTrue(shortestPath[0] == 2);
            Assert.IsTrue(shortestPath[1] == 4);
            Assert.IsTrue(shortestPath[2] == 3);
            Assert.IsTrue(shortestPath[3] == 0);
        }

        [Test]
        public void TestThatTheParentVertexIsTheExpected()
        {
            MockGraph graph = new MockGraph();
            graph.AddMockData();
            MockDijkstra dijkstra = new MockDijkstra(graph, 0, 2);
            dijkstra.SearchFromTo(0, 2);
            int testVertex = dijkstra.PreviousVertices[2];

            Assert.IsTrue(testVertex == 4);
        }

    }
    /*This is the integration test. That all our methods works togheter*/
    public class IntegrationTest
    {
        [Test]
        public void TestRouteConnectorAnNodeConnectionsWithCalculateRoute()
        {
            GraphGenerator graphGenerator = new GraphGenerator();
            Graph graph = graphGenerator.Generate(10);
            Dijkstra dijkstra = new Dijkstra(graph, 0);

            Assert.AreEqual(10, graph.NumberOfVertices);
            Assert.IsNotNull(dijkstra.ShortestDistances);

        }
    }
}