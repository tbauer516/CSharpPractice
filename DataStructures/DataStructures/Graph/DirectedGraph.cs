using System.Collections.Generic;
using DataStructures.Graph.Edge;

namespace DataStructures.Graph
{
    public class DirectedGraph<T> : IGraph<T>
    {
        protected IEdgeStructure<T> _edges;
        
        public DirectedGraph()
        {
            _edges = new WeightedEdgeList<T>();
        }
        
        public DirectedGraph(IEdgeStructure<T> edges)
        {
            _edges = edges;
        }

        public void AddVertex(T source) { _edges.AddVertex(source); }
        public void RemoveVertex(T source) { _edges.RemoveVertex(source); }
        public bool ContainsVertex(T source) { return _edges.ContainsVertex(source); }
        public ICollection<T> Vertices() { return _edges.Vertices(); }

        public void AddEdge(T source, T dest) { _edges.AddEdge(source, dest); }
        public void RemoveEdge(T source, T dest) { _edges.RemoveEdge(source, dest); }
        public bool ContainsEdge(T source, T dest) { return _edges.ContainsEdge(source, dest); }
        public IList<T> OutEdges(T source) { return _edges.OutEdges(source); }
        public IList<T> InEdges(T source) { return _edges.InEdges(source); }

        public string Print() { return ((WeightedEdgeList<string>) _edges).Print(); }
    }
}