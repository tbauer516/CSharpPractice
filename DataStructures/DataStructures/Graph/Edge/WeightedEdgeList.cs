using System;
using System.Collections.Generic;

namespace DataStructures.Graph.Edge
{
    public class WeightedEdgeList<T> : IEdgeStructure<T>
    {
        private readonly Dictionary<T, LinkedList<Tuple<T, int>>> _edges;

        public WeightedEdgeList()
        {    
            _edges = new Dictionary<T, LinkedList<Tuple<T, int>>>();
        }

        public void AddVertex(T source)
        {
            if (!_edges.ContainsKey(source))
                _edges.Add(source, new LinkedList<Tuple<T, int>>());
        }

        public void RemoveVertex(T source)
        {
            if (_edges.ContainsKey(source))
                _edges.Remove(source);
            
            foreach (var vertex in _edges.Keys)
                foreach (var tup in _edges[vertex])
                    if (tup.Item1.Equals(source))
                        _edges[vertex].Remove(tup);
        }

        public bool ContainsVertex(T source)
        {
            return _edges.ContainsKey(source);
        }

        public void AddEdge(T source, T dest, int weight)
        {
            if (!_edges.ContainsKey(source))
                AddVertex(source);

            var adjacencyList = _edges[source];
            
            foreach (var tup in adjacencyList)
                if (tup.Item1.Equals(dest))
                    return;
            
            adjacencyList.AddLast(new Tuple<T, int>(dest, weight));
        }

        public void AddEdge(T source, T dest)
        {
            AddEdge(source, dest, 0);
        }

        public void RemoveEdge(T source, T dest)
        {
            if (!_edges.ContainsKey(source))
                return;

            var adjacencyList = _edges[source];

            Tuple<T, int> toRemove = null;
            foreach (var tup in adjacencyList)
                if (tup.Item1.Equals(dest))
                {
                    toRemove = tup;
                    break;
                }

            adjacencyList.Remove(toRemove);
        }

        private Tuple<T, int> GetEdge(T source, T dest)
        {
            if (!_edges.ContainsKey(source))
                return null;
            
            foreach (var tup in _edges[source])
                if (tup.Item1.Equals(dest))
                    return tup;

            return null;
        }

        public bool ContainsEdge(T source, T dest)
        {
            return GetEdge(source, dest) != null;
        }

        public int EdgeWeight(T source, T dest)
        {
            var edge = GetEdge(source, dest);

            if (edge == null)
                throw new ArgumentException("Edge "
                                            + source.ToString() + " -> "
                                            + dest.ToString() + " does not exist");

            return edge.Item2;
        }

        public IList<T> OutEdges(T source)
        {
            var outList = new List<T>();
            if (!_edges.ContainsKey(source))
                return outList;
            
            foreach (var tup in _edges[source])
                outList.Add(tup.Item1);

            return outList;
        }

        public IList<T> InEdges(T source)
        {
            var inList = new List<T>();
            foreach (var vertex in _edges.Keys)
            {
                foreach (var tup in _edges[vertex])
                    if (tup.Item1.Equals(source))
                        inList.Add(vertex);
            }

            return inList;
        }

        // TODO: finish implementing
        public string Print()
        {
            string pretty = "";

            foreach (var vertex in _edges.Keys)
            {
                var seen = new HashSet<T>();
                var stack = new Stack<Tuple<T, int>>();

                //seen.Add(vertex);
                stack.Push(new Tuple<T, int>(vertex, 0));

                pretty += "\n";

                while (stack.Count > 0)
                {
                    var currentTup = stack.Pop();
                    var currentV = currentTup.Item1;
                    var currentIndent = currentTup.Item2;

                    var pad = String.Format("{0,-" + ((currentIndent > 0) ? ((currentIndent - 1) * 10) : 0) + "}", "");
                    if (currentIndent > 0)
                        pad += String.Format("{0,-10}", "|---------");
                    
                    pretty += pad + currentV.ToString() + "\n";

                    var children = OutEdges(currentV);

                    foreach (var child in children)
                    {
                        if (seen.Contains(child))
                            continue;

                        stack.Push(new Tuple<T, int>(child, currentIndent + 1));
                        seen.Add(child);
                    }
                }
            }

            return pretty;
        }
    }
}