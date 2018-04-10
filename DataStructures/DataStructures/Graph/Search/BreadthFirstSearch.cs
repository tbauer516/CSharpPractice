using System.Collections.Generic;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Search
{
    // TODO: change linkedlists to lists
    public static class BreadthFirstSearch<T>
    {
        public static ICollection<T> Search(IGraph<T> graph, T source, T dest)
        {
            var paths = new Dictionary<T, T>();

            var seen = new HashSet<T>();
            var queue = new Queue<T>();
            seen.Add(source);
            queue.Enqueue(source);

            var keepRunning = true;
            while (keepRunning && queue.Count > 0)
            {
                var current = queue.Dequeue();
                var children = graph.OutEdges(current);

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
            var path = new LinkedList<T>();
            while (paths.ContainsKey(nextV) || nextV.Equals(source))
            {
                path.AddFirst(nextV);

                if (nextV.Equals(source))
                    return path;

                nextV = paths[nextV];
            }

            return new LinkedList<T>();
        }
    }
}