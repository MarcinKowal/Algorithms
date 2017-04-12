using System.Collections.Generic;
using System.Linq;

namespace Algorithms.Strings
{
    public class Anagrams
    {
        public ICollection<string> Find(IEnumerable<string> wordsCollection)
        {
            var dict = new Dictionary<string, string>();
            var outList = new List<string>();

            foreach (var word in wordsCollection)
            {
                var sortedWord = new string(word.OrderBy(c => c).ToArray());
                if (!dict.ContainsKey(sortedWord))
                {
                    dict.Add(sortedWord, word);
                }
                else
                {
                    var value = dict[sortedWord];
                    value = value + " " + word;
                    dict[sortedWord] = value;
                }
            }

            foreach (var item in dict.Values)
            {
                var parsedValues = item.Split(' ');
                if (parsedValues.Count() > 1)
                {
                    outList.AddRange(parsedValues);
                }
            }

            return outList;
        }
    }
}
