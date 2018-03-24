using System.Collections.Generic;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Edge
{
    public class WeightedEdgeList<T> : EdgeList<T>, IWeightedEdgeStructure<T>
    {
        private readonly Dictionary<Vertex<T>, LinkedList<Vertex<T>>> _edges;
        private readonly Dictionary<Vertex<T>, LinkedList<int>> _weights;

        public void AddEdge(Vertex<T> source, Vertex<T> dest, int weight)
        {

        }
    }
}