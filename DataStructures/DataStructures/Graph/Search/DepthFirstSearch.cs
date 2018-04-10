using System.Collections.Generic;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Search
{
    // TODO: change linkedlists to lists
    public static class DepthFirstSearch<T>
    {
        public static ICollection<T> Search(IGraph<T> graph, T source, T dest)
        {
            var paths = new Dictionary<T, T>();

            var seen = new HashSet<T>();
            var stack = new Stack<T>();
            seen.Add(source);
            stack.Push(source);

            var keepRunning = true;
            while (keepRunning && stack.Count > 0)
            {
                var current = stack.Pop();
                var children = graph.OutEdges(current);

                foreach (var child in children)
                {
                    if (seen.Contains(child))
                        continue;

                    stack.Push(child);
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