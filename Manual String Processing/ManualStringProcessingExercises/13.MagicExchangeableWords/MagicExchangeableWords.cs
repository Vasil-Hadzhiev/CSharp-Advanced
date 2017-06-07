using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.MagicExchangeableWords
{
    public class MagicExchangeableWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().Split();

            var firstWord = words[0];
            var secondWord = words[1];

            var dict = new Dictionary<char, char>();
            var isExchangeable = true;

            if (firstWord.Length == secondWord.Length)
            {
                for (int i = 0; i < firstWord.Length; i++)
                {
                    if (!dict.ContainsKey(firstWord[i]))
                    {
                        dict[firstWord[i]] = secondWord[i];                      
                    }

                    if (dict[firstWord[i]] != secondWord[i])
                    {
                        isExchangeable = false;
                        break;
                    }
                }
            }
            else
            {
                var shorterWord = firstWord;
                var longerWord = secondWord;

                if (firstWord.Length > secondWord.Length)
                {
                    shorterWord = secondWord;
                    longerWord = firstWord;
                }

                for (int i = 0; i < shorterWord.Length; i++)
                {
                    if (!dict.ContainsKey(longerWord[i]))
                    {
                        dict[longerWord[i]] = shorterWord[i];
                    }

                    if (dict[longerWord[i]] != shorterWord[i])
                    {
                        isExchangeable = false;
                        break;
                    }
                }

                if (isExchangeable)
                {
                    for (int i = shorterWord.Length; i < longerWord.Length; i++)
                    {
                        if (!dict.ContainsKey(longerWord[i]))
                        {
                            isExchangeable = false;
                            break;
                        }
                    }
                }
            }

            if (isExchangeable)
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine("false");
            }
        }
    }
}
