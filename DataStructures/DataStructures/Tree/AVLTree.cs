using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
    public class AVLTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        protected new AVLNode<T> Root;

        public override T Insert(T val)
        {
            var newNode = new AVLNode<T>(val);
            
            if (Root == null)
            {
                Root = newNode;
                Root.Depth = 0;
                Root.Height = 0;
                Size++;
                return val;
            }

            var parent = (AVLNode<T>) FindParent(val);
            if (parent.HasChild(val))
                return val;

            if (val.CompareTo(parent.Value) < 0)
                parent.Left = newNode;
            else
                parent.Right = newNode;

            newNode.Depth = parent.Depth + 1;
            newNode.Height = 0;

            Size++;
            
            CheckBalance(parent);
            
            return val;
        }

        public override T Remove(T val)
        {
            throw new NotImplementedException();
        }

        private ICollection<AVLNode<T>> GetParentChain(AVLNode<T> node)
        {
            var chain = new LinkedList<AVLNode<T>>();
            var current = Root;

            while (current != null && current.Value.Equals(node.Value))
            {
                chain.AddLast(current);

                if (node.Value.CompareTo(current.Value) < 0)
                    current = (AVLNode<T>) current.Left;
                else if (node.Value.CompareTo(current.Value) > 0)
                    current = (AVLNode<T>) current.Right;
                else
                    break;
            }

            return chain;
        }

        private void CheckBalance(AVLNode<T> node)
        {
            throw new NotImplementedException();
        }

        protected class AVLNode<T> : BTNode<T> where T : IComparable<T>
        {
            public int Height { get; set; }
            public int Depth { get; set; }

            public AVLNode(T val) : base(val) {}
        }
    }
}