using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Tree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private BTNode<T> Root;
        public int Size { get; private set; }

        public BinaryTree()
        {
            this.Root = null;
        }

        public List<T> InOrder()
        {
            return InOrder(this.Root, new List<T>());
        }

        private List<T> InOrder(BTNode<T> current, List<T> ReturnList)
        {
            if (current == null)
                return ReturnList;

            InOrder(current.Left, ReturnList);
            ReturnList.Add(current.Value);
            InOrder(current.Right, ReturnList);
            return ReturnList;
        }

        public bool Contains(T val)
        {
            var parent = FindParent(val);
            return parent != null && ( parent.Value.Equals(val) || parent.HasChild(val) );
        }

        public void Insert(T val)
        {
            if (this.Root == null)
            {
                this.Root = new BTNode<T>(val);
                this.Size++;
                return;
            }

            var parent = FindParent(val);
            if (parent.HasChild(val))
                return;

            var newNode = new BTNode<T>(val);
            if (val.CompareTo(parent.Value) < 0)
                parent.Left = newNode;
            else
                parent.Right = newNode;
            this.Size++;
        }

        public void Remove(T val)
        {
            var parent = FindParent(val);
            if (parent == null || !parent.HasChild(val))
                return;

            var child = parent.Left;
            var isLeftChild = true;
            if (parent.Right != null && parent.Right.Value.Equals(val))
            {
                child = parent.Right;
                isLeftChild = false;
            }

            // TODO: implement the 2 child scenario
            // Node has 2 children
            if (child.Left != null && child.Right != null)
            {
                var replaceParent = FindSmallestParent(child.Right);
                if (replaceParent.Value.Equals(child.Right.Value))
                {
                    // Do same as when only 1 right child
                    if (isLeftChild)
                        parent.Left = child.Right;
                    else
                        parent.Right = child.Right;
                    return;
                }
            }

            // Node has 1 left child
            if (child.Left != null && child.Right == null)
            {
                if (isLeftChild)
                    parent.Left = child.Left;
                else
                    parent.Right = child.Left;
                return;
            }

            // Node has 1 right child
            if (child.Left == null && child.Right != null)
            {
                if (isLeftChild)
                    parent.Left = child.Right;
                else
                    parent.Right = child.Right;
                return;
            }

            // Node has 0 children
            if (child.IsLeaf())
            {
                if (isLeftChild)
                    parent.Left = null;
                else
                    parent.Right = null;
                return;
            }
        }

        private BTNode<T> FindSmallestParent(BTNode<T> search)
        {
            var current = search;
            while (current != null && current.Left != null)
            {
                if (current.Left.Left == null)
                    break;

                current = current.Left;
            }
            return current;
        }

        // returns the parent of the node of the value being searched for
        // returns:
        //      null:   when Root is null
        //      BTNode: when parent where child is found OR would be found if it existed
        // **NOTE: does not provide info on whether the value exists or not
        private BTNode<T> FindParent(T val)
        {
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

                if (nextChild == null)
                    return current;

                current = nextChild;
            }
            return null;
        }

        public class BTNode<T> where T : IComparable<T>
        {
            public T Value { get; set; }
            public BTNode<T> Left { get; set; }
            public BTNode<T> Right { get; set; }

            public BTNode(T val)
            {
                this.Value = val;
            }

            public bool HasChild(T val)
            {
                if (this.Right != null && this.Right.Value.Equals(val))
                    return true;
                if (this.Left != null && this.Left.Value.Equals(val))
                    return true;
                return false;
            }

            public bool IsLeaf()
            {
                return this.Left == null && this.Right == null;
            }
        }
    }
}
