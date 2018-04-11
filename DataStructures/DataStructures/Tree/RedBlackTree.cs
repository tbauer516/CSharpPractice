using System;
using System.Dynamic;

namespace DataStructures.Tree
{
    public class RedBlackTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
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
            public bool Black { get; set; }
            
            public RedBlackNode(T val) : base(val)
            {
                Black = true;
            }
        }
    }
}