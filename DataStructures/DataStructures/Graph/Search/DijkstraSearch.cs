using System.Collections.Generic;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Search
{
    public static class DijkstraSearch<T>
    {
        public static ICollection<Vertex<T>> Search(IGraph<T> graph, Vertex<T> source, Vertex<T> dest)
        {
            // TODO: implement a priority queue and Dijkstra's
            // Pseudocode:
            // https://en.wikipedia.org/wiki/Dijkstra%27s_algorithm#Using_a_priority_queue
            
            return new LinkedList<Vertex<T>>();
        }
    }
}