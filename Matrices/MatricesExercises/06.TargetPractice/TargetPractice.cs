using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TargetPractice
{
    public class TargetPractice
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

            var snake = Console.ReadLine();

            var shotParams = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var impactRow = shotParams[0];
            var impactCol = shotParams[1];
            var radius = shotParams[2];

            FillMatrix(matrix, snake);
            ShootMatrix(matrix, impactRow, impactCol, radius);
            DropCharsDown(matrix);
            PrintMatrix(matrix);
        }

        private static void FillMatrix(char[,] matrix, string snake)
        {
            var isMovingLeft = true;
            var currentCharIndex = 0;
            var col = 0;

            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                if (isMovingLeft)
                {
                    col = matrix.GetLength(1) - 1;
                }
                else
                {
                    col = 0;
                }

                while (0 <= col && col < matrix.GetLength(1))
                {
                    matrix[row, col] = snake[currentCharIndex];
                    currentCharIndex++;

                    if (currentCharIndex == snake.Length)
                    {
                        currentCharIndex = 0;
                    }

                    if (isMovingLeft)
                    {
                        col--;
                    }
                    else
                    {
                        col++;
                    }                   
                }
                isMovingLeft = !isMovingLeft;
            }
        }

        public static bool IsInRadius(int row, int col, int impactRow, int impactCol, int radius)
        {
            var isInRadius = false;

            var checkRow = Math.Abs(row - impactRow);
            var checkCol = Math.Abs(col - impactCol);

            if (checkRow * checkRow + checkCol * checkCol <= radius * radius)
            {
                isInRadius = true;
            }

            return isInRadius;
        }

        private static void ShootMatrix(char[,] matrix, int impactRow, int impactCol, int radius)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (IsInRadius(row, col, impactRow, impactCol, radius))
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }
        }

        private static void DropCharsDown(char[,] matrix)
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != ' ')
                    {
                        continue;
                    }

                    var updateRow = row;

                    while (true)
                    {
                        if (updateRow == 0)
                        {
                            break;
                        }

                        updateRow--;

                        if (matrix[updateRow, col] !=  ' ')
                        {
                            matrix[row, col] = matrix[updateRow, col];
                            matrix[updateRow, col] = ' ';
                            break;
                        }
                    }
                }
            }
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }
    }
}
