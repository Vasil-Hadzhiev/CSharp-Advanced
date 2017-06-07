using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseString
{
    public class ReverseString
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var charArray = input.ToCharArray();
            Array.Reverse(charArray);

            var output = new string(charArray);
            Console.WriteLine(output);
        }
    }
}
