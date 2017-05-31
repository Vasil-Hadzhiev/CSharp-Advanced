using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalSum
{
    public class MaximalSum
    {
        public static void Main()
        {
            var matrixTokens = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var rows = matrixTokens[0];
            var cols = matrixTokens[1];

            var matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var numbers = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();

                matrix[row] = numbers;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentNumber = numbers[col];
                    matrix[row][col] = currentNumber;
                }
            }

            var maximumSum = int.MinValue;
            var rowIndex = 0;
            var colIndex = 0;

            for (int row = 0; row < rows - 2; row++)
            {
                for (int col = 0; col < cols - 2; col++)
                {
                    var currentSum =
                        matrix[row][col] +
                        matrix[row][col + 1] +
                        matrix[row][col + 2] +
                        matrix[row + 1][col] +
                        matrix[row + 1][col + 1] +
                        matrix[row + 1][col + 2] +
                        matrix[row + 2][col] +
                        matrix[row + 2][col + 1] +
                        matrix[row + 2][col + 2];

                    if (currentSum > maximumSum)
                    {
                        maximumSum = currentSum;
                        rowIndex = row;
                        colIndex = col;
                    }
                }
            }

            Console.WriteLine($"Sum = {maximumSum}");

            for (int i = rowIndex; i < rowIndex + 3; i++)
            {
                for (int j = colIndex; j < colIndex + 3; j++)
                {
                    Console.Write($"{matrix[i][j]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
