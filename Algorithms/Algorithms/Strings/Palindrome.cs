using System.Text;
using System.Collections.Generic;

namespace Algorithms.Strings
{
    public static partial class StringExtensions
    {
        public static bool IsPalindrome(this string text)
        {
            var stringBuilder = new StringBuilder();
            var list = new List<char>(text);

            list.ForEach(c => 
            {
                if (c != ' ')
                    stringBuilder.Append(c);
            });

            var convertedText = stringBuilder.ToString();
            var leftIndex = 0;
            var rightIndex = convertedText.Length - 1;

            while (leftIndex <= rightIndex)
            {
                if (convertedText[leftIndex++] != convertedText[rightIndex--])
                    return false;
            }

            return true;
        }
    }
}
