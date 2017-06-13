using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.SentenceExtractor
{
    public class SentenceExtractor
    {
        public static void Main()
        {
            var keyword = Console.ReadLine();

            var text = Console.ReadLine();

            var pattern = @"[\w\W]+?[.|?|!]";

            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var sentence = match.Groups[0].Value;

                if (sentence.Contains(keyword))
                {
                    Console.WriteLine(sentence);
                }
            }
        }
    }
}
