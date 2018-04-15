using System;
using System.Dynamic;

namespace DataStructures.Tree
{
    public class RedBlackTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        // 1) The root is black
        // 2) All leaves are black
        // 3) Every red node must have two black child nodes
        // 4) Every path from a given node to any of its descendant leaves must contain an equal number of black nodes

        protected enum NodeColors { Black, Red };
        
        public override T Insert(T val)
        {
            throw new NotImplementedException();
        }

        public override T Remove(T val)
        {
            throw new NotImplementedException();
        }
        
        protected class RedBlackNode<T> : BTNode<T> where T : IComparable<T>
        {
            public NodeColors Color { get; set; }
            public int BlackHeight { get; set; }
            
            public RedBlackNode(T val) : base(val)
            {
                Color = NodeColors.Red;
                BlackHeight = 0;
            }
        }
    }
}