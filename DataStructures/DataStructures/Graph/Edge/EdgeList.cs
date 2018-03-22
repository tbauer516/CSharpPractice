using System.Collections.Generic;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Edge
{
    public class EdgeList<T> : IEdgeStructure<T>
    {
        private readonly Dictionary<Vertex<T>, LinkedList<Vertex<T>>> _edges;

        public EdgeList()
        {
            _edges = new Dictionary<Vertex<T>, LinkedList<Vertex<T>>>();
        }

        public void AddVertex(Vertex<T> source)
        {
            if (!_edges.ContainsKey(source))
                _edges.Add(source, new LinkedList<Vertex<T>>());
        }

        public void RemoveVertex(Vertex<T> source)
        {
            if (_edges.ContainsKey(source))
                _edges.Remove(source);
            
            foreach (var vertex in _edges.Keys)
                if (_edges[vertex].Contains(source))
                    _edges[vertex].Remove(source);
        }

        public bool ContainsVertex(Vertex<T> source)
        {
            return _edges.ContainsKey(source);
        }

        public void AddEdge(Vertex<T> source, Vertex<T> dest)
        {
            if (!_edges.ContainsKey(source))
                _edges.Add(source, new LinkedList<Vertex<T>>());

            var adjacencyList = _edges[source];
            if (!adjacencyList.Contains(dest))
                adjacencyList.AddLast(dest);
        }

        public void RemoveEdge(Vertex<T> source, Vertex<T> dest)
        {
            if (!_edges.ContainsKey(source))
                return;

            var adjacencyList = _edges[source];
            if (adjacencyList.Contains(dest))
                adjacencyList.Remove(dest);
        }

        public bool ContainsEdge(Vertex<T> source, Vertex<T> dest)
        {
            return _edges.ContainsKey(source) && _edges[source].Contains(dest);
        }

        public IList<Vertex<T>> OutEdges(Vertex<T> source)
        {
            var outList = new List<Vertex<T>>();
            if (!_edges.ContainsKey(source))
                return outList;
            
            foreach (var vertex in _edges[source])
                outList.Add(vertex);

            return outList;
        }

        public IList<Vertex<T>> InEdges(Vertex<T> source)
        {
            var inList = new List<Vertex<T>>();
            foreach (var key in _edges.Keys)
            {
                if (_edges[key].Contains(source))
                    inList.Add(key);
            }

            return inList;
        }
    }
}