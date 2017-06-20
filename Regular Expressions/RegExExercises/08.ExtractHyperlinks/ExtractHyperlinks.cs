using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _08.ExtractHyperlinks
{
    public class ExtractHyperlinks
    {
        public static void Main()
        {
            var pattern = @"<a\s+[^>]*?href\s*=(.*?)>.*?<\s*\/\s*a\s*>";
            var input = Console.ReadLine();
            var sb = new StringBuilder();

            while (!input.Equals("END"))
            {
                sb.Append(input);
                input = Console.ReadLine();
            }

            var matches = Regex.Matches(sb.ToString(), pattern);

            foreach (Match match in matches)
            {
                var possibleHref = match.Groups[1].ToString().Trim();
                var result = string.Empty;

                if (possibleHref[0].Equals('"'))
                {
                    result = possibleHref.Split(new char[] { '"' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else if (possibleHref[0] == '\'')
                {
                    result = possibleHref.Split(new char[] { '\'' }, StringSplitOptions.RemoveEmptyEntries).First();
                }
                else
                {
                    result = possibleHref.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).First();
                }

                Console.WriteLine(result);
            }
        }
    }
}
