using System.Collections.Generic;

namespace DataStructures.Graph
{
    public class GraphEdgeList<T>
    {
        public Dictionary<GraphNode<T>, LinkedList<GraphNode<T>>> Edges { get; private set; }

        public GraphEdgeList()
        {
            this.Edges = new Dictionary<GraphNode<T>, LinkedList<GraphNode<T>>>();
        }

        public void AddEdge(GraphNode<T> source, GraphNode<T> dest, int weight)
        {
            if (!this.Edges.ContainsKey(source))
                this.Edges.Add(source, new LinkedList<GraphNode<T>>());

            var adjacencyList = this.Edges[source];
            if (!adjacencyList.Contains(dest))
                adjacencyList.AddLast(dest);
        }
    }
}