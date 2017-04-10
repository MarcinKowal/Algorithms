using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Strings;

namespace Algorithms.UnitTests.Strings
{
    [TestClass]
    public class AtoiTests
    {
        [TestMethod]
        public void ShouldReturnPositiveIntegerFromString()
        {
            var intput = "1234";

            Assert.AreEqual(1234, intput.Atoi());
        }

        [TestMethod]
        public void ShouldReturnNegativeIntegerFromString()
        {
            var intput = "-1234";

            Assert.AreEqual(-1234, intput.Atoi());
        }
    }
}
