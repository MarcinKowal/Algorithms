using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Algorithms.UnitTests
{
    [TestClass]
    public class MaxStackImplementationTests
    {
       
        [TestMethod]
        public void ShouldReturnMaxItemFromStackWhenPush()
        {
           var cut = new MaxStackImplementation<int>(5);


            cut.Push(4);
            Assert.AreEqual(4, cut.Max());

            cut.Push(2);
            Assert.AreEqual(4, cut.Max());

            cut.Push(14);
            Assert.AreEqual(14, cut.Max());

            cut.Push(1);
            Assert.AreEqual(14, cut.Max());

            cut.Push(18);
            Assert.AreEqual(18, cut.Max());

        }

        [TestMethod]
        public void ShouldReturnMaxItemFromStackWhenPop()
        {
            var items = new List<int> { 4, 2, 14, 1, 18 };
            var cut = new MaxStackImplementation<int>(items.Capacity);
            items.ForEach(item => cut.Push(item));

          
            cut.Pop(); //18
            Assert.AreEqual(14, cut.Max());

            cut.Pop(); //1
            Assert.AreEqual(14, cut.Max());

            cut.Pop(); //14
            Assert.AreEqual(4, cut.Max());

            cut.Pop(); //2
            Assert.AreEqual(4, cut.Max());

        }

        [TestMethod]
        public void ShouldReturnMaxItemFromStackWhenPopWithDuplicatedItems()
        {
            var items = new List<int> { 4, 2, 14, 1, 14};
            var cut = new MaxStackImplementation<int>(items.Capacity);
            items.ForEach(item => cut.Push(item));


            cut.Pop(); //14
            Assert.AreEqual(14, cut.Max());

            cut.Pop(); //1
            Assert.AreEqual(14, cut.Max());

            cut.Pop(); //14
            Assert.AreEqual(4, cut.Max());

            cut.Pop(); //2
            Assert.AreEqual(4, cut.Max());

        }
    }
}
