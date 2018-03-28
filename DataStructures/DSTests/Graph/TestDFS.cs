using System.Collections.Generic;
using DataStructures.Graph;
using DataStructures.Graph.Search;
using NUnit.Framework;

namespace DSTests.Graph
{
    public class TestDFS
    {
        
        // Tests for normal DirectedGraph
        
        [Test]
        public void TestDFSSuccess()
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

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDFSLoop()
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

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDFSFail()
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

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }
        
        // Tests for WeightedDirectedGraph
        
        [Test]
        public void TestWDFSSuccess()
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

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWDFSLoop()
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
            graph.AddEdge(v1, v4, 5);
            graph.AddEdge(v1, v3, 20);
            graph.AddEdge(v2, v4, 21);
            graph.AddEdge(v3, v1, 1);
            graph.AddEdge(v3, v5, 4);
            graph.AddEdge(v5, v1, 6);

            var expected = new LinkedList<string>();
            expected.AddLast(v1);
            expected.AddLast(v3);
            expected.AddLast(v5);

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestWDFSFail()
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

            graph.AddEdge(v2, v4, 5);
            graph.AddEdge(v3, v5, 7);

            var expected = new LinkedList<string>();

            var actual = DepthFirstSearch<string>.Search(graph, v1, v5);

            Assert.AreEqual(expected, actual);
        }
    }
}