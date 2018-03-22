using System.Collections.Generic;
using DataStructures.Graph.Vertex;

namespace DataStructures.Graph.Edge
{
    public interface IEdgeStructure<T>
    {
        void AddVertex(Vertex<T> source);
        void RemoveVertex(Vertex<T> source);
        bool ContainsVertex(Vertex<T> source);
        
        void AddEdge(Vertex<T> source, Vertex<T> dest);
        void RemoveEdge(Vertex<T> source, Vertex<T> dest);
        bool ContainsEdge(Vertex<T> source, Vertex<T> dest);
        IList<Vertex<T>> OutEdges(Vertex<T> source);
        IList<Vertex<T>> InEdges(Vertex<T> source);
    }
}