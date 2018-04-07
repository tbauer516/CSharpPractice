using System;

namespace DataStructures.Tree
{
    public class BinarySearchTree<T> : BinaryTree<T> where T : IComparable<T>
    {
        public override T Insert(T val)
        {
            var newNode = new BTNode<T>(val);
            
            if (Root == null)
            {
                Root = newNode;
                Size++;
                return val;
            }

            var parent = FindParent(val);
            if (parent.HasChild(val))
                return val;

            if (val.CompareTo(parent.Value) < 0)
                parent.Left = newNode;
            else
                parent.Right = newNode;

            Size++;
            return val;
        }

        public override T Remove(T val)
        {
            var parent = FindParent(val);

            // Tree has no nodes
            if (parent == null)
                return default(T);

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
                return default(T);

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
                Root = replace;
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
            Size--;
            return val;
        }
    }
}