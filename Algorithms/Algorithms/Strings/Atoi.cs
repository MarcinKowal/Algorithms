using System.Linq;

namespace Algorithms.Strings
{
    public static partial class StringExtensions
    {
        public static int Atoi(this string text)
        {
            int value = 0;
            int sign;
            var tmpText = text;   
            
            if (text.First().Equals('-'))
            {
                sign = -1;
                tmpText = text.Substring(1);
            }
            else
            {
                sign = 1;
            }

            foreach (var character in tmpText)
            {
                value = value * 10 + character - '0';
            }

            return value*sign;
        }
    }
}
