using System.Collections.Generic;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Search
{
    public static class DijkstraSearch<T>
    {
        public static ICollection<Vertex<T>> Search(IGraph<T> graph, Vertex<T> source, Vertex<T> dest)
        {
            return new LinkedList<Vertex<T>>();
        }
    }
}