using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
    public class AVLTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        public override T Insert(T val)
        {
            var newNode = new AVLNode<T>(val);
            base.Insert(newNode);
            
            CorrectHeight(newNode);
            
            return val;
        }

        public override T Remove(T val)
        {
            var parent = (AVLNode<T>) FindParent(val);
            if (parent == null)
                throw new ArgumentException("val of " + val.ToString() + " does not exist");

            if (parent.Value.Equals(val))
            {
                Root = RemoveNode(parent);
            }
            else if (parent.Left != null && parent.Left.Value.Equals(val))
            {
                parent.Left = RemoveNode((AVLNode<T>) parent.Left);
            }
            else if (parent.Right != null && parent.Right.Value.Equals(val))
            {
                parent.Right = RemoveNode((AVLNode<T>) parent.Right);
            }

            Size--;
            
            CorrectHeight(parent);

            return val;
        }

        private AVLNode<T> RemoveNode(AVLNode<T> node)
        {
            var left = (AVLNode<T>) node.Left;
            var right = (AVLNode<T>) node.Right;
            
            if (left == null && right == null)
                return null;

            if (left == null || right.Height > left.Height)
                return RemoveFromRight(node);

            return RemoveFromLeft(node);
        }

        private AVLNode<T> RemoveFromLeft(AVLNode<T> node)
        {
            // Assumption: we know that node.Left is not null from the RemoveNode() method
            
            var leftChild = node.Left;
            var largestP = base.FindSmallestParent(leftChild);
            var largest = largestP.Right;
            var replacement = largest;

            if (largest != null)
            {
                largestP.Right = largest.Left;
                largest.Left = leftChild;
            }
            else
            {
                replacement = leftChild;
            }

            replacement.Right = node.Right;
            
            CorrectHeight((AVLNode<T>) replacement, (AVLNode<T>) largestP);

            return (AVLNode<T>) replacement;
        }

        private AVLNode<T> RemoveFromRight(AVLNode<T> node)
        {
            // Assumption: we know that node.Right is not null  from the RemoveNode() method
            
            var rightChild = node.Right;
            var smallestP = base.FindSmallestParent(rightChild);
            var smallest = smallestP.Left;
            var replacement = smallest;

            if (smallest != null)
            {
                smallestP.Left = smallest.Right;
                smallest.Right = rightChild;
            }
            else
            {
                replacement = rightChild;
            }

            replacement.Left = node.Left;
            
            CorrectHeight((AVLNode<T>) replacement, (AVLNode<T>) smallestP);

            return (AVLNode<T>) replacement;
        }

        private AVLNode<T> RotateRight(AVLNode<T> node, bool recurse = true)
        {
            // returns:
            //    node:        when a rotation is not possible
            //    newParent:   when the rotation is complete

            var left = (AVLNode<T>) node.Left;

            if (left == null)
                return node;
            
            var tempChild = left.Right;
            left.Right = node;
            node.Left = tempChild;

            node.Height = CalculateHeight(node);
            left.Height = CalculateHeight(left);
            
            return left;
        }
        
        private AVLNode<T> RotateLeft(AVLNode<T> node, bool recurse = true)
        {
            // returns:
            //    node:        when a rotation is not possible
            //    newParent:   when the rotation is complete

            var right = (AVLNode<T>) node.Right;

            if (right == null)
                return node;

            var tempChild = right.Left;
            right.Left = node;
            node.Right = tempChild;

            node.Height = CalculateHeight(node);
            right.Height = CalculateHeight(right);
            
            return right;
        }

        private AVLNode<T> CheckRotation(AVLNode<T> node)
        {
            var bal = CalculateBalance(node);
            if (bal < -1)
            {
                var left = (AVLNode<T>) node.Left;
                var leftBal = CalculateBalance(left);
                if (leftBal > 0)
                    node.Left = RotateLeft(left);
                return RotateRight(node);
            }
            else if (bal > 1)
            {
                var right = (AVLNode<T>) node.Right;
                var rightBal = CalculateBalance(right);
                if (rightBal < 0)
                    node.Right = RotateRight(right);
                return RotateLeft(node);
            }

            return node;
        }

        private Stack<AVLNode<T>> GetParentChain(AVLNode<T> node)
        {
            return GetParentChain((AVLNode<T>) Root, node);
        }

        private Stack<AVLNode<T>> GetParentChain(AVLNode<T> parent, AVLNode<T> child)
        {
            var chain = new Stack<AVLNode<T>>();
            var current = parent;

            while (current != null && !current.Value.Equals(child.Value))
            {
                chain.Push(current);

                if (child.Value.CompareTo(current.Value) < 0)
                    current = (AVLNode<T>) current.Left;
                else if (child.Value.CompareTo(current.Value) > 0)
                    current = (AVLNode<T>) current.Right;
                else
                    break;
            }

            return chain;
        }

        private void CorrectHeight(AVLNode<T> node)
        {
            CorrectHeight((AVLNode<T>) Root, node);
        }

        private void CorrectHeight(AVLNode<T> top, AVLNode<T> bottom)
        {
            if (top == null || bottom == null)
                return;
            
            var parentChain = GetParentChain(top, bottom);
            parentChain.Push(bottom);

            while (parentChain.Count > 0)
            {
                var parent = parentChain.Pop();

                if (parent.Left != null)
                    parent.Left = CheckRotation((AVLNode<T>) parent.Left);

                if (parent.Right != null)
                    parent.Right = CheckRotation((AVLNode<T>) parent.Right);

                parent.Height = CalculateHeight(parent);
            }

            if (!top.Equals(Root))
                return;
            
            Root = CheckRotation((AVLNode<T>) Root);
        }

        private int CalculateHeight(AVLNode<T> node)
        {
            if (node == null)
                throw new NullReferenceException("node does not exist");

            var left = (AVLNode<T>) node.Left;
            var leftHeight = -1;
            if (left != null)
                leftHeight = left.Height;

            var right = (AVLNode<T>) node.Right;
            var rightHeight = -1;
            if (right != null)
                rightHeight = right.Height;

            return 1 + Math.Max(leftHeight, rightHeight);
        }

        private int CalculateBalance(AVLNode<T> node)
        {
            if (node == null)
                throw new NullReferenceException("node does not exist");

            var left = (AVLNode<T>) node.Left;
            var leftHeight = -1;
            if (left != null)
                leftHeight = left.Height;

            var right = (AVLNode<T>) node.Right;
            var rightHeight = -1;
            if (right != null)
                rightHeight = right.Height;

            return rightHeight - leftHeight;
        }

        protected class AVLNode<T> : BTNode<T> where T : IComparable<T>
        {
            public int Height { get; set; }

            public AVLNode(T val) : base(val)
            {
                Height = 0;
            }
        }
    }
}