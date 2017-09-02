namespace _02.KnightGame
{
    using System;

    public class KnightGame
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var matrix = new char[n][];

            for (int row = 0; row < matrix.Length; row++)
            {
                var inputRow = Console.ReadLine().ToCharArray();
                matrix[row] = new char[n];
                matrix[row] = inputRow;
            }

            var currentKnightsInDanger = 0;
            var maxKnightsInDanger = -1;
            var mostDangerousKnightRow = 0;
            var mostDangerousKnightCol = 0;
            var count = 0;

            while (true)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        if (matrix[row][col] == 'K')
                        {
                            if (IsInMatrix(row - 2, col - 1, matrix))
                            {
                                if (matrix[row - 2][col - 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (IsInMatrix(row - 2, col + 1, matrix))
                            {
                                if (matrix[row - 2][col + 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (IsInMatrix(row + 2, col - 1, matrix))
                            {
                                if (matrix[row + 2][col -1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (IsInMatrix(row + 2, col + 1, matrix))
                            {
                                if (matrix[row + 2][col + 1] == 'K')
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (IsInMatrix(row - 1, col - 2, matrix))
                            {
                                if (matrix[row - 1][col - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (IsInMatrix(row - 1, col + 2, matrix))
                            {
                                if (matrix[row - 1][col + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (IsInMatrix(row + 1, col - 2, matrix))
                            {
                                if (matrix[row + 1][col - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            if (IsInMatrix(row + 1, col + 2, matrix))
                            {
                                if (matrix[row + 1][col + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = row;
                            mostDangerousKnightCol = col;
                        }
                        currentKnightsInDanger = 0;
                    }                   
                }

                if (maxKnightsInDanger != 0)
                {
                    matrix[mostDangerousKnightRow][mostDangerousKnightCol] = 'O';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        private static bool IsInMatrix(int row, int col, char[][] matrix)
        {
            if (0 <= row && row < matrix.Length && 0 <= col && col < matrix[row].Length)
            {
                return true;
            }

            return false;
        }
    }
}