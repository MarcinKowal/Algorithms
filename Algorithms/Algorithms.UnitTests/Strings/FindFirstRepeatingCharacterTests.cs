using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Strings;

namespace Algorithms.UnitTests.Strings
{
    [TestClass]
    public class FindFirstRepeatingCharacterTests
    {
        [TestMethod]
        public void ShouldReturnFirstRepeatingChar()
        {
            var input = "horizon tutorials";

            Assert.AreEqual('o', input.FindFirstRepeatingChar());
        }

        [TestMethod]
        public void ShouldReturnNullForNotRepeatingChars()
        {
            var input = "abcd";

            Assert.IsNull(input.FindFirstRepeatingChar());
        }
    }
}
