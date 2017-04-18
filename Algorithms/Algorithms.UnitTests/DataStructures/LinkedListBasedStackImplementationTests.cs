using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;

namespace Algorithms.UnitTests.DataStructures
{
    [TestClass]
    public class LinkedListBasedStackImplementationTests
    {
        private LinkedListBasedStackImplementation<int> cut = new LinkedListBasedStackImplementation<int>();

        [TestMethod]
        public void ShouldReturnZeroAsSizeOfEmptyStack()
        {
            Assert.AreEqual(0, cut.CurrentSize);
        }

        [TestMethod]
        public void ShouldReturnSizeOfStackWhenPushed()
        {
            cut.Push(10);
            Assert.AreEqual(1, cut.CurrentSize);
        }

        [TestMethod]
        public void ShouldReturnSizeOfStackWhenPoped()
        {
            cut.Push(10);
            cut.Push(100);
            cut.Pop();
            Assert.AreEqual(1, cut.CurrentSize);
        }

        [TestMethod]
        public void ShouldReturnPushedElementToEmptyStack()
        {
            cut.Push(5);

            Assert.AreEqual(5, cut.Pop());
        }

        [TestMethod]
        public void ShouldReturnPushedElementsToNonEmptyStack()
        {
            cut.Push(5);
            cut.Push(50);
            Assert.AreEqual(50, cut.Pop());
            Assert.AreEqual(5, cut.Pop());
        }

        [TestMethod]
        public void ShouldReturnPeekElement()
        {
            cut.Push(5);
            Assert.AreEqual(5, cut.Peek());
        }

        [TestMethod]
        public void ShouldNotDecreaseSizeOfStackWhenPeekItem()
        {
            cut.Push(5);
            cut.Push(5400);

            var sizeBeforePeek = cut.CurrentSize;

            cut.Peek();

            Assert.AreEqual(sizeBeforePeek, cut.CurrentSize);
        }

        [TestMethod]
        public void ShouldReturnWholeStack()
        {
            cut.Push(1);
            cut.Push(2);
            cut.Push(4);

            CollectionAssert.AreEquivalent(new[] { 4, 2, 1 }, cut.GetAll());

            cut.Pop();
            CollectionAssert.AreEquivalent(new[] { 2, 1 }, cut.GetAll());

            cut.Pop();
            CollectionAssert.AreEquivalent(new[] { 1 }, cut.GetAll());

            cut.Pop();
            CollectionAssert.AreEquivalent(null, cut.GetAll());
        }
    }
}
