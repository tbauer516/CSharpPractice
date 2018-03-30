using System.Collections.Generic;
using DataStructures.Graph.Vertex;
using DataStructures.Queue;

namespace DataStructures.Graph.Search
{
    public static class DijkstraSearch<T>
    {
        public static ICollection<T> Search(IGraph<T> graph, T source, T dest)
        {
            var pq = new PriorityQueue<T>();
            // TODO: implement a priority queue and Dijkstra's
            // Pseudocode:
            // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue
            
            return new LinkedList<T>();
        }
    }
}