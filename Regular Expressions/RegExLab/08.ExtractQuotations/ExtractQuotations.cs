using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractQuotations
{
    public class ExtractQuotations
    {
        public static void Main()
        {
            var pattern = @"'(.+?)'|" + "\"(.+?)\"";

            var text = Console.ReadLine();

            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match item in matches)
            {
                var currentMatch = item.Groups[0].Value;
                currentMatch = currentMatch.Substring(1, currentMatch.Length - 2);
                Console.WriteLine(currentMatch);
            }
        }
    }
}
