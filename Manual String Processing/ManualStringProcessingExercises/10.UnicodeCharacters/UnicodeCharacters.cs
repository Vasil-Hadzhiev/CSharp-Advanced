using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.UnicodeCharacters
{
    public class UnicodeCharacters
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var output = new StringBuilder();

            for (int i = 0; i < input.Length; i++)
            {
                var currentChar = Convert.ToInt32(input[i]);
                var unicode = "\\u" + currentChar.ToString("x4");
                output.Append(unicode);
            }

            Console.WriteLine(output);
        }
    }
}
