using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BiggestSumOf2x2Matrix
{
    public class BiggestSumOf2x2Matrix
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().
                Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();

            var rows = tokens[0];
            var cols = tokens[1];

            var matrix = new int[rows, cols];

            for (int i = 0; i < rows; i++)
            {
                var numbers = Console.ReadLine().
                    Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();

                for (int j = 0; j < cols; j++)
                {
                    matrix[i, j] = numbers[j];
                }
            }

            var rowsIndex = 0;
            var colsIndex = 0;
            var maxSum = int.MinValue;

            for (int i = 0; i < rows - 1; i++)
            {
                for (int j = 0; j < cols - 1; j++)
                {
                    var currentSum = 
                        matrix[i, j] + 
                        matrix[i, j + 1] + 
                        matrix[i + 1, j] + 
                        matrix[i + 1, j + 1];

                    if (currentSum > maxSum)
                    {
                        maxSum = currentSum;
                        rowsIndex = i;
                        colsIndex = j;
                    }
                }
            }

            Console.WriteLine($"{matrix[rowsIndex, colsIndex]} {matrix[rowsIndex, colsIndex + 1]}");
            Console.WriteLine($"{matrix[rowsIndex + 1, colsIndex]} {matrix[rowsIndex + 1, colsIndex + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}
