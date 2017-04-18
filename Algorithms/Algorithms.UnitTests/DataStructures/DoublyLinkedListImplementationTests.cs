using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.UnitTests.DataStructures
{
    [TestClass]
    public class DoublyLinkedListImplementationTests
    {
        private DoublyLinkedListImplementation<int> cut = new DoublyLinkedListImplementation<int>();

        [TestMethod]
        public void ShouldReturnZeroAsSizeOfEmptyList()
        {
            Assert.AreEqual(0, cut.Size);
        }

        [TestMethod]
        public void ShouldReturnSizeOfNonEmptyList()
        {
            cut.AddAtStart(5);
            Assert.AreEqual(1, cut.Size);
        }

        [TestMethod]
        public void ShouldReturnItemByGivenIndex()
        {
            var firstlyAddedItem = 5;
            var secondlyAddedItem = 10;

            cut.AddAtStart(firstlyAddedItem);
            cut.AddAtStart(secondlyAddedItem);
           
            Assert.AreEqual(secondlyAddedItem, cut.GetElementByIndex(0));
            Assert.AreEqual(firstlyAddedItem, cut.GetElementByIndex(1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenIndexIsNegative()
        {
            cut.GetElementByIndex(-1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenIndexIsOutside()
        {
            cut.GetElementByIndex(5);
        }

        [TestMethod]
        public void ShouldAddElementAtEndOfNonEmptyList()
        {
            cut.AddAtStart(5);
            cut.AddAtEnd(10);

            Assert.AreEqual(10, cut.GetElementByIndex(1));
        }

        [TestMethod]
        public void ShouldAddElementAtEndOfEmptyList()
        {
            cut.AddAtEnd(5);
            Assert.AreEqual(5, cut.GetElementByIndex(0));
        }

        [TestMethod]
        public void ShouldTakeElementFromBeginOfOneElementList()
        {
            cut.AddAtStart(5);
            Assert.AreEqual(5, cut.TakeAtStart());
        }

        [TestMethod]
        public void ShouldTakeElementFromBeginOfMultipleElementsList()
        {
            cut.AddAtStart(5);
            cut.AddAtStart(10);
            Assert.AreEqual(10, cut.TakeAtStart());
        }

        [TestMethod]
        public void ShouldReturnDefaultTakenFromBeginOfEmptyList()
        {
            Assert.AreEqual(0, cut.TakeAtStart());
        }

        [TestMethod]
        public void ShouldTakeElementFromEndOfMultipleElementsList()
        {
            cut.AddAtStart(5);
            cut.AddAtStart(10);

            Assert.AreEqual(5, cut.TakeAtEnd());
        }

        [TestMethod]
        public void ShouldTakeElementFromEndOfOneElementList()
        {
            cut.AddAtStart(5);
            Assert.AreEqual(5, cut.TakeAtEnd());
        }

        [TestMethod]
        public void ShouldReturnDefaultTakenFromEndOfEmptyList()
        {
            Assert.AreEqual(0, cut.TakeAtEnd());
        }

        [TestMethod]
        public void ShouldReturnAllElementWithCorrectOrder()
        {
            cut.AddAtStart(5);
            cut.AddAtStart(4);
            cut.TakeAtStart();
            cut.AddAtEnd(6);
            cut.AddAtStart(10);
            cut.TakeAtEnd();

            CollectionAssert.AreEquivalent(new[] { 10, 5 }, cut.GetAll().ToList());
        }

        [TestMethod]
        public void ShouldInsertElementAtGivenIndexInListWithMultipleElements()
        {
            var insertionIndex = 1;
            var element = 100;

            cut.AddAtStart(5);
            cut.AddAtStart(4);

            cut.InsertAt(insertionIndex, element);

            CollectionAssert.AreEquivalent(new[] {4, 100, 5 }, cut.GetAll().ToList());
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenInsertAtOutOfRangeIndex()
        {
            var insertionIndex = 10;
            var element = 100;

            cut.AddAtStart(5);
            cut.InsertAt(insertionIndex, element);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenInsertAtNegativeIndex()
        {
            var insertionIndex = -10;
            var element = 100;
            
            cut.InsertAt(insertionIndex, element);
        }

        [TestMethod]
        public void ShouldReturnEmptyListWhenGetAllFromEmptyList()
        {
            CollectionAssert.AreEquivalent(new List<int>(), cut.GetAll().ToList());
        }
    }
}
