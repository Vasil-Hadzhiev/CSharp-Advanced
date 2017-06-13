using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _02.MatchPhoneNumber
{
    public class MatchPhoneNumber
    {
        public static void Main()
        {
            var pattern = @"^\+359(\s|-)2\1\d{3}\1\d{4}$";

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
