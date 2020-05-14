using GraphDataStructureAndDijkstra;
using NUnit.Framework;

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
    /*This class will test the graf generator so that the outcome of generation of connections are right*/
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

            Assert.AreEqual(graph.NumberOfVertices, 10);
            Assert.IsNotNull(dijkstra.ShortestDistances);
            Assert.IsNotNull(graphGenerator.NumberOfEdges);

        }
    }
}