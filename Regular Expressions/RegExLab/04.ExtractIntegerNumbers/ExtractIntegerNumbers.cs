using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _04.ExtractIntegerNumbers
{
    public class ExtractIntegerNumbers
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"\d{1,}";

            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var currentMatch = match.Groups[0].Value;
                Console.WriteLine(currentMatch);
            }
        }
    }
}
