using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StringLength
{
    public class StringLength
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            text = text.PadRight(20, '*');

            Console.WriteLine(text);
        }
    }
}
