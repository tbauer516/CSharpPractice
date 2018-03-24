using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Edge
{
    interface IWeightedEdgeStructure<T> :IEdgeStructure<T>
    {
        void AddEdge(Vertex<T> source, Vertex<T> dest, int weight);
    }
}
