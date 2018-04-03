using System;
using System.Collections.Generic;
using DataStructures.Graph.Vertex;
using DataStructures.Queue;

namespace DataStructures.Graph.Search
{
    public static class DijkstraSearch<T>
    {
        public static ICollection<T> Search(IWeightedGraph<T> graph, T source, T dest)
        {
            var pq = new PriorityQueue<T>();
            var dist = new Dictionary<T, int>();
            var prev = new Dictionary<T, T>();

            dist.Add(source, 0);
            foreach (var vertex in graph.Vertices())
            {
                if (!vertex.Equals(source))
                    dist.Add(vertex, int.MaxValue);
                
                pq.Insert(vertex, dist[vertex]);
            }

            while (!pq.IsEmpty())
            {
                var vertex = pq.DeleteMin();
                foreach (var outEdge in graph.OutEdges(vertex))
                {
                    var alt = dist[vertex] + graph.EdgeWeight(vertex, outEdge);
                    if (alt >= dist[outEdge])
                        continue;

                    if (dist.ContainsKey(outEdge))
                        dist[outEdge] = alt;
                    else
                        dist.Add(outEdge, alt);

                    if (prev.ContainsKey(outEdge))
                        prev[outEdge] = vertex;
                    else
                        prev.Add(outEdge, vertex);
                    
                    pq.DecreaseKey(outEdge, alt);
                }
            }

            var nextV = dest;
            var path = new LinkedList<T>();
            while (prev.ContainsKey(nextV) || nextV.Equals(source))
            {
                path.AddFirst(nextV);

                if (nextV.Equals(source))
                    return path;

                nextV = prev[nextV];
            }

            return new LinkedList<T>();
        }
    }
}