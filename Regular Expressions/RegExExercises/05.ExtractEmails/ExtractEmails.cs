using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _05.ExtractEmails
{
    public class ExtractEmails
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var pattern = @"\b[a-z][a-z0-9-._]+@[a-z-]+\.[a-z]+[.a-z]+\b";

            var regex = new Regex(pattern);

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                var currentMatch = match.Groups[0].Value;
                Console.WriteLine(currentMatch);
            }
        }
    }
}
