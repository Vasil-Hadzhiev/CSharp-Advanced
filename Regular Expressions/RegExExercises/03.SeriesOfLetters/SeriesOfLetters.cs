using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _03.SeriesOfLetters
{
    public class SeriesOfLetters
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            Console.WriteLine(Regex.Replace(input, "(\\w)\\1+", "$1"));
        }
    }
}
