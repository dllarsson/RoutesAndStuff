using GraphDataStructureAndDijkstra;
using NUnit.Framework;

namespace NUnitTestProject
{
    public class TestNodeConnections
    {
        Node nodeOne;
        Node nodeTwo;
        int weight;
        Connections testConnection;

        [Test]
        public void TestThatConnectionIsAdded()
        {
            testConnection = new Connections(new Node("A"), new Node("B"), 5);

            Assert.AreEqual(testConnection.a.Name, "A");
            Assert.AreEqual(testConnection.b.Name, "B");
            Assert.AreEqual(testConnection.Weight, 5);
        }
        [Test]
        public void TestThatConnectionIsAddedToList()
        {
            nodeOne = new Node("A");
            nodeTwo = new Node("B");
            nodeOne.AddConnections(nodeOne, nodeTwo);

            Assert.IsTrue(nodeOne.Connections.Count == 1);
            Assert.IsTrue(nodeTwo.Connections.Count == 1);
        }
        [Test]
        public void TestThatConnectionGetsRandomWeight()
        {
            nodeOne = new Node("A");
            nodeTwo = new Node("B");
            nodeOne.AddConnections(nodeOne, nodeTwo);
            weight = nodeOne.Connections[0].Weight;

            Assert.IsTrue(weight > 0 && weight <= 10);
        }
        [Test]
        public void TestIfNodeAHasConnectionWithBAndBWithA()
        {
            nodeOne = new Node("A");
            nodeTwo = new Node("B");
            nodeOne.AddConnections(nodeOne, nodeTwo);

            Assert.AreEqual(nodeOne.Connections[0].b, nodeTwo);
        }
        [Test]
        public void TestIfAConnectionHasTheSameWeight()
        {
            nodeOne = new Node("A");
            nodeTwo = new Node("B");
            nodeOne.AddConnections(nodeOne, nodeTwo);

            Assert.AreEqual(nodeOne.Connections[0].Weight, nodeTwo.Connections[0].Weight);
        }
    }
    public class TestRoutGenerator
    {
        RouteConnector testConnector;

        //In this some test more methods within the class will be tested. In the method ConnectRouts the are 2 more methods involved to create
        // all the connections to the nodes. If they work as excpected the test will pass.
        [Test]
        public void TestThatANodeHasAConnection()
        {
            testConnector = new RouteConnector();
            testConnector.ConnectRouts();

            for (int i = 0; i < testConnector.Nodes.Count; i++)
            {
                if (testConnector.Nodes[i].Connections.Count == 0)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }

        [Test]
        public void TestThatThereIsTenNodes()
        {
            testConnector = new RouteConnector();
            testConnector.CreateListNodes();

            Assert.IsTrue(testConnector.Nodes.Count == 10);
        }

        [Test]
        public void TestThatEachNodeHasTwoToThreeConnections()
        {
            testConnector = new RouteConnector();
            testConnector.ConnectRouts();

            for (int i = 0; i < testConnector.Nodes.Count; i++)
            {
                if (testConnector.Nodes[i].Connections.Count <= 1 || testConnector.Nodes[i].Connections.Count > 3)
                {
                    Assert.Fail();
                }
            }
            Assert.Pass();
        }
        [Test]
        public void TestIfANodeHasConnectionToItself()
        {
            testConnector = new RouteConnector();
            testConnector.ConnectRouts();

            for (int i = 0; i < testConnector.Nodes.Count; i++)
            {
                for (int x = 0; x < testConnector.Nodes[i].Connections.Count; x++)
                {
                    if (testConnector.Nodes[i].Connections[x].a == testConnector.Nodes[i].Connections[x].b)
                    {
                        Assert.Fail();
                    }
                }
            }
            Assert.Pass();
        }
    }
    public class TestRoutCalculator
    {
        MockObject mock;
        Vertex testVertex;
        RouteCalculator calculator;
        [Test]
        public void TestThatShortestPathIsCalculatedCorrectly()
        {
            mock = new MockObject();
            calculator = new RouteCalculator(mock.mockObject);
            testVertex = calculator.FindShortestPath(mock.mockObject[0], mock.mockObject[2], 0);

            Assert.IsTrue(testVertex.GoldenNumber == 6);
        }
        [Test]
        public void TestThatRightNodeGetsReturned()
        {
            mock = new MockObject();
            calculator = new RouteCalculator(mock.mockObject);
            testVertex = calculator.FindShortestPath(mock.mockObject[0], mock.mockObject[2], 0);

            Assert.IsTrue(testVertex.vertex == "C");
        }
        [Test]
        public void TestThatTheParentVertexIsTheExpected()
        {
            mock = new MockObject();
            calculator = new RouteCalculator(mock.mockObject);
            testVertex = calculator.FindShortestPath(mock.mockObject[0], mock.mockObject[2], 0);

            Assert.IsTrue(testVertex.parentVertex == "E");
        }
        [Test]
        public void TestThatItTakeTheExpectedWay()
        {
            mock = new MockObject();
            calculator = new RouteCalculator(mock.mockObject);
            testVertex = calculator.FindShortestPath(mock.mockObject[0], mock.mockObject[4], 0);

            Assert.IsTrue(testVertex.parentVertex == "B");
            Assert.IsTrue(testVertex.vertex == "E");
            Assert.AreEqual(testVertex.GoldenNumber, 5);
        }
    }
    public class IntegrationTest
    {
        RouteConnector testConnector;
        Vertex testVertex;
        RouteCalculator calculator;

        [Test]
        public void TestRouteConnectorAnNodeConnectionsWithCalculateRoute()
        {
            testConnector = new RouteConnector();
            testConnector.ConnectRouts();
            calculator = new RouteCalculator(testConnector.Nodes);
            testVertex = calculator.FindShortestPath(testConnector.Nodes[0], testConnector.Nodes[1], 0);

            Assert.AreEqual(testVertex.vertex, testConnector.Nodes[1].Name);
            Assert.IsTrue(testVertex.Distance < 10);
            Assert.IsTrue(testVertex.Distance > 0);
            Assert.IsTrue(testConnector.Nodes.Count == 10);
        }
    }
}