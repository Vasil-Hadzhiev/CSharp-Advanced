using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _10.UseYourChainsBuddy
{
    public class UseYourChainsBuddy
    {
        public static void Main()
        {
            byte[] inputBuffer = new byte[4096];
            Stream inputStream = Console.OpenStandardInput(inputBuffer.Length);
            Console.SetIn(new StreamReader(inputStream, Console.InputEncoding, false, inputBuffer.Length));

            var firstHalf = "abcdefghijklm";
            var secondHalf = "nopqrstuvwxyz";

            var text = Console.ReadLine();

            var result = string.Empty;

            var pattern = @"<p>(.+?)<\/p>";

            var regex = new Regex(pattern);

            var matches = regex.Matches(text);

            foreach (Match match in matches)
            {
                var currentMatch = match.Groups[1].Value;

                for (int i = 0; i < currentMatch.Length; i++)
                {
                    var currentChar = currentMatch[i];

                    if (!char.IsDigit(currentChar) && !char.IsLower(currentChar))
                    {
                        currentMatch = currentMatch.Replace(currentChar, ' ');
                    }
                }

                currentMatch = Regex.Replace(currentMatch, @"\s+", " ");
                var decryptedWord = string.Empty;

                for (int i = 0; i < currentMatch.Length; i++)
                {
                    var currentChar = currentMatch[i];
                    var index = 0;

                    if (firstHalf.Contains(currentChar))
                    {
                        index = firstHalf.IndexOf(currentChar);
                        decryptedWord += secondHalf[index];
                    }
                    else if (secondHalf.Contains(currentChar))
                    {
                        index = secondHalf.IndexOf(currentChar);
                        decryptedWord += firstHalf[index];
                    }
                    else
                    {
                        decryptedWord += currentChar;
                    }
                }

                result += decryptedWord;
            }

            Console.WriteLine(result);
        }
    }
}
