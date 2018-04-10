using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace DataStructures.Tree
{
    public abstract class BinaryTree<T> where T : IComparable<T>
    {
        protected BTNode<T> Root;
        public int Size { get; protected set; }

        protected BinaryTree()
        {
            Root = null;
            Size = 0;
        }

        public abstract T Insert(T val);

        public abstract T Remove(T val);
        
        public bool Contains(T val)
        {
            var node = FindNode(val);
            return node != null;
        }
        
        public List<T> InOrder()
        {
            return InOrder(Root, new List<T>());
        }

        private List<T> InOrder(BTNode<T> current, List<T> returnList)
        {
            if (current == null)
                return returnList;

            InOrder(current.Left, returnList);
            returnList.Add(current.Value);
            InOrder(current.Right, returnList);
            return returnList;
        }

        public List<T> PreOrder()
        {
            return PreOrder(Root, new List<T>());
        }

        private List<T> PreOrder(BTNode<T> current, List<T> returnList)
        {
            if (current == null)
                return returnList;

            returnList.Add(current.Value);
            PreOrder(current.Left, returnList);
            PreOrder(current.Right, returnList);
            return returnList;
        }

        protected BTNode<T> FindSmallestParent(BTNode<T> search)
        {
            // returns:
            //  null:   search is null
            //  search: when search has no left children
            //  BTNode: furthest left child of search otherwise
            var current = search;
            while (current != null && current.Left != null)
            {
                if (current.Left.Left == null)
                    break;

                current = current.Left;
            }
            return current;
        }
        
        protected BTNode<T> FindLargestParent(BTNode<T> search)
        {
            // returns:
            //  null:   search is null
            //  search: when search has no right children
            //  BTNode: furthest right child of search otherwise
            var current = search;
            while (current != null && current.Right != null)
            {
                if (current.Right.Right == null)
                    break;

                current = current.Right;
            }
            return current;
        }

        protected BTNode<T> FindParent(T val)
        {
            // returns the parent of the node of the value being searched for
            // returns:
            //      null:   when Root is null
            //      Root:   when the value searched is the Root
            //      BTNode: when parent where child is found OR would be found if it existed
            // **NOTE: does not provide info on whether the value exists or not
            var current = this.Root;
            while (current != null)
            {
                BTNode<T> nextChild = null;
                if (val.CompareTo(current.Value) < 0)
                {
                    nextChild = current.Left;
                }
                else if (val.CompareTo(current.Value) > 0)
                {
                    nextChild = current.Right;
                }

                if (nextChild == null || nextChild.Value.Equals(val))
                    return current;

                current = nextChild;
            }

            return null;
        }

        protected BTNode<T> FindNode(T val)
        {
            // returns the node we are looking for
            // returns:
            //    null:    when Root is null
            //    null:    when the node is not found
            //    BTNode:  when the node is found
            var parent = FindParent(val);
            if (parent == null)
                return null;

            BTNode<T> child = null;
            if (parent.Value.Equals(val))
                child = parent;
            else if (parent.Left != null && parent.Left.Value.Equals(val))
                child = parent.Left;
            else if (parent.Right != null && parent.Right.Value.Equals(val))
                child = parent.Right;

            return child;
        }

        protected class BTNode<T> where T : IComparable<T>
        {
            public T Value { get; }
            public BTNode<T> Left { get; set; }
            public BTNode<T> Right { get; set; }
            
            public BTNode(T val)
            {
                Value = val;
                Left = null;
                Right = null;
            }

            public bool HasChild(T val)
            {
                if (Right != null && Right.Value.Equals(val))
                    return true;
                if (Left != null && Left.Value.Equals(val))
                    return true;
                
                return false;
            }

            public bool IsLeaf()
            {
                return Left == null && Right == null;
            }
        }
    }
}
