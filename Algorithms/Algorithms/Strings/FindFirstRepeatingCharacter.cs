using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Strings
{
    public static partial class StringExtensions
    {
        public static char? FindFirstRepeatingChar(this string text)
        {
            var dict = new Dictionary<char, uint>();

            foreach (var character in text)
            {

                if (dict.TryGetValue(character, out uint value))
                {
                    dict[character] = ++value;
                }
                else
                {
                    dict.Add(character, 1);
                }
            }

            if (dict.Any(c => c.Value > 1))
            {
                return dict.FirstOrDefault(c => c.Value > 1).Key;
            }
            return null;
        }
    }
}
