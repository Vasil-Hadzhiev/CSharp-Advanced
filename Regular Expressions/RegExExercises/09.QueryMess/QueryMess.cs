using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _09.QueryMess
{
    public class QueryMess
    {
        public static void Main()
        {
            var query = new Dictionary<string, List<string>>();

            var whiteSpacePatternOne = @"(?:\+|%20)";
            var whiteSpacePatternTwo = @"\s+";

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                input = Regex.Replace(input, whiteSpacePatternOne, " ");
                input = Regex.Replace(input, whiteSpacePatternTwo, " ");

                var pairs = input.Split('&');

                Decode(pairs, query);

                foreach (var keyValuePair in query)
                {
                    Console.Write("{0}=[{1}]", 
                        keyValuePair.Key, string.Join(", ", keyValuePair.Value));
                }

                Console.WriteLine();
                query.Clear();
            }
        }

        private static void Decode(string[] pairs, Dictionary<string, List<string>> query)
        {
            foreach (var pair in pairs)
            {
                var properString = pair;
                var indexOfSeparator = pair.IndexOf('?');

                if (indexOfSeparator != -1)
                {
                    properString = properString.Substring(indexOfSeparator + 1);
                }

                var splitPair = properString.Split('=');
                var key = splitPair[0].Trim();
                var value = splitPair[1].Trim();

                if (!query.ContainsKey(key))
                {
                    query[key] = new List<string>();
                }
                query[key].Add(value);
            }
        }
    }
}
