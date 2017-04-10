using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms.Strings
{
    public static partial class StringExtensions
    {
        public static string Reverse(this string text)
        {
            var chars = text.ToArray();
            var leftIndex = 0;
            var rightIndex = text.Length - 1;

          
            while (leftIndex < rightIndex)
            {
                var temp = chars[leftIndex];
                chars[leftIndex] = chars[rightIndex];
                chars[rightIndex] = temp;

                leftIndex++;
                rightIndex--;
            }

            return new string(chars);
        }
    }
}
