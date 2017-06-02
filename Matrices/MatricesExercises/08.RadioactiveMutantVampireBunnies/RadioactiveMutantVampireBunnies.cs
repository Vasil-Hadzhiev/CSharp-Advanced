using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RadioactiveMutantVampireBunnies
{
    public class RadioactiveMutantVampireBunnies
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

            var matrix = new char[rows, cols];

            FillMatrix(matrix);

            var directions = Console.ReadLine();

            IsPlayerAlive(matrix, directions, rows, cols);

        }

        private static void FillMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var inputLine = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = inputLine[col];
                }
            }
        }

        private static void IsPlayerAlive(char[,] matrix, string directions, int rows, int cols)
        {
            var survived = false;
            var currentPlayerRow = 0;
            var currentPlayerCol = 0;
            var runInToBunny = false;
            var diedFromBunny = false;

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        currentPlayerRow = row;
                        currentPlayerCol = col;
                    }
                }
            }

            var lastPlayerRow = 0;
            var lastPlayerCol = 0;

            for (int i = 0; i < directions.Length; i++)
            {
                var currentDirection = directions[i];
                lastPlayerRow = currentPlayerRow;
                lastPlayerCol = currentPlayerCol;

                switch (currentDirection)
                {
                    case 'U':
                        currentPlayerRow--;
                        break;
                    case 'D':
                        currentPlayerRow++;
                        break;
                    case 'L':
                        currentPlayerCol--;
                        break;
                    case 'R':
                        currentPlayerCol++;
                        break;
                    default:
                        break;
                }

                matrix[lastPlayerRow, lastPlayerCol] = '.';

                if (currentPlayerRow < 0 ||
                    currentPlayerCol < 0 ||
                    currentPlayerRow == rows ||
                    currentPlayerCol == cols)
                {
                    survived = true;
                    break;
                }

                if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                {
                    runInToBunny = true;
                    survived = false;
                    break;
                }

                matrix[currentPlayerRow, currentPlayerCol] = 'P';

                matrix = SpreadBunnies(matrix, rows, cols);

                if (matrix[currentPlayerRow, currentPlayerCol] == 'B')
                {
                    diedFromBunny = true;
                    break;
                }
            }

            if (!diedFromBunny)
            {
                matrix = SpreadBunnies(matrix, rows, cols);
            }
            
            PrintMatrix(matrix);

            if (survived)
            {
                Console.WriteLine($"won: {lastPlayerRow} {lastPlayerCol}");
            }
            else if (runInToBunny || diedFromBunny)
            {
                Console.WriteLine($"dead: {currentPlayerRow} {currentPlayerCol}");
            }
            else
            {
                Console.WriteLine($"dead: {lastPlayerRow} {lastPlayerCol}");
            }
        }

        private static char[,] SpreadBunnies(char[,] matrix, int rows, int cols)
        {
            var newMatrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        if (row > 0)
                        {
                            newMatrix[row - 1, col] = 'B';
                        }
                        if (row < rows - 1)
                        {
                            newMatrix[row + 1, col] = 'B';
                        }
                        if (col > 0)
                        {
                            newMatrix[row, col - 1] = 'B';
                        }
                        if (col < cols - 1)
                        {
                            newMatrix[row, col + 1] = 'B';
                        }
                    }
                }
            }

            return newMatrix;
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

