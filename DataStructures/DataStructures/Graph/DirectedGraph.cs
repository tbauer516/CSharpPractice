namespace DataStructures.Graph
{
    public class DirectedGraph<T>
    {
        private EdgeStructure<T> _edges;
        
        public DirectedGraph()
        {
            _edges = new EdgeList<T>();
        }
        
    }
}