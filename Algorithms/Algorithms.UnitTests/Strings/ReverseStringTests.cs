using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Strings;

namespace Algorithms.UnitTests.Strings
{
    [TestClass]
    public class ReverseStringTests
    {
        [TestMethod]
        public void ShouldReverseString()
        {
            var input = "marcin";
            var output = "nicram";

            // act
            var receivedString = input.Reverse();

            // assert
            Assert.AreEqual(output, receivedString);

        }
    }
}
