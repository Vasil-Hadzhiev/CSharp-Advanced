using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.ReplaceTag
{
    public class ReplaceTag
    {
        public static void Main()
        {
            var pattern = @"(<a (href=.+?)>).+(<\/a>)";

            var regex = new Regex(pattern);

            var finalText = new StringBuilder();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "end")
                {
                    break;
                }

                var matches = regex.Matches(inputLine);

                foreach (Match match in matches)
                {
                    var firstTag = match.Groups[1].Value;
                    var href = match.Groups[2].Value;
                    var secondTag = match.Groups[3].Value;

                    inputLine = inputLine.Replace(firstTag, "[URL " + href + "]");
                    inputLine = inputLine.Replace(secondTag, "[/URL]");
                }

                finalText.AppendLine(inputLine);
            }

            Console.WriteLine(finalText);
        }
    }
}
