using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MatrixOfPalindromes
{
    public class MatrixOfPalindromes
    {
        public static void Main()
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            var matrixTokens = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var rows = matrixTokens[0];
            var cols = matrixTokens[1];

            var matrix = new string[rows, cols];

            var palindrome = string.Empty;

            var count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    palindrome = alphabet[row] + "" + alphabet[col + count] + ""  + alphabet[row];
                    matrix[row, col] = palindrome;
                }
                count++;
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row,col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
