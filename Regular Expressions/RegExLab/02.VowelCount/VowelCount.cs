using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _02.VowelCount
{
    public class VowelCount
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var pattern = @"[AEIOUYaeiouy]";

            var count = Regex.Matches(text, pattern).Count;

            Console.WriteLine($"Vowels: {count}");
        }
    }
}
