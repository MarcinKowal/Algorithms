using Algorithms.DataStructures;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace Algorithms.UnitTests.DataStructures
{
    [TestClass]
    public class CircularBufferImplementationTests
    {
        [TestMethod]
        public void ShouldReturnGivenItem()
        {
            var buffer = new CircularBufferImplementation<int>(1);
            var item = 5;
        
            buffer.Add(5);

            CollectionAssert.AreEquivalent(new[] { item }, buffer.GetAll().ToList());
        }

        [TestMethod]
        public void ShouldReturnMultipleItemsNotExceedingBufferSize()
        {
            var buffer = new CircularBufferImplementation<int>(2);
            var item1 = 5;
            var item2 = 10;

            buffer.Add(item1);
            buffer.Add(item2);
        
            CollectionAssert.AreEquivalent(new[] { item1, item2 }, buffer.GetAll().ToList());
        }

        [TestMethod]
        public void ShouldReturnItemsWhenExceedingBufferSize()
        {
            var buffer = new CircularBufferImplementation<int>(1);
            var item1 = 5;
            var item2 = 10;

            buffer.Add(item1);
            buffer.Add(item2);
            CollectionAssert.AreEquivalent(new[] { item2 }, buffer.GetAll().ToList());
        }
    }
}
