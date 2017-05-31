using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._2x2SquaresInMatrix
{
    public class SquaresInMatrix
    {
        public static void Main()
        {
            var matrixTokens = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var rows = matrixTokens[0];
            var cols = matrixTokens[1];

            var matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var matrixCharacters = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(char.Parse).
                    ToArray();

                for (int col = 0; col < matrixCharacters.Length; col++)
                {
                    matrix[row, col] = matrixCharacters[col];
                }
            }

            var count = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    if (matrix[row, col] == matrix[row, col+1] &&
                        matrix[row, col] == matrix[row + 1, col] &&
                        matrix[row, col] == matrix[row + 1, col + 1])
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine(count);
        }
    }
}
