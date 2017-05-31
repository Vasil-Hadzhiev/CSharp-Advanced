using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.DiagonalDifference
{
    public class DiagonalDifference
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new double[n, n];

            for (int row = 0; row < n; row++)
            {
                var numbers = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(double.Parse).
                    ToArray();

                for (int col = 0; col < numbers.Length; col++)
                {
                    var currentNumber = numbers[col];
                    matrix[row, col] = currentNumber;
                }
            }

            var primaryDiagonalSum = 0d;
            var secondayDiagonalSum = 0d;

            var cols = 0;

            for (int row = 0; row < n; row++)
            {
                primaryDiagonalSum += matrix[row, cols];
                cols++;
            }

            cols--;

            for (int row = 0; row < n; row++)
            {
                secondayDiagonalSum += matrix[row, cols];
                cols--;
            }

            Console.WriteLine(Math.Abs(primaryDiagonalSum - secondayDiagonalSum));
        }
    }
}
