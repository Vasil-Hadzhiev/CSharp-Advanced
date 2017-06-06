using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.ConcatenateStrings
{
    public class ConcatenateStrings
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var text = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var currentString = Console.ReadLine();

                text.Append(currentString);
                text.Append(" ");
            }

            Console.WriteLine(text);
        }
    }
}
