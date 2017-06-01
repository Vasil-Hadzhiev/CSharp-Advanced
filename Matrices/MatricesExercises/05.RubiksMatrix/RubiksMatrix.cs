using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RubiksMatrix
{
    public class RubiksMatrix
    {
        public static void Main()
        {
            var matrixTokens = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var rows = matrixTokens[0];
            var cols = matrixTokens[1];

            var matrix = new int[rows, cols];

            FillMatrix(rows, cols, matrix);

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                var index = int.Parse(tokens[0]);
                var command = tokens[1];
                var count = int.Parse(tokens[2]);

                switch (command)
                {
                    case "up":
                        ShiftMatrixUp(index, count, matrix);
                        break;
                    case "down":
                        ShiftMatrixDown(index, count, matrix);
                        break;
                    case "left":
                        ShiftMatrixLeft(index, count, matrix);
                        break;
                    case "right":
                        ShiftMatrixRight(index, count, matrix);
                        break;
                    default:
                        break;
                }
            }

            RearrangeMatrix(matrix);

        }

        private static void FillMatrix(int rows, int cols, int[,] matrix)
        {
            var count = 1;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }
        }

        private static void ShiftMatrixRight(int index, int count, int[,] matrix)
        {
            count %= matrix.GetLength(1);
            for (int i = 0; i < count; i++)
            {
                var lastElement = matrix[index, matrix.GetLength(1) - 1];

                for (int j = matrix.GetLength(1) - 1; j > 0; j--)
                {
                    matrix[index, j] = matrix[index, j - 1];
                }
                matrix[index, 0] = lastElement;
            }
        }

        private static void ShiftMatrixLeft(int index, int count, int[,] matrix)
        {
            count %= matrix.GetLength(1);
            for (int i = 0; i < count; i++)
            {
                var firstElement = matrix[index, 0];

                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    matrix[index, j] = matrix[index, j + 1];
                }
                matrix[index, matrix.GetLength(1) - 1] = firstElement;
            }
        }

        private static void ShiftMatrixDown(int index, int count, int[,] matrix)
        {
            count %= matrix.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                var lastElement = matrix[matrix.GetLength(0) - 1, index];

                for (int j = matrix.GetLength(0) - 1; j > 0; j--)
                {
                    matrix[j, index] = matrix[j - 1, index];
                }
                matrix[0, index] = lastElement;
            }
        }

        private static void ShiftMatrixUp(int index, int count, int[,] matrix)
        {
            count %= matrix.GetLength(0);
            for (int i = 0; i < count; i++)
            {
                var firstElement = matrix[0, index];

                for (int j = 0; j < matrix.GetLength(0) - 1; j++)
                {
                    matrix[j, index] = matrix[j + 1, index];
                }
                matrix[matrix.GetLength(0) - 1, index] = firstElement;
            }
        }

        private static void RearrangeMatrix(int[,] matrix)
        {
            var element = 1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var currentElement = matrix[row, col];
                    if (currentElement != element)
                    {
                        for (int swapRow = 0; swapRow < matrix.GetLength(0); swapRow++)
                        {
                            for (int swapCol = 0; swapCol < matrix.GetLength(1); swapCol++)
                            {
                                if (matrix[swapRow, swapCol] == element)
                                {
                                    matrix[swapRow, swapCol] = currentElement;
                                    matrix[row, col] = element;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({swapRow}, {swapCol})");
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No swap required");
                    }
                    element++;
                }
            }
        }
    }
}
