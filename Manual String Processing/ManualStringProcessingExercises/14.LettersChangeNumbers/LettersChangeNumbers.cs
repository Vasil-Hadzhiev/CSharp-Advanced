using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.LettersChangeNumbers
{
    public class LettersChangeNumbers
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().
                Split(new char[] { ' ', '\t' },
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var alphabet = "abcdefghijklmnopqrstuvwxyz";

            var sum = 0d;

            for (int i = 0; i < tokens.Length; i++)
            {
                var currentToken = tokens[i];
                var number = double.Parse(currentToken.Substring(1, currentToken.Length - 2));
                var firstLetter = currentToken[0];
                var lastLetter = currentToken[currentToken.Length - 1];

                var position = alphabet.IndexOf(firstLetter.ToString().ToLower()) + 1;

                if (char.IsUpper(firstLetter))
                {
                    number /= position;
                }
                else
                {
                    number *= position;
                }

                position = alphabet.IndexOf(lastLetter.ToString().ToLower()) + 1;

                if (char.IsUpper(lastLetter))
                {
                    number -= position;
                }
                else
                {
                    number += position;
                }

                sum += number;
            }

            Console.WriteLine($"{sum:f2}");
        }
    }
}
