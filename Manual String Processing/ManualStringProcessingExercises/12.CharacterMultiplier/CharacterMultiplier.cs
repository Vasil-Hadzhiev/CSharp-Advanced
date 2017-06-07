using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CharacterMultiplier
{
    public class CharacterMultiplier
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split();

            var firstString = input[0];
            var secondString = input[1];

            var totalSum = 0;

            if (firstString.Length > secondString.Length)
            {
                for (int i = 0; i < secondString.Length; i++)
                {
                    totalSum += Convert.ToInt32(firstString[i]) * Convert.ToInt32(secondString[i]);
                }

                for (int i = secondString.Length; i < firstString.Length; i++)
                {
                    totalSum += Convert.ToInt32(firstString[i]);
                }
            }
            else if (firstString.Length < secondString.Length)
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    totalSum += Convert.ToInt32(firstString[i]) * Convert.ToInt32(secondString[i]);
                }

                for (int i = firstString.Length; i < secondString.Length; i++)
                {
                    totalSum += Convert.ToInt32(secondString[i]);
                }
            }
            else
            {
                for (int i = 0; i < firstString.Length; i++)
                {
                    totalSum += Convert.ToInt32(firstString[i]) * Convert.ToInt32(secondString[i]);
                }
            }

            Console.WriteLine(totalSum);
        }
    }
}
