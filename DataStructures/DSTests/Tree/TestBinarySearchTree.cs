﻿using NUnit.Framework;
using DataStructures.Tree;
using System.Collections.Generic;
using System;

namespace DSTests.Tree
{
    [TestFixture]
    class TestBinarySearchTree
    {

        private BinarySearchTree<int> SetupTree()
        {
            var testTree = new BinarySearchTree<int>();
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
            var testTree = new BinarySearchTree<int>();
            var initialSize = testTree.Size;
            Assert.AreEqual(0, initialSize);

            testTree.Insert(4);
            var oneSize = testTree.Size;
            Assert.AreEqual(1, oneSize);

            testTree.Insert(2);
            var twoSize = testTree.Size;
            Assert.AreEqual(2, twoSize);
        }

        [Test]
        public void TestContains()
        {
            var testTree = new BinarySearchTree<int>();
            var hasOne = testTree.Contains(1);
            Assert.AreEqual(false, hasOne);

            testTree.Insert(1);
            var hasOneAfterInsert = testTree.Contains(1);
            Assert.AreEqual(true, hasOneAfterInsert);
        }

        [Test]
        public void TestRemoveRoot()
        {
            var testTree = new BinarySearchTree<int>();
            var initialSize = testTree.Size;
            var initialContains = testTree.Contains(4);
            Assert.AreEqual(0, initialSize);
            Assert.AreEqual(false, initialContains);

            testTree.Insert(4);
            var oneSize = testTree.Size;
            var fourContains = testTree.Contains(4);
            Assert.AreEqual(1, oneSize);
            Assert.AreEqual(true, fourContains);

            testTree.Remove(4);
            var twoSize = testTree.Size;
            var fourContainsAfterRemove = testTree.Contains(4);
            Assert.AreEqual(0, twoSize);
            Assert.AreEqual(false, fourContainsAfterRemove);
        }
        
        [Test]
        public void TestRemove1()
        {
            var testTree = SetupTree();
            var initialSize = testTree.Size;
            var toRemove = 1;

            testTree.Remove(toRemove);
            var newSize = testTree.Size;
            var newContains = testTree.Contains(toRemove);
            Assert.AreEqual(initialSize - 1, newSize);
            Assert.AreEqual(false, newContains);
        }
        
        [Test]
        public void TestRemove2()
        {
            var testTree = SetupTree();
            var initialSize = testTree.Size;
            var toRemove = 2;

            testTree.Remove(toRemove);
            var newSize = testTree.Size;
            var newContains = testTree.Contains(toRemove);
            Assert.AreEqual(initialSize - 1, newSize);
            Assert.AreEqual(false, newContains);
        }

        [Test]
        public void TestRemove3()
        {
            var testTree = SetupTree();
            var initialSize = testTree.Size;
            var toRemove = 3;

            testTree.Remove(toRemove);
            var newSize = testTree.Size;
            var newContains = testTree.Contains(toRemove);
            Assert.AreEqual(initialSize - 1, newSize);
            Assert.AreEqual(false, newContains);
        }
        
        [Test]
        public void TestRemove4()
        {
            var testTree = SetupTree();
            var initialSize = testTree.Size;
            var toRemove = 4;

            testTree.Remove(toRemove);
            var newSize = testTree.Size;
            var newContains = testTree.Contains(toRemove);
            Assert.AreEqual(initialSize - 1, newSize);
            Assert.AreEqual(false, newContains);
        }
        
        [Test]
        public void TestRemove5()
        {
            var testTree = SetupTree();
            var initialSize = testTree.Size;
            var toRemove = 5;

            testTree.Remove(toRemove);
            var newSize = testTree.Size;
            var newContains = testTree.Contains(toRemove);
            Assert.AreEqual(initialSize - 1, newSize);
            Assert.AreEqual(false, newContains);
        }
        
        [Test]
        public void TestRemove6()
        {
            var testTree = SetupTree();
            var initialSize = testTree.Size;
            var toRemove = 6;

            testTree.Remove(toRemove);
            var newSize = testTree.Size;
            var newContains = testTree.Contains(toRemove);
            Assert.AreEqual(initialSize - 1, newSize);
            Assert.AreEqual(false, newContains);
        }
        
        [Test]
        public void TestRemove7()
        {
            var testTree = SetupTree();
            var initialSize = testTree.Size;
            var toRemove = 7;

            testTree.Remove(toRemove);
            var newSize = testTree.Size;
            var newContains = testTree.Contains(toRemove);
            Assert.AreEqual(initialSize - 1, newSize);
            Assert.AreEqual(false, newContains);
        }

        [Test]
        public void TestInOrder()
        {
            var testTree = SetupTree();
            var result = testTree.InOrder();

            var expected = new List<int>();
            for (var i = 1; i <= 7; i++)
            {
                expected.Add(i);
            }

            Assert.AreEqual(expected, result);
        }
    }
}
