using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.DataStructures;
using Algorithms.Algorithms;
using System.Collections.Generic;

namespace Algorithms.UnitTests.Algorithms
{
    [TestClass]
    public class RemoveDuplicatesFromLinkedListTests
    {
        private RemoveDuplicatesFromLinkedList cut;

        [TestInitialize]
        public void Init()
        {
           cut = new RemoveDuplicatesFromLinkedList();
        }
        [TestMethod]
        public void ShouldReturnLinkedListWithoutDup()
        {
            var secondList = new SinglyLinkedNode<int>
            {
                Data = 1,
                Next = new SinglyLinkedNode<int>
                {
                    Data = 2,
                    Next = new SinglyLinkedNode<int>
                    {
                        Data = 2,
                        Next = new SinglyLinkedNode<int>
                        {
                            Data = 4,
                            Next = new SinglyLinkedNode<int>
                            {
                                Data = 3,
                                Next = new SinglyLinkedNode<int>
                                {
                                    Data = 3,
                                    Next = new SinglyLinkedNode<int>
                                    {
                                        Data = 2,
                                        Next = null
                                    }
                                }
                            }
                        }
                    }
                }
            };

            var currentNode = cut.RemoveDuplicates(secondList);
            var expectedList = new List<int> { 1, 2, 4, 3 };
            var index = 0;
            while (currentNode.Next != null)
            {
                Assert.AreEqual(expectedList[index++], currentNode.Data);
                currentNode = currentNode.Next;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ShouldThrowExceptionWhenHeadOfListIsNull()
        {
            var currentNode = cut.RemoveDuplicates<SinglyLinkedNode<int>>(null);
        }
    }
}
