namespace _02.JediGalaxy
{
    using System;
    using System.Linq;

    public class JediGalaxy
    {
        public static void Main()
        {
            var dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            var matrix = new int[rows, cols];

            FillMatrix(matrix);

            var totalStars = 0L;

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Let the Force be with you")
                {
                    break;
                }

                var ivoCoord = input
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var ivoStartRow = ivoCoord[0];
                var ivoStartCol = ivoCoord[1];

                var evilCoord = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var evilStartRow = evilCoord[0];
                var evilStartCol = evilCoord[1];

                DestroyStars(matrix, evilStartRow, evilStartCol);
                totalStars += CollectStars(matrix, ivoStartRow, ivoStartCol);
            }

            Console.WriteLine(totalStars);
        }

        private static bool IsInMatrix(int givenRow, int givenCol, int rows, int cols)
        {
            bool result =
                givenRow >= 0 &&
                givenRow < rows &&
                givenCol >= 0 &&
                givenCol < cols;

            return result;
        }

        private static long CollectStars(int[,] matrix, int ivoStartRow, int ivoStartCol)
        {
            var collectedStars = 0L;

            while (ivoStartRow >= 0 && ivoStartCol < matrix.GetLength(1))
            {
                if (IsInMatrix(ivoStartRow, ivoStartCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    collectedStars += matrix[ivoStartRow, ivoStartCol];
                }

                ivoStartRow--;
                ivoStartCol++;
            }

            return collectedStars;
        }

        private static void DestroyStars(int[,] matrix, int evilStartRow, int evilStartCol)
        {
            while (evilStartRow >= 0 && evilStartCol >= 0)
            {
                if (IsInMatrix(evilStartRow, evilStartCol, matrix.GetLength(0), matrix.GetLength(1)))
                {
                    matrix[evilStartRow, evilStartCol] = 0;
                }

                evilStartRow--;
                evilStartCol--;
            }
        }

        private static void FillMatrix(int[,] matrix)
        {
            var count = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = count;
                    count++;
                }
            }
        }
    }
}