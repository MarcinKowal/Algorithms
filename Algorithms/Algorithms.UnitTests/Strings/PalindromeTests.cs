using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Algorithms.Strings;

namespace Algorithms.UnitTests.Strings
{
    [TestClass]
    public class PalindromeTests
    {
        [TestMethod]
        public void ShouldReturnTrueForPalindromeMultipleWords()
        {
            var text = "no lemon, no melon";

            // act & assert
            Assert.IsTrue(text.IsPalindrome());
        }

        [TestMethod]
        public void ShouldReturnTrueForPalindromeSingleWord()
        {
            var text = "sedes";

            // act & assert
            Assert.IsTrue(text.IsPalindrome());
        }

        [TestMethod]
        public void ShouldReturnFalseForNonPalindromeMultipleWord()
        {
            var text = "this is not palindrome sentence";

            // act & assert
            Assert.IsFalse(text.IsPalindrome());
        }
    }
}
