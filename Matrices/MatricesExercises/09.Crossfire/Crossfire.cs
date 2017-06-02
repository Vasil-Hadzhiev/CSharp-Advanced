using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Crossfire
{
    public class Crossfire
    {
        public static void Main()
        {
            var matrixTokens = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            var rows = matrixTokens[0];
            var cols = matrixTokens[1];

            var matrix = new int[rows][];

            FillMatrix(matrix, rows, cols);

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "Nuke it from orbit")
                {
                    break;
                }

                var fireParams = inputLine.
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

                var impactRow = fireParams[0];
                var impactCol = fireParams[1];
                var radius = fireParams[2];

                DestroyCells(matrix, impactRow, impactCol, radius, rows);
                matrix = ResizeMatrix(rows, matrix);
            }

            PrintMatrix(matrix, rows);
        }

        private static void FillMatrix(int[][] matrix, int rows, int cols)
        {
            var count = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = count;
                    count++;
                }
            }
        }

        private static void DestroyCells(int[][] matrix, int impactRow, int impactCol, int radius, int rows)
        {
            var lastRow = 0;
            var firstRow = 0;

            if (impactRow + radius >= rows)
            {
                lastRow = rows - 1;
            }
            else
            {
                lastRow = impactRow + radius;
            }

            if (impactRow - radius < 0)
            {
                firstRow = 0;
            }
            else
            {
                firstRow = impactRow - radius;
            }

            for (int row = firstRow; row <= lastRow; row++)
            {
                if (matrix[row].Length < impactCol)
                {
                    continue;
                }
                matrix[row][impactCol] = 0;
            }

            var firstCol = 0;
            var lastCol = 0;

            if (impactCol + radius >= matrix[impactRow].Length)
            {
                lastCol = matrix[impactRow].Length - 1;
            }
            else
            {
                lastCol = impactRow + radius;
            }

            if (impactCol - radius < 0)
            {
                firstCol = 0;
            }
            else
            {
                firstCol = impactCol - radius;
            }

            for (int col = firstCol; col <= lastCol; col++)
            {
                matrix[impactRow][col] = 0;
            }
        }

        private static int[][] ResizeMatrix(int rows, int[][] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        var updateCol = col;
                        while (updateCol < matrix[row].Length - 1)
                        {
                            updateCol++;
                            if (matrix[row][updateCol] != 0)
                            {
                                matrix[row][col] = matrix[row][updateCol];
                                matrix[row][updateCol] = 0;
                                break;
                            }
                        }
                    }
                }
            }

            var newMatrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                var index = Array.IndexOf(matrix[row], 0);

                if (index >= 0)
                {
                    newMatrix[row] = new int[index];
                    for (int col = 0; col < newMatrix[row].Length; col++)
                    {
                        newMatrix[row][col] = matrix[row][col];
                    }
                }
                else
                {
                    newMatrix[row] = new int[matrix[row].Length];
                    for (int col = 0; col < newMatrix[row].Length; col++)
                    {
                        newMatrix[row][col] = matrix[row][col];
                    }
                }
            }

            return newMatrix;
        }

        private static void PrintMatrix(int[][] matrix, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                if (matrix[row].Length == 0)
                {
                    continue;
                }
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
