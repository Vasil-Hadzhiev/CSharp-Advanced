using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.GroupNumbers
{
    public class GroupNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            var sizes = new int[3];
            var offsets = new int[3];

            for (int i = 0; i < numbers.Length; i++)
            {
                var reminder = 0;
                var currentNumber = numbers[i];
                if (currentNumber < 0)
                {
                    currentNumber *= -1;
                    reminder = currentNumber % 3;
                }
                else
                {
                    reminder = currentNumber % 3;
                }
                
                sizes[reminder]++;
            }

            int[][] matrix =
            {
                new int[sizes[0]],
                new int[sizes[1]],
                new int[sizes[2]]
            };

            for (int i = 0; i < numbers.Length; i++)
            {
                var reminder = 0;
                var currentNumber = numbers[i];
                if (currentNumber < 0)
                {
                    reminder = (currentNumber * -1) % 3;
                }
                else
                {
                    reminder = currentNumber % 3;
                }
                
                var index = offsets[reminder];
                matrix[reminder][index] = currentNumber;
                offsets[reminder]++;
            }


            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < sizes[i]; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
