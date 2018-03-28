using System.Collections.Generic;
using NUnit.Framework;
using DataStructures.Graph;
using DataStructures.Graph.Search;

namespace DSTests.Graph
{
    public class TestBFS
    {
        
        // Tests for the normal DirectedGraph
        
        [Test]
        public void TestBFSSuccess()
        {
            var graph = new DirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);
            graph.AddEdge(v1, v3);
            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v5);

            var expected = new LinkedList<string>();
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

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

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

            var expected = new LinkedList<string>();
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

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

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

            var expected = new LinkedList<string>();
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

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2);

            graph.AddEdge(v2, v4);
            graph.AddEdge(v3, v5);

            var expected = new LinkedList<string>();

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }
        
        // Tests for the WeightedDirectedGraph
        
        [Test]
        public void TestWBFSSuccess()
        {
            var graph = new WeightedDirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2, 2);
            graph.AddEdge(v1, v3, 3);
            graph.AddEdge(v2, v4, 4);
            graph.AddEdge(v3, v5, 5);

            var expected = new LinkedList<string>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWBFSShortest()
        {
            var graph = new WeightedDirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2, 3);
            graph.AddEdge(v1, v3, 4);
            graph.AddEdge(v2, v4, 2);
            graph.AddEdge(v3, v5, 1);
            graph.AddEdge(v4, v5, 10);

            var expected = new LinkedList<string>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWBFSLoop()
        {
            var graph = new WeightedDirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2, 2);
            graph.AddEdge(v1, v4, 3);
            graph.AddEdge(v1, v3, 4);
            graph.AddEdge(v2, v4, 5);
            graph.AddEdge(v3, v1, 10);
            graph.AddEdge(v3, v5, 20);
            graph.AddEdge(v5, v1, 4);

            var expected = new LinkedList<string>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWBFSFail()
        {
            var graph = new WeightedDirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            var v3 = "Three";
            var v4 = "Four";
            var v5 = "Five";

            graph.AddVertex(v1);
            graph.AddVertex(v2);
            graph.AddVertex(v3);
            graph.AddVertex(v4);
            graph.AddVertex(v5);

            graph.AddEdge(v1, v2, 3);

            graph.AddEdge(v2, v4, 4);
            graph.AddEdge(v3, v5, 4);

            var expected = new LinkedList<string>();

            var actual = BreadthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }
    }
}