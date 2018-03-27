namespace DataStructures.Graph
{
    public class WeightedDirectedGraph<T> : DirectedGraph<T>, IWeightedGraph<T>
    {
        public void AddEdge(T source, T dest, int weight) { _edges.AddEdge(source, dest, weight); }
        public int EdgeWeight(T source, T dest) { return _edges.EdgeWeight(source, dest); }
    }
}
