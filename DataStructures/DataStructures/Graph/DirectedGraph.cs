using System.Collections.Generic;

namespace DataStructures.Graph
{
    public class DirectedGraph<T>
    {
        private EdgeStructure<T> _edges;
        
        public DirectedGraph()
        {
            _edges = new EdgeList<T>();
        }
        
        public DirectedGraph(EdgeStructure<T> edges)
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

        public ICollection<Vertex<T>> BreadthFirstSearch(Vertex<T> source, Vertex<T> dest)
        {
            var paths = new Dictionary<Vertex<T>, Vertex<T>>();

            var seen = new HashSet<Vertex<T>>();
            var queue = new Queue<Vertex<T>>();
            seen.Add(source);
            queue.Enqueue(source);

            var keepRunning = true;
            while (keepRunning && queue.Count > 0)
            {
                var current = queue.Dequeue();
                var children = _edges.OutEdges(current);

                foreach (var child in children)
                {
                    if (seen.Contains(child))
                        continue;

                    queue.Enqueue(child);
                    seen.Add(child);
                    paths.Add(child, current);

                    if (child.Equals(dest))
                    {
                        keepRunning = false;
                        break;
                    }
                }
            }

            var nextV = dest;
            var path = new LinkedList<Vertex<T>>();
            while (paths.ContainsKey(nextV) || nextV.Equals(source))
            {
                path.AddFirst(nextV);

                if (nextV.Equals(source))
                    return path;

                nextV = paths[nextV];
            }

            return new LinkedList<Vertex<T>>();
        }
    }
}