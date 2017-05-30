using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SumMatrixElements
{
    public class SumMatrixElements
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

            var totalSum = 0;

            foreach (var item in matrix)
            {
                totalSum += item;
            }

            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(totalSum);
        }
    }
}
