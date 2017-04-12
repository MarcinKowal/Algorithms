using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Strings;
namespace Algorithms.UnitTests.Strings
{
    [TestClass]
    public class AnagramsTests
    {
        [TestMethod]
        public void ShouldReturnAnagrams()
        {
            var input = new[] { "cat", "act", "asdf", "who", "how" };
            var cut = new Anagrams();
            var anagrams = cut.Find(input);

            Assert.AreEqual(4, anagrams.Count);
            Assert.IsTrue(anagrams.Contains("cat"));
            Assert.IsTrue(anagrams.Contains("act"));
            Assert.IsTrue(anagrams.Contains("who"));
            Assert.IsTrue(anagrams.Contains("how"));
        }
    }
}
