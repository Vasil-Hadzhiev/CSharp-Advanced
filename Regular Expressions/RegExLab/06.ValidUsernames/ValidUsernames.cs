using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _06.ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var pattern = @"^[A-z-_0-9]{3,16}$";

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
