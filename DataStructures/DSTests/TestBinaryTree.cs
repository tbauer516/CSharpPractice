using System;
using NUnit.Framework;
using DataStructures.Tree;

namespace DSTests
{
    [TestFixture]
    class TestBinaryTree
    {

        private BinaryTree<int> SetupTree()
        {
            var testTree = new BinaryTree<int>();
            testTree.Insert(4);
            testTree.Insert(3);
            testTree.Insert(1);
            testTree.Insert(2);
            testTree.Insert(6);
            testTree.Insert(5);
            testTree.Insert(7);
            return testTree;
        }

        [Test]
        public void TestInsert()
        {
            var testTree = new BinaryTree<int>();
            var initialSize = testTree.Size;
            Assert.AreEqual(initialSize, 0);

            testTree.Insert(4);
            var oneSize = testTree.Size;
            Assert.AreEqual(oneSize, 1);

            testTree.Insert(2);
            var twoSize = testTree.Size;
            Assert.AreEqual(twoSize, 2);
        }

        [Test]
        public void TestContains()
        {
            var testTree = new BinaryTree<int>();
            var hasOne = testTree.Contains(1);
            Assert.AreEqual(hasOne, false);

            testTree.Insert(1);
            var hasOneAfterInsert = testTree.Contains(1);
            Assert.AreEqual(hasOneAfterInsert, true);
        }

        [Test]
        public void TestRemove()
        {
            var testTree = new BinaryTree<int>();
            var initialSize = testTree.Size;
            var initialContains = testTree.Contains(1);
            Assert.AreEqual(initialSize, 0);
            Assert.AreEqual(initialContains, false);

            testTree.Insert(4);
            var oneSize = testTree.Size;
            var fourContains = testTree.Contains(4);
            Assert.AreEqual(oneSize, 1);
            Assert.AreEqual(fourContains, true);

            testTree.Remove(4);
            var twoSize = testTree.Size;
            var fourContainsAfterRemove = testTree.Contains(4);
            Assert.AreEqual(twoSize, 0);
            Assert.AreEqual(fourContainsAfterRemove, false);
        }

        [Test]
        public void TestInOrder()
        {
            var testTree = SetupTree();
            var result = testTree.InOrder();

            var expected = new System.Collections.Generic.List<int>();
            for (var i = 1; i < 8; i++)
            {
                expected.Add(i);
            }

            Assert.AreEqual(expected, result);
        }
    }
}
