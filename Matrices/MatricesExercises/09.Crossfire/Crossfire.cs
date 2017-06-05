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
                Split().
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

                var nukeParams = inputLine.
                    Split().
                    Select(int.Parse).
                    ToArray();

                var impactRow = nukeParams[0];
                var impactCol = nukeParams[1];
                var radius = nukeParams[2];

                NukeMatrix(matrix, impactRow, impactCol, radius, rows);
                matrix = ResizeMatrix(matrix, rows);
            }
            PrintMatrix(matrix);
        }

        private static void FillMatrix(int[][] matrix, int rows, int cols)
        {
            var currentCellNumber = 1;
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = currentCellNumber;
                    currentCellNumber++;
                }
            }
        }

        private static void NukeMatrix(int[][] matrix, int impactRow, int impactCol, int radius, int rows)
        {
            for (int row = 0; row < rows; row++)
            {
                if (row >= impactRow - radius && row <= impactRow + radius && row != impactRow)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (col == impactCol)
                        {
                            matrix[row][col] = 0;
                        }
                    }
                }
                else if (row == impactRow)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (col >= impactCol - radius && col <= impactCol + radius)
                        {
                            matrix[row][col] = 0;
                        }
                    }
                }
            }
        }

        private static int[][] ResizeMatrix(int[][] matrix, int rows)
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

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
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
