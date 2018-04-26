using System;
using System.Dynamic;

namespace DataStructures.Tree
{
    public class RedBlackTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        protected enum NodeColors { Black, Red };

        // 1) The root is black
        // 2) All leaves are black
        // 3) Every red node must have two black child nodes
        // 4) Every path from a given node to any of its descendant leaves must contain an equal number of black nodes

        private void CheckNode(RedBlackNode<T> node)
        {
            RedBlackNode<T> left = (RedBlackNode<T>) node.Left;
            RedBlackNode<T> right = (RedBlackNode<T>) node.Right;
            if (left.BlackHeight != right.BlackHeight)
            {
                // rotate
                // make left node red and checknode
                // make right node red and checknode
            }

            if (node.Color.Equals(NodeColors.Red))
            {
                if (node.Equals(this.Root) || left.Color.Equals(NodeColors.Red) || right.Color.Equals(NodeColors.Red))
                    node.Color = NodeColors.Black;
            }
        }
        
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