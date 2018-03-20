using System.Collections.Generic;

namespace DataStructures.Graph
{
    public class DirectedGraph<T>
    {
        public HashSet<T> Nodes;
        
        public DirectedGraph()
        {
            this.Nodes = new HashSet<T>();
        }
    }
}