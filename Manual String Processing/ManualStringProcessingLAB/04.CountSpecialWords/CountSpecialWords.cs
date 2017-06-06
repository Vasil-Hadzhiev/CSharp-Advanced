using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _04.CountSpecialWords
{
    public class CountSpecialWords
    {
        public static void Main()
        {
            var specialWords = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var text = Console.ReadLine().
                Split(new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var dict = new Dictionary<string, int>();

            for (int i = 0; i < specialWords.Length; i++)
            {
                var currentSpecialWord = specialWords[i];

                if (!dict.ContainsKey(currentSpecialWord))
                {
                    dict[currentSpecialWord] = 0;
                }

                for (int j = 0; j < text.Length; j++)
                {
                    if (text[j] == currentSpecialWord)
                    {
                        dict[currentSpecialWord]++;
                    }
                }
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }
}
