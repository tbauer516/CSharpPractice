using NUnit.Framework;
using DataStructures.Queue;
using System.Collections.Generic;
using System;

namespace DSTests.Queue
{
    [TestFixture]
    class TestPriorityQueue
    {

        [Test]
        public void TestDeleteMin1()
        {
            var q = new PriorityQueue<string>();
            
            q.Insert("one", 8);
            q.Insert("two", 7);
            q.Insert("three", 6);
            q.Insert("four", 5);
            q.Insert("five", 4);
            q.Insert("six", 3);
            q.Insert("seven", 2);

            var actual = q.DeleteMin();
            var expected = "seven";
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeleteMin2()
        {
            var q = new PriorityQueue<string>();
            
            q.Insert("one", 1);
            q.Insert("two", 2);
            q.Insert("three", 3);
            q.Insert("four", 4);
            q.Insert("five", 5);
            q.Insert("six", 6);
            q.Insert("seven", 7);

            var actual = q.DeleteMin();
            var expected = "one";
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDeleteMin3()
        {
            var q = new PriorityQueue<string>();
            
            q.Insert("one", 3);
            q.Insert("two", 5);
            q.Insert("three", 4);
            q.Insert("four", 1);
            q.Insert("five", 2);
            q.Insert("six", 2);
            q.Insert("seven", 4);

            var actual = q.DeleteMin();
            var expected = "four";
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestDecreaseKey()
        {
            var q = new PriorityQueue<string>();

            var one = "one";
            
            q.Insert(one, 8);
            q.Insert("two", 7);

            q.DecreaseKey(one, 1);
            
            var actual = q.DeleteMin();
            var expected = "one";
            
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void TestIncreaseKey()
        {
            var q = new PriorityQueue<string>();

            var two = "two";
            
            q.Insert("one", 8);
            q.Insert(two, 7);

            q.IncreaseKey(two, 10);
            
            var actual = q.DeleteMin();
            var expected = "one";
            
            Assert.AreEqual(expected, actual);
        }
    }
}
