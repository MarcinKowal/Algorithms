using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Algorithms;
using Algorithms.DataStructures;
using System.Linq;

namespace Algorithms.UnitTests.Algorithms
{
    [TestClass]
    public class MergeTwoSinglyLinkedListsTests
    {
        [TestMethod]
        public void ShouldMergeTwoLists()
        {
            var cut = new MergeTwoSinglyLinkedLists();
            var firstList = new SinglyLinkedNode<int>
            {
                Data = 2,
                Next = new SinglyLinkedNode<int>
                {
                    Data = 6,
                    Next = new SinglyLinkedNode<int>
                    {
                        Data = 18,
                    }
                }
            };

            var secondList = new SinglyLinkedNode<int>
            {
                Data = 1,
                Next = new SinglyLinkedNode<int>
                {
                    Data = 3,
                    Next = new SinglyLinkedNode<int>
                    {
                        Data = 17,
                        Next = new SinglyLinkedNode<int>
                        {
                            Data = 19,
                        }
                    }
                }
            };
            
            var mergedList = cut.Merge(firstList, secondList);
            CollectionAssert.AreEquivalent(new[] { 1, 2, 3, 6, 17, 18, 19 }, mergedList.GetAll().ToList());
        }
    }
}
