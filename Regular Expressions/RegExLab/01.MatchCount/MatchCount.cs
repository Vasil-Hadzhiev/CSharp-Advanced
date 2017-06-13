using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _01.MatchCount
{
    public class MatchCount
    {
        public static void Main()
        {
            var pattern = Console.ReadLine();

            var text = Console.ReadLine();

            var count = Regex.Matches(text, pattern).Count;

            Console.WriteLine(count);
        }
    }
}
