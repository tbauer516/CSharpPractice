using System.Collections.Generic;

namespace DataStructures.Graph
{
    public interface IGraph<T>
    {
        void AddVertex(T source);
        void RemoveVertex(T source);
        bool ContainsVertex(T source);
        ICollection<T> Vertices();
        
        void AddEdge(T source, T dest);
        void RemoveEdge(T source, T dest);
        bool ContainsEdge(T source, T dest);
        IList<T> OutEdges(T source);
        IList<T> InEdges(T source);
    }
}