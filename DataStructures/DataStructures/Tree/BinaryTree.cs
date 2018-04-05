using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;

namespace DataStructures.Tree
{
    public class BinaryTree<T> where T : IComparable<T>
    {
        private BTNode<T> _root;
        public int Size { get; private set; }

        public BinaryTree()
        {
            this._root = null;
        }

        public List<T> InOrder()
        {
            return InOrder(this._root, new List<T>());
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
            if (this._root == null)
            {
                this._root = new BTNode<T>(val);
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

            // Tree has no nodes
            if (parent == null)
                return;

            // Child is either:
            //      == to parent if val == Root
            //      left or right child of parent otherwise
            var child = parent;
            bool? isLeft = null;
            if (parent.Left != null && parent.Left.Value.Equals(val))
            {
                child = parent.Left;
                isLeft = true;
            }
            else if (parent.Right != null && parent.Right.Value.Equals(val))
            {
                child = parent.Right;
                isLeft = false;
            }

            // if child == parent and doesn't equal val, then the val doesn't exist
            if (!child.Value.Equals(val))
                return;

            // alias for child, to make more logical sense
            var toRemove = child;

            // replaceParent either null, if toRemove.Right == null
            // or toRemove.Right if toRemove.Right has no left child
            // or left most child of toRemove.Right
            var replaceParent = FindSmallestParent(toRemove.Right);
            var replace = replaceParent;

            // either one right child, or two children
            if (replaceParent != null)
            {
                // there is an actual parent that has a left child
                if (replaceParent.Left != null)
                {
                    replace = replaceParent.Left;
                    replaceParent.Left = replace.Right;
                }
                // otherwise the parent and child are the same
            }
            else
            {
                // there is no right child to promote, so we need to do the left
                // only happens if one left child exists
                replace = toRemove.Left;
            }

            // set the parent's child
            if (isLeft == null)
                this._root = replace;
            else if ((bool) isLeft)
                parent.Left = replace;
            else
                parent.Right = replace;

            // if node is not a leaf, we need to make sure all the children are preserved
            if (replace != null)
            {
                replace.Right = toRemove.Right;
                if (toRemove.Left != null && !toRemove.Left.Value.Equals(replace.Value))
                    replace.Left = toRemove.Left;
            }

            // if we reach here, the remove was successful and we decrement the stored size
            this.Size--;
        }

        public int Height(T val)
        {
            var node = FindNode(val);

            return node.Height;
        }

        public int Depth(T val)
        {
            var node = FindNode(val);

            return node.Height;
        }

        private void UpdateNode(T val)
        {
            var node = FindNode(val);
            node.Height = CalculateHeight(node);
            node.Depth = CalculateDepth(node.Value);
        }

        private int CalculateDepth(T val)
        {
            var depth = 0;
            var curr = this._root;
            if (curr == null)
                throw new ArgumentException("the tree is empty");

            while (curr != null && !curr.Value.Equals(val))
            {
                depth++;
                if (val.CompareTo(curr.Value) < 0)
                    curr = curr.Left;
                else
                    curr = curr.Right;
            }
            
            if (curr == null)
                throw new ArgumentException("tree does not contain val: " + val.ToString());

            return depth;
        }

        private int CalculateHeight(T val)
        {
            var node = FindNode(val);

            return CalculateHeight(node);
        }

        private int CalculateHeight(BTNode<T> node)
        {
            if (node == null)
                return -1;
            
            return Math.Max(CalculateHeight(node.Left), CalculateHeight(node.Right));
        }

        // returns:
        //  null:   search is null
        //  search: when search has no left children
        //  BTNode: furthest left child of search otherwise
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
        //      Root:   when the value searched is the Root
        //      BTNode: when parent where child is found OR would be found if it existed
        // **NOTE: does not provide info on whether the value exists or not
        private BTNode<T> FindParent(T val)
        {
            var current = this._root;
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
            
            throw new ArgumentException("the tree contains no nodes");
        }

        // returns the node we are looking for
        // returns:
        //    null:    when Root is null
        //    null:    when the node is not found
        //    BTNode:  when the node is found
        private BTNode<T> FindNode(T val)
        {
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

            if (child == null)
                throw new ArgumentException("the tree does not contain the node: " + val.ToString());

            return child;
        }

        protected class BTNode<T> where T : IComparable<T>
        {
            public T Value { get; set; }
            public BTNode<T> Left { get; set; }
            public BTNode<T> Right { get; set; }
            public int Height { get; set; }
            public int Depth { get; set; }

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
