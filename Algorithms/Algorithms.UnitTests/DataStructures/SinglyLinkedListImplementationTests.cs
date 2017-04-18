using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using System.Linq;
using System.Collections.Generic;

namespace Algorithms.UnitTests.DataStructures
{
    [TestClass]
    public class SinglyLinkedListImplementationTests
    {
        private SinglyLinkedListImplementation<int> cut = new SinglyLinkedListImplementation<int>();

        [TestMethod]
        public void ShouldAddNodeAtBeginToEmptyList()
        {
            cut.AddAtStart(2);

            Assert.AreEqual(1, cut.Size);
        }
        
        [TestMethod]
        public void ShouldReturnNodeFromStart()
        {
            var element = 2;
            cut.AddAtStart(element);

            Assert.AreEqual(element, cut.GetElementByIndex(0));
        }

        [TestMethod]
        public void ShouldReturnNodeByIndex()
        {
            var firstElement = 2;
            var secondElement = 5;

            cut.AddAtStart(2);
            cut.AddAtStart(5);

            Assert.AreEqual(secondElement, cut.GetElementByIndex(0));
            Assert.AreEqual(firstElement, cut.GetElementByIndex(1));
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenIndexIsOutOfRange()
        {
            cut.GetElementByIndex(5);    
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenIndexIsNegative()
        {
            cut.GetElementByIndex(-5);
        }

        [TestMethod]
        public void ShouldReturnSizeOfNonEmptyList()
        {
            cut.AddAtStart(2);
            cut.AddAtStart(5);

            Assert.AreEqual(2, cut.Size);
        }

        [TestMethod]
        public void ShouldReturnSizeOfEmptyList()
        {
            Assert.AreEqual(0, cut.Size);
        }

        [TestMethod]
        public void ShouldAddNodeAtEndOfNonEmptyList()
        {
            cut.AddAtStart(2);
            cut.AddAtEnd(5);

            Assert.AreEqual(5, cut.GetElementByIndex(1));
        }

        [TestMethod]
        public void ShouldAddNodeAtEndOfEmptyList()
        {
            cut.AddAtEnd(5);

            Assert.AreEqual(5, cut.GetElementByIndex(0));
        }

        [TestMethod]
        public void ShouldAddNodeAtEndOfNonEmptyListMultipleTimes()
        {
            cut.AddAtEnd(5);
            cut.AddAtEnd(1);
            cut.AddAtEnd(10);

            Assert.AreEqual(5, cut.GetElementByIndex(0));
            Assert.AreEqual(1, cut.GetElementByIndex(1));
            Assert.AreEqual(10, cut.GetElementByIndex(2));
        }

        [TestMethod]
        public void ShouldRemoveElementAtBeginOfList()
        {
            cut.AddAtStart(2);
            cut.AddAtEnd(5);

            var takenValue = cut.TakeAtStart();

            Assert.AreEqual(2, takenValue);
            Assert.AreEqual(1, cut.Size);
        }

        [TestMethod]
        public void ShouldRemoveElementAtBeginOfListWithOneElement()
        {
            cut.AddAtEnd(5);

            var takenValue = cut.TakeAtStart();

            Assert.AreEqual(5, takenValue);
            Assert.AreEqual(0, cut.Size);
        }

        [TestMethod]
        public void ShouldReturnDefaultWhenRemoveElementAtBeginOfEmptyList()
        {
            var takenValue = cut.TakeAtStart();
            Assert.AreEqual(0, takenValue);
        }

        [TestMethod]
        public void ShouldTakeElementAtEndOfList()
        {
            cut.AddAtStart(2);
            cut.AddAtEnd(5);

            var takenValue = cut.TakeAtEnd();

            Assert.AreEqual(5, takenValue);
            Assert.AreEqual(1, cut.Size);
        }

        [TestMethod]
        public void ShouldTakeElementAtEndOfListWithOneElement()
        {
            cut.AddAtEnd(5);

            var takenValue = cut.TakeAtEnd();

            Assert.AreEqual(5, takenValue);
            Assert.AreEqual(0, cut.Size);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenInsertAtNegativeIndex()
        {
            cut.InsertAt(5, -1);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void ShouldThrowExceptionWhenInsertAtOutsideTheList()
        {
            var element = 5;
            var insertionIndex = 2;
            cut.InsertAt(element, insertionIndex);
        }

        [TestMethod]
        public void ShouldInsertElementAtTheMiddleOfList()
        {
            var element = 56;
            var insertionIndex = 1;

            cut.AddAtStart(1);
            cut.AddAtEnd(3);

            cut.InsertAt(element, insertionIndex);

            Assert.AreEqual(3, cut.Size);
            Assert.AreEqual(element, cut.GetElementByIndex(insertionIndex));
        }


        [TestMethod]
        public void ShouldReturnAllElementsWithCorrectOrder()
        {
            cut.AddAtEnd(3);
            cut.AddAtStart(1);
            cut.InsertAt(2, 1);

            CollectionAssert.AreEquivalent(new[] { 1, 2, 3 }, cut.GetAll().ToList());
        }

        [TestMethod]
        public void ShouldReturnEmptyListWhenGetAllOnEmptyList()
        {
            CollectionAssert.AreEquivalent(new List<int>(), cut.GetAll().ToList());
        }
    }
}
