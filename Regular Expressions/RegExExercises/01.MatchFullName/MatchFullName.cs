using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchFullName
{
    public class MatchFullName
    {
        public static void Main()
        {
            var pattern = @"^[A-Z][a-z]+\s[A-Z][a-z]+";

            var regex = new Regex(pattern);

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "end")
                {
                    break;
                }

                var matches = regex.Matches(inputLine);

                foreach (Match match in matches)
                {
                    Console.WriteLine(match.Groups[0].Value);
                }
            }

        }
    }
}
