using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ParkingSystem
{
    public class ParkingSystem
    {
        public static void Main()
        {
            var parking = new Dictionary<int, HashSet<int>>();

            var dimensions = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var rows = dimensions[0];
            var cols = dimensions[1];

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "stop")
                {
                    break;
                }

                var coordinates = inputLine.
                    Split().
                    Select(int.Parse).
                    ToArray();

                var entryRow = coordinates[0];
                var desiredRow = coordinates[1];
                var desiredCol = coordinates[2];

                if (!IsPlaceOccupied(parking, desiredRow, desiredCol))
                {
                    OccupyPlace(parking, desiredRow, desiredCol);
                    var distance = Math.Abs(entryRow - desiredRow) + desiredCol + 1;
                    Console.WriteLine(distance);
                }
                else
                {
                    desiredCol = FindEmptyPlace(parking, desiredRow, desiredCol, cols);
                    if (desiredCol == 0)
                    {
                        Console.WriteLine($"Row {desiredRow} full");
                    }
                    else
                    {
                        OccupyPlace(parking, desiredRow, desiredCol);
                        var distance = Math.Abs(entryRow - desiredRow) + desiredCol + 1;
                        Console.WriteLine(distance);
                    }
                }
                
            }
        }

        private static int FindEmptyPlace(Dictionary<int, HashSet<int>> parking, int desiredRow, int desiredCol, int cols)
        {
            var indexOfEmptyPlace = 0;
            var minDistance = int.MaxValue;

            if (parking.Count == cols)
            {
                return indexOfEmptyPlace;
            }
            else
            {
                for (int col = 1; col < cols; col++)
                {
                    var currentDistance = Math.Abs(desiredCol - col);
                    if (!parking[desiredRow].Contains(col) && currentDistance < minDistance)
                    {
                        indexOfEmptyPlace = col;
                        minDistance = currentDistance;
                    }
                }
                return indexOfEmptyPlace;
            }
        }

        private static bool IsPlaceOccupied(Dictionary<int, HashSet<int>> parking, int desiredRow, int desiredCol)
        {
            return parking.ContainsKey(desiredRow) && parking[desiredRow].Contains(desiredCol);
        }

        private static void OccupyPlace(Dictionary<int, HashSet<int>> parking, int desiredRow, int desiredCol)
        {
            if (!parking.ContainsKey(desiredRow))
            {
                parking[desiredRow] = new HashSet<int>();
            }
            parking[desiredRow].Add(desiredCol);
        }
    }
}
