using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.PascalTriangle
{
    public class PascalTriangle
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new long[n][];

            var count = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new long[count];
                var currentRow = matrix[i];

                matrix[i][0] = 1;
                matrix[i][count - 1] = 1;

                for (int j = 1; j < currentRow.Length - 1; j++)
                {
                    matrix[i][j] = matrix[i - 1][j - 1] + matrix[i - 1][j];
                }

                count++;
            }

            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
