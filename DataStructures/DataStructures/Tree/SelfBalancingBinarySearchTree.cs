using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.Tree
{
    public abstract class SelfBalancingBinarySearchTree<T> : BinarySearchTree<T> where T : IComparable<T>
    {
        protected virtual BTNode<T> RemoveFromLeft(BTNode<T> node)
        {
            if (node == null || node.Left == null)
                return null;

            var leftChild = node.Left;
            var largestP = base.FindLargestParent(leftChild);
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

            node.Left = null;
            node.Right = null;

            return replacement;
        }

        protected virtual BTNode<T> RemoveFromRight(BTNode<T> node)
        {
            if (node == null || node.Right == null)
                return null;

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

            node.Left = null;
            node.Right = null;

            return replacement;
        }

        protected virtual BTNode<T> RotateRight(BTNode<T> node)
        {
            // returns:
            //    node:        when a rotation is not possible
            //    newParent:   when the rotation is complete

            var left = node.Left;

            if (left == null)
                return node;

            var tempChild = left.Right;
            left.Right = node;
            node.Left = tempChild;

            return left;
        }

        protected virtual BTNode<T> RotateLeft(BTNode<T> node)
        {
            // returns:
            //    node:        when a rotation is not possible
            //    newParent:   when the rotation is complete

            var right = node.Right;

            if (right == null)
                return node;

            var tempChild = right.Left;
            right.Left = node;
            node.Right = tempChild;

            return right;
        }

        protected virtual Stack<BTNode<T>> GetParentChain(BTNode<T> node)
        {
            return GetParentChain(Root, node);
        }

        protected Stack<BTNode<T>> GetParentChain(BTNode<T> parent, BTNode<T> child)
        {
            var chain = new Stack<BTNode<T>>();
            var current = parent;

            while (current != null && !current.Value.Equals(child.Value))
            {
                chain.Push(current);

                if (child.Value.CompareTo(current.Value) < 0)
                    current = current.Left;
                else if (child.Value.CompareTo(current.Value) > 0)
                    current = current.Right;
                else
                    break;
            }

            return chain;
        }
    }
}
