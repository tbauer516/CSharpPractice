using System;
using System.Collections.Generic;

namespace DataStructures.Tree
{
    public class AVLTree<T> : SelfBalancingBinarySearchTree<T> where T : IComparable<T>
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
                Root = RemoveNode(parent);
            else if (parent.Left != null && parent.Left.Value.Equals(val))
                parent.Left = RemoveNode((AVLNode<T>) parent.Left);
            else if (parent.Right != null && parent.Right.Value.Equals(val))
                parent.Right = RemoveNode((AVLNode<T>) parent.Right);

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
                return (AVLNode<T>) RemoveFromRight(node);

            return (AVLNode<T>) RemoveFromLeft(node);
        }

        protected override BTNode<T> RemoveFromLeft(BTNode<T> node)
        {
            // Assumption: we know that node.Left is not null from the RemoveNode() method
            var replacement = base.RemoveFromLeft(node);

            CorrectHeight((AVLNode<T>) replacement.Left, (AVLNode<T>) replacement);

            return replacement;
        }

        protected override BTNode<T> RemoveFromRight(BTNode<T> node)
        {
            // Assumption: we know that node.Right is not null from the RemoveNode() method
            var replacement = base.RemoveFromRight(node);

            CorrectHeight((AVLNode<T>) replacement.Right, (AVLNode<T>) replacement);

            return replacement;
        }

        protected override BTNode<T> RotateRight(BTNode<T> node)
        {
            var newRoot = base.RotateRight(node);

            ((AVLNode<T>) newRoot.Right).Height = CalculateHeight((AVLNode<T>) newRoot.Right);
            ((AVLNode<T>) newRoot).Height = CalculateHeight((AVLNode<T>) newRoot);

            return newRoot;
        }

        protected override BTNode<T> RotateLeft(BTNode<T> node)
        {
            var newRoot = base.RotateLeft(node);

            ((AVLNode<T>)newRoot.Left).Height = CalculateHeight((AVLNode<T>)newRoot.Left);
            ((AVLNode<T>)newRoot).Height = CalculateHeight((AVLNode<T>)newRoot);

            return newRoot;
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
                return (AVLNode<T>) RotateRight(node);
            }
            else if (bal > 1)
            {
                var right = (AVLNode<T>) node.Right;
                var rightBal = CalculateBalance(right);
                if (rightBal < 0)
                    node.Right = RotateRight(right);
                return (AVLNode<T>) RotateLeft(node);
            }

            return node;
        }

        private void CorrectHeight(AVLNode<T> node)
        {
            CorrectHeight((AVLNode<T>) Root, node);
        }

        private void CorrectHeight(AVLNode<T> top, AVLNode<T> bottom)
        {
            if (top == null || bottom == null)
                return;
            
            var parentChain = base.GetParentChain(top, bottom);
            parentChain.Push(bottom);

            while (parentChain.Count > 0)
            {
                var parent = (AVLNode<T>) parentChain.Pop();

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