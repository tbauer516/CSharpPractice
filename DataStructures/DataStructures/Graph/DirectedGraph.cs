using System.Collections.Generic;
using DataStructures.Graph.Edge;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph
{
    public class DirectedGraph<T> : IGraph<T>
    {
        private IEdgeStructure<T> _edges;
        
        public DirectedGraph()
        {
            _edges = new EdgeList<T>();
        }
        
        public DirectedGraph(IEdgeStructure<T> edges)
        {
            _edges = edges;
        }

        public void AddVertex(Vertex<T> source) { _edges.AddVertex(source); }
        public void RemoveVertex(Vertex<T> source) { _edges.RemoveVertex(source); }
        public bool ContainsVertex(Vertex<T> source) { return _edges.ContainsVertex(source); }

        public void AddEdge(Vertex<T> source, Vertex<T> dest) { _edges.AddEdge(source, dest); }
        public void RemoveEdge(Vertex<T> source, Vertex<T> dest) { _edges.RemoveEdge(source, dest); }
        public bool ContainsEdge(Vertex<T> source, Vertex<T> dest) { return _edges.ContainsEdge(source, dest); }
        public IList<Vertex<T>> OutEdges(Vertex<T> source) { return _edges.OutEdges(source); }
        public IList<Vertex<T>> InEdges(Vertex<T> source) { return _edges.InEdges(source); }
    }
}