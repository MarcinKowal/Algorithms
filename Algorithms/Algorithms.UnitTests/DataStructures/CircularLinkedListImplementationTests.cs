using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using System.Linq;

namespace Algorithms.UnitTests.DataStructures
{
    [TestClass]
    public class CircularLinkedListImplementationTests
    {
        private CircularLinkedListImplementation<int> cut = new CircularLinkedListImplementation<int>();

        [TestMethod]
        public void ShouldReturnZeroAsSizeOfEmptyList()
        {
            Assert.AreEqual(0, cut.Size);
        }

        [TestMethod]
        public void ShouldReturnSizeOfNonEmptyList()
        {
            cut.AddAtStart(10);
            Assert.AreEqual(1, cut.Size);
        }

        [TestMethod]
        public void ShouldReturnAllItemsWithCorrectOrder()
        {
            cut.AddAtStart(3);
            cut.AddAtEnd(10);

            CollectionAssert.AreEquivalent(new[] { 3, 10 }, cut.GetAll().ToList());
        }

        [TestMethod]
        public void ShouldTakeElementFromEndOfList()
        {
            cut.AddAtStart(3);
            cut.AddAtEnd(10);
            cut.AddAtStart(30);

            var receivedItem = cut.TakeAtEnd();
            Assert.AreEqual(10, receivedItem);
            Assert.AreEqual(2, cut.Size);
            CollectionAssert.AreEquivalent(new[] { 30, 3 }, cut.GetAll().ToList());

        }

        [TestMethod]
        public void ShouldTakeElementFromBeginOfList()
        {
            cut.AddAtStart(3);
            cut.AddAtEnd(10);
            cut.AddAtStart(30);

            var receivedItem = cut.TakeAtStart();
            Assert.AreEqual(30, receivedItem);
            Assert.AreEqual(2, cut.Size);
            CollectionAssert.AreEquivalent(new[] { 3, 10 }, cut.GetAll().ToList());

        }
    }
}
