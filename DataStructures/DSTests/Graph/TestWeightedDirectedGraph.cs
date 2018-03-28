using System;
using NUnit.Framework;
using DataStructures.Graph;
using System.Collections.Generic;
using DataStructures.Graph.Search;

namespace DSTests.Graph
{
    [TestFixture]
    class TestWeightedDirectedGraph
    {
        [Test]
        public void TestVertexAdd()
        {
            var graph = new WeightedDirectedGraph<string>();

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
            var graph = new WeightedDirectedGraph<string>();

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
            var graph = new WeightedDirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            var actual1 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(false, actual1);

            graph.AddEdge(v1, v2, 5);
            var actual2 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(true, actual2);
        }

        [Test]
        public void TestEdgeAddNegative()
        {
            var graph = new WeightedDirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            
            Assert.Throws<ArgumentException>(() => graph.AddEdge(v1, v2, -5));
        }

        [Test]
        public void TestEdgeRemove()
        {
            var graph = new WeightedDirectedGraph<string>();

            var v1 = "One";
            var v2 = "Two";
            graph.AddEdge(v1, v2, 5);
            var actual1 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(true, actual1);

            graph.RemoveEdge(v1, v2);
            var actual2 = graph.ContainsEdge(v1, v2);
            Assert.AreEqual(false, actual2);
        }
        
        [Test]
        public void TestPrint()
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
            graph.AddEdge(v3, v2, 10);
            graph.AddEdge(v3, v4, 100);
            graph.AddEdge(v3, v5, 40);
            graph.AddEdge(v4, v1, 15);
            graph.AddEdge(v5, v3, 8);

            Console.WriteLine(graph.Print());
        }
    }
}
