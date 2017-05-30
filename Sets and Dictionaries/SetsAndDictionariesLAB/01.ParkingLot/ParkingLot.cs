using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ParkingLot
{
    public class ParkingLot
    {
        public static void Main()
        {
            var parking = new SortedSet<string>();

            while (true)
            {
                var tokens = Console.ReadLine().
                    Split(new char[] { ',', ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                var command = tokens[0];

                if (command == "END")
                {
                    break;
                }

                var carNumber = tokens[1];

                if (command == "IN")
                {
                    parking.Add(carNumber);
                }
                else
                {
                    parking.Remove(carNumber);
                }
            }

            if (parking.Any())
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            
        }
    }
}
