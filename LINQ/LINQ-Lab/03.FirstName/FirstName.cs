using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FirstName
{
    public class FirstName
    {
        public static void Main()
        {
            var names = Console.ReadLine().
                Split();

            var letters = Console.ReadLine().
                Split().
                OrderBy(n => n).
                ToArray();

            var winnerName = string.Empty;

            foreach (var letter in letters)
            {
                winnerName = names.
                    Where(n => n.ToLower().StartsWith(letter.ToLower())).
                    FirstOrDefault();

                if (winnerName != null)
                {
                    break;
                }
            }

            if (winnerName == null)
            {
                Console.WriteLine("No match");
            }
            else
            {
                Console.WriteLine(winnerName);
            }
        }
    }
}
