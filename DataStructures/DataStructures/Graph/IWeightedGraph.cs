namespace DataStructures.Graph
{
    public interface IWeightedGraph<T> : IGraph<T>
    {
        void AddEdge(T source, T dest, int weight = 0);
        int EdgeWeight(T source, T dest);
    }
}