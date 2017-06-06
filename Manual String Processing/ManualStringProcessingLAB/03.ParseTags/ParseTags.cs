using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.ParseTags
{
    public class ParseTags
    {
        public static void Main()
        {
            var text = Console.ReadLine();

            var openingTag = "<upcase>";
            var closingTag = "</upcase>";

            while (true)
            {
                var openingTagIndex = text.IndexOf(openingTag);

                if (openingTagIndex == -1)
                {
                    break;
                }

                var closingTagIndex = text.IndexOf(closingTag);

                if (closingTagIndex == -1)
                {
                    break;
                }

                var currentText = text.Substring(openingTagIndex, closingTagIndex - openingTagIndex + closingTag.Length);

                var currentTextUpperCase = currentText
                    .Replace(openingTag, "")
                    .Replace(closingTag, "")
                    .ToUpper();

                text = text.Replace(currentText, currentTextUpperCase);
                openingTagIndex = text.IndexOf(openingTag);
            }

            Console.WriteLine(text);
        }
    }
}
