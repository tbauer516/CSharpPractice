using NUnit.Framework;
using DataStructures.Graph;
using System.Collections.Generic;
using DataStructures.Graph.Search;
using System;

namespace DSTests.Graph
{
    [TestFixture]
    public class TestDirectedGraph
    {
        [Test]
        public void TestVertexAdd()
        {
            var graph = new DirectedGraph<string>();

            var v1 = "One";
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

            var v1 = "One";
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

            var v1 = "One";
            var v2 = "Two";
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

            var v1 = "One";
            var v2 = "Two";
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

        [Test]
        public void TestPrint()
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
            graph.AddEdge(v3, v2);
            graph.AddEdge(v3, v4);
            graph.AddEdge(v3, v5);
            graph.AddEdge(v4, v1);
            graph.AddEdge(v5, v3);

            Console.WriteLine(graph.Print());
        }
    }
}