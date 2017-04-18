using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Algorithms;
using Algorithms.DataStructures;

namespace Algorithms.UnitTests.Algorithms
{
    [TestClass]
    public class FindNodeFromEndOfLinkedListTests
    {
        [TestMethod]
        public void ShouldReturn5thElementFromTheEndOfList()
        {
            var cut = new FindNodeFromEndOfLinkedList<int>();

            SinglyLinkedNode<int> n = new SinglyLinkedNode<int>(1)
            {
                Next = new SinglyLinkedNode<int>(2)
                {
                    Next = new SinglyLinkedNode<int>(8)
                    {
                        Next = new SinglyLinkedNode<int>(3)
                        {
                            Next = new SinglyLinkedNode<int>(7)
                            {
                                Next = new SinglyLinkedNode<int>(0)
                                {
                                    Next = new SinglyLinkedNode<int>(4)
                                }
                            }
                        }
                    }
                }
            };

            Assert.AreEqual(8,cut.Find(n, 5));
        }
    }
}
