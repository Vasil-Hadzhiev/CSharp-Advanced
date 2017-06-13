using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace _05.ExtractTags
{
    public class ExtractTags
    {
        public static void Main()
        {
            var pattern = @"<.+?>";

            var regex = new Regex(pattern);

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "END")
                {
                    break;
                }

                var matches = regex.Matches(inputLine);

                foreach (Match match in matches)
                {
                    var tag = match.Groups[0].Value;

                    Console.WriteLine(tag);
                }
            }
        }
    }
}
