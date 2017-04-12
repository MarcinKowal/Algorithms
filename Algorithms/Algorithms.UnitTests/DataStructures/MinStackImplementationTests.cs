using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.UnitTests.Stack
{
    [TestClass]
    public class MinStackImplementationTests
    {
        [TestMethod]
        public void ShouldReturnMinItemFromStackWhenPush()
        {
            var cut = new MinStackImplementation<int>(5);


            cut.Push(4);
            Assert.AreEqual(4, cut.Min());

            cut.Push(2);
            Assert.AreEqual(2, cut.Min());

            cut.Push(14);
            Assert.AreEqual(2, cut.Min());

            cut.Push(1);
            Assert.AreEqual(1, cut.Min());

            cut.Push(18);
            Assert.AreEqual(1, cut.Min());

        }
       
        [TestMethod]
        public void ShouldReturnMinItemFromStackWhenPop()
        {
            var items = new List<int> { 4, 2, 14, 1, 18 };
            var cut = new MinStackImplementation<int>(items.Capacity);
            items.ForEach(item => cut.Push(item));


            cut.Pop(); //18
            Assert.AreEqual(1, cut.Min());

            cut.Pop(); //1
            Assert.AreEqual(2, cut.Min());

            cut.Pop(); //14
            Assert.AreEqual(2, cut.Min());

            cut.Pop(); //2
            Assert.AreEqual(4, cut.Min());

        }
    }
}
