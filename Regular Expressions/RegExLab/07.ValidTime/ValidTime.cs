using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidTime
{
    public class ValidTime
    {
        public static void Main()
        {
            var pattern = @"(([0][0-9])|([1][0-2]))\:([0-5][0-9])\:([0-5][0-9])\s(AM|PM)";

            var regex = new Regex(pattern);

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                if (regex.Match(inputLine).Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
            }
        }
    }
}
