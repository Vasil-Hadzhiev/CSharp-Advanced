using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LegoBlocks
{
    public class LegoBlocks
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var firstJaggedArray = new int[n][];
            var secondJaggedArray = new int[n][];

            FillMatrix(firstJaggedArray);
            FillMatrix(secondJaggedArray);
            ReverseMatrix(secondJaggedArray);

            var finalMatrix = new int[n][];

            var isItFit = CheckArrayMatch(n, firstJaggedArray, secondJaggedArray, finalMatrix);

            if (isItFit)
            {
                PrintMatrix(finalMatrix);
            }
            else
            {
                var cellCount = GetNumberOfCells(firstJaggedArray, secondJaggedArray);
                Console.WriteLine($"The total number of cells is: {cellCount}");
            }

        }

        private static void FillMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var numbers = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(int.Parse).
                    ToArray();

                matrix[row] = numbers;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = numbers[col];
                }
            }  
        }

        private static void ReverseMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Array.Reverse(matrix[row]);
            }
        }

        private static bool CheckArrayMatch(int n, int[][] firstJaggedArray, int[][] secondJaggedArray, int[][] finalMatrix)
        {
            var initialLength = firstJaggedArray[0].Length + secondJaggedArray[0].Length;

            var isItFit = true;

            for (int row = 0; row < n; row++)
            {
                if (firstJaggedArray[row].Length + secondJaggedArray[row].Length == initialLength)
                {
                    finalMatrix[row] = new int[initialLength];
                    var finalCol = 0;

                    for (int col = 0; col < firstJaggedArray[row].Length; col++)
                    {
                        finalMatrix[row][finalCol] = firstJaggedArray[row][col];
                        finalCol++;
                    }

                    for (int col = 0; col < secondJaggedArray[row].Length; col++)
                    {
                        finalMatrix[row][finalCol] = secondJaggedArray[row][col];
                        finalCol++;
                    }
                }
                else
                {
                    isItFit = false;
                    break;
                }
            }

            return isItFit;
        }

        private static int GetNumberOfCells(int[][] firstMatrix, int[][] secondMatrix)
        {
            var cellCount = 0;

            for (int row = 0; row < firstMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < firstMatrix[row].Length; col++)
                {
                    cellCount++;
                }
            }

            for (int row = 0; row < secondMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < secondMatrix[row].Length; col++)
                {
                    cellCount++;
                }
            }

            return cellCount;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine("[{0}]", string.Join(", ", matrix[row]));
            }
        }
    }
}
