using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _03.NonDigitCount
{
    public class NonDigitCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"[\D]";

            var regex = new Regex(pattern);

            var count = regex.Matches(text).Count;

            Console.WriteLine($"Non-digits: {count}");
        }
    }
}
