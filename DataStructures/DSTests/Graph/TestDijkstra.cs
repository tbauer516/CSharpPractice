using System.Collections.Generic;
using DataStructures.Graph;
using DataStructures.Graph.Search;
using NUnit.Framework;

namespace DSTests.Graph
{
    [TestFixture]
    public class TestDijkstra
    {
        [Test]
        public void TestSearch1()
        {
            var graph = new WeightedDirectedGraph<string>();

            var a = "A";
            var b = "B";
            var c = "C";
            var d = "D";
            var e = "E";
            var f = "F";
            var g = "G";
            var h = "H";
            
            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);
            graph.AddVertex(h);
            
            graph.AddEdge(a, b, 2);
            graph.AddEdge(a, d, 4);
            graph.AddEdge(a, c, 1);
            graph.AddEdge(b, c, 5);
            graph.AddEdge(b, f, 2);
            graph.AddEdge(b, e, 10);
            graph.AddEdge(c, a, 9);
            graph.AddEdge(c, e, 11);
            graph.AddEdge(d, c, 2);
            graph.AddEdge(e, d, 7);
            graph.AddEdge(e, g, 1);
            graph.AddEdge(f, h, 3);
            graph.AddEdge(g, e, 3);
            graph.AddEdge(g, f, 2);
            graph.AddEdge(h, g, 1);

            var actual = DijkstraSearch<string>.Search(graph, a, e);

            var expected = new string[] { a, b, f, h, g, e };
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void TestSearch2()
        {
            var graph = new WeightedDirectedGraph<string>();

            var a = "A";
            var b = "B";
            var c = "C";
            var d = "D";
            var e = "E";
            var f = "F";
            var g = "G";
            var h = "H";
            
            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);
            graph.AddVertex(h);
            
            graph.AddEdge(a, b, 2);
            graph.AddEdge(a, d, 4);
            graph.AddEdge(a, c, 1);
            graph.AddEdge(b, c, 5);
            graph.AddEdge(b, f, 2);
            graph.AddEdge(b, e, 10);
            graph.AddEdge(c, a, 9);
            graph.AddEdge(c, e, 11);
            graph.AddEdge(d, c, 2);
            graph.AddEdge(e, d, 7);
            graph.AddEdge(e, g, 1);
            graph.AddEdge(f, h, 3);
            graph.AddEdge(g, e, 3);
            graph.AddEdge(g, f, 2);
            graph.AddEdge(h, g, 1);

            var actual = DijkstraSearch<string>.Search(graph, d, e);

            var expected = new string[] { d, c, e };
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestSearch3()
        {
            var graph = new WeightedDirectedGraph<string>();

            var a = "A";
            var b = "B";
            var c = "C";
            var d = "D";
            var e = "E";
            var f = "F";
            var g = "G";
            
            graph.AddVertex(a);
            graph.AddVertex(b);
            graph.AddVertex(c);
            graph.AddVertex(d);
            graph.AddVertex(e);
            graph.AddVertex(f);
            graph.AddVertex(g);
            
            graph.AddEdge(a, d, 1);
            graph.AddEdge(a, c, 2);
            graph.AddEdge(b, a, 2);
            graph.AddEdge(c, d, 1);
            graph.AddEdge(c, f, 2);
            graph.AddEdge(d, b, 5);
            graph.AddEdge(d, e, 1);
            graph.AddEdge(d, g, 5);
            graph.AddEdge(d, f, 6);
            graph.AddEdge(e, b, 1);
            graph.AddEdge(f, g, 10);
            graph.AddEdge(g, e, 3);

            var actual = DijkstraSearch<string>.Search(graph, a, g);

            var expected = new string[] { a, d, g };
            
            Assert.AreEqual(expected, actual);
        }
    }
}