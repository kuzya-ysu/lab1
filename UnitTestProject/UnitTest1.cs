using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyQueueClass;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CountShouldBeZeroAfterQueueCreation()
        {
            var Queue = new MyQueue<int>();
            Assert.AreEqual(0, Queue.Count);
        }

        [TestMethod]
        public void CountIncreasedAfterEnqueueing()
        {
            var Queue = new MyQueue<int>();
            Queue.Enqueue(1);
            Assert.AreEqual(1, Queue.Count);
        }

        [TestMethod]
        public void ItemExistsAfterEnqueueing()
        {
            var Queue = new MyQueue<int>();
            Queue.Enqueue(1);
            Assert.AreEqual(Queue[0], 1);
        }

        [TestMethod]
        public void CountIncreasedAfterRangeEnqueueing()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                Queue.Enqueue(i);
            }
            Assert.AreEqual(100, Queue.Count);
        }

        [TestMethod]
        public void ItemsExistAfterRangeEnqueueing()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                Queue.Enqueue(i);
            }
            for (int i = 0; i < n; i++)
            {
                Assert.AreEqual(i, Queue.Dequeue());
            }
        }

        [TestMethod]
        public void CountDecreasesAfterDequeueing()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                Queue.Enqueue(i);
            }
            Queue.Dequeue();
            Assert.AreEqual(Queue.Count, n-1);
        }

        [TestMethod]
        public void ItemDoesntExistAfterDequeueing()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int n = 100;
            for (int i = 1; i < n + 1; i++)
            {
                Queue.Enqueue(i);
            }
            Queue.Dequeue();
            Assert.AreEqual(Queue[0], 0);
        }
        [TestMethod]
        public void ItemInRightOrder()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int n = 4;
            for (int i = 1; i < n + 1; i++)
            {
                Queue.Enqueue(i);
            }
            Queue.Dequeue();
            Queue.Dequeue();
            Queue.Enqueue(n+1);
            Queue.Enqueue(n+2);
            for (int i = 3; i < n + 3; i++)
            {
                Assert.AreEqual(i, Queue.Dequeue());
            }
            
        }

        [TestMethod]
        public void PeekReturnsCorrectValue()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int n = 100;
            for (int i = 0; i < n; i++)
            {
                Queue.Enqueue(i);
            }
            Queue.Dequeue();
            Assert.AreEqual(Queue.Peek(), 1);
        }

        [TestMethod]
        public void ContainsReturnsCorrectValue()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int n = 50;
            bool[] Contains = new bool[100];
            for (int i = 0; i < 50; i++)
            {
                Contains[i] = true;
            }
            for (int i = 0; i < n; i++)
            {
                Queue.Enqueue(i);
            }
            for (int i = 0; i < 100; i++)
            {
                Assert.AreEqual(Contains[i], Queue.Contains(i));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ExceptionInCapacityConstructorWorksCorrectly()
        {
            MyQueue<int> Queue = new MyQueue<int>(-4);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ExceptionInCollectionConstructorWorksCorrectly()
        {
            int[] array = null;
            MyQueue<int> Queue = new MyQueue<int>(array);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInDequeueMethodWorksCorrectly()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            Queue.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ExceptionInPeekMethodWorksCorrectly()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            Queue.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionInGetIndexatorWorksCorrectly()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            int a = Queue[-1];
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ExceptionInSetIndexatorWorksCorrectly()
        {
            MyQueue<int> Queue = new MyQueue<int>();
            Queue[-1] = 5;
        }
    }
}