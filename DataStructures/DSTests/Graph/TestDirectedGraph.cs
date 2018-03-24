using NUnit.Framework;
using DataStructures.Graph;
using System.Collections.Generic;
using DataStructures.Graph.Search;
using DataStructures.Graph.Vertex;

namespace DSTests.Graph
{
    
    [TestFixture]
    public class TestDirectedGraph
    {

        private DirectedGraph<string> Setup()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");
            var v6 = new Vertex<string>("Six");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);
            graph.AddVertex(v6);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v1, v4);

            graph.AddEdge(v2, v3);
            graph.AddEdge(v2, v5);
            graph.AddEdge(v2, v6);

            graph.AddEdge(v3, v1);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v3, v6);

            graph.AddEdge(v4, v2);
            graph.AddEdge(v4, v3);
            graph.AddEdge(v4, v5);

            graph.AddEdge(v5, v1);
            graph.AddEdge(v5, v2);
            graph.AddEdge(v5, v6);

            graph.AddEdge(v6, v1);
            graph.AddEdge(v6, v3);
            graph.AddEdge(v6, v4);

            return graph;
        }

        [Test]
        public void TestVertexAdd()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var actual1 = graph.ContainsVertex(v1);
            Assert.AreEqual(false, actual1);

            graph.AddVertex(v1);
            var actual2 = graph.ContainsVertex(v1);
            Assert.AreEqual(true, actual2);
        }

        [Test]
        public void TestVertexRemove()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            graph.AddVertex(v1);
            var actual1 = graph.ContainsVertex(v1);
            Assert.AreEqual(true, actual1);

            graph.RemoveVertex(v1);
            var actual2 = graph.ContainsVertex(v1);
            Assert.AreEqual(false, actual2);
        }

        [Test]
        public void TestEdgeAdd()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var actual1 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(false, actual1);

            graph.AddEdge(v1, v2);
            var actual2 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(true, actual2);
        }

        [Test]
        public void TestEdgeRemove()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            graph.AddEdge(v1, v2);
            var actual1 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(true, actual1);

            graph.RemoveEdge(v1, v2);
            var actual2 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(false, actual2);
        }

        [Test]
        public void TestBFSSuccess()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v5);

            var expected = new LinkedList<Vertex<string>>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBFSShortest()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v5);
            graph.AddEdge(v4, v5);

            var expected = new LinkedList<Vertex<string>>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBFSLoop()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v4);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v1);
            graph.AddEdge(v3, v5);
            graph.AddEdge(v5, v1);

            var expected = new LinkedList<Vertex<string>>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestBFSFail()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);

            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v5);

            var expected = new LinkedList<Vertex<string>>();

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TestDFSSuccess()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v5);

            var expected = new LinkedList<Vertex<string>>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDFSLoop()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v4);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v1);
            graph.AddEdge(v3, v5);
            graph.AddEdge(v5, v1);

            var expected = new LinkedList<Vertex<string>>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDFSFail()
        {
            var graph = new DirectedGraph<string>();

            var v1 = new Vertex<string>("One");
            var v2 = new Vertex<string>("Two");
            var v3 = new Vertex<string>("Three");
            var v4 = new Vertex<string>("Four");
            var v5 = new Vertex<string>("Five");

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);

            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v5);

            var expected = new LinkedList<Vertex<string>>();

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }
    }
}