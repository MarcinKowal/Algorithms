using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class StackImplementationTests
    {

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenSizeOfStackIsNegative()
        {
            new ListBasedStackImplementation<int>(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldThrowExceptionWhenSizeOfStackIsZero()
        {
            new ListBasedStackImplementation<int>(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionWhenPopOnEmptyStack()
        {
            var cut = new ListBasedStackImplementation<int>(1);
            var item = cut.Pop();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ShouldThrowExceptionWhenPeekOnEmptyStack()
        {
            var cut = new ListBasedStackImplementation<int>(1);
            var item = cut.Peek();
        }

        [TestMethod]
        [ExpectedException(typeof(StackOverflowException))]
        public void ShouldThrowExceptionWhenPushOnExceededSize()
        {
            var cut = new ListBasedStackImplementation<int>(1);

            cut.Push(3);
            cut.Push(12);
        }

        [TestMethod]
        public void ShouldReturnItemsInRevertedOrderThanWasInserted()
        {
            var items = new List<int> { 18, 5, -6, 36, 48 };
            var expectedList = new List<int>(items);
            expectedList.Reverse();

            var cut = new ListBasedStackImplementation<int>(items.Capacity);


            items.ForEach(item => cut.Push(item));

            expectedList.ForEach(expectedItem => { Assert.AreEqual(expectedItem, cut.Pop()); });
        }

        [TestMethod]
        public void ShouldReturnZeroWhenStackIsEmpty()
        {
            var cut = new ListBasedStackImplementation<int>(10);

            Assert.AreEqual(0, cut.CurrentSize);
        }

        [TestMethod]
        public void ShouldReturnDifferentSizeWhenPush()
        {
            var cut = new ListBasedStackImplementation<int>(10);
            var items = new List<int> { 18, 5, -6, 36, 48 };

            for (int i = 0; i < items.Count; i++)
            {
                cut.Push(items[i]);
                Assert.AreEqual(i + 1, cut.CurrentSize);

            }
        }

        [TestMethod]
        public void ShouldReturnDifferentSizeWhenPop()
        {
            var cut = new ListBasedStackImplementation<int>(10);
            var items = new List<int> { 18, 5, -6, 36, 48 };

            items.ForEach(item => cut.Push(item));

            var size = cut.CurrentSize;
            do
            {
                cut.Pop();
                size--;
                Assert.AreEqual(size, cut.CurrentSize);
            }
            while (size > 0);
        }

        [TestMethod]
        public void ShouldReturnSameSizeWhenPeek()
        {
            var cut = new ListBasedStackImplementation<int>(10);
            var items = new List<int> { 18, 5, -6, 36, 48 };

            items.ForEach(item => cut.Push(item));

            foreach (var item in items)
            {
                Assert.AreEqual(items.Last(), cut.Peek());
                Assert.AreEqual(items.Count, cut.CurrentSize);
            }
        }
    }
}
