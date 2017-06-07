using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.Palindromes
{
    public class Palindromes
    {
        public static void Main()
        {
            var text = Console.ReadLine().
                Split(new char[] { ' ', ',', '.', '!', '?' },
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var palindromes = new SortedSet<string>();

            for (int i = 0; i < text.Length; i++)
            {
                var currentWord = text[i];
                var charArray = currentWord.ToArray();
                Array.Reverse(charArray);
                var reversedWord = new string(charArray);

                if (reversedWord == currentWord)
                {
                    palindromes.Add(currentWord);
                }
            }

            Console.WriteLine("[{0}]",
                string.Join(", ", palindromes));
        }
    }
}
