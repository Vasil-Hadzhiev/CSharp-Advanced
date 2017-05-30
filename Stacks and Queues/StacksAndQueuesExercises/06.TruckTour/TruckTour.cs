using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    public class TruckTour
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var pumps = new Queue<GasPump>();

            var totalPetrol = 0;

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split().
                    Select(int.Parse).
                    ToArray();

                var petrolAmount = tokens[0];
                var distance = tokens[1];

                var newGasPump = new GasPump(petrolAmount, distance, i);
                pumps.Enqueue(newGasPump);
            }

            GasPump starterPump = null;
            var isComplete = false;

            while (true)
            {
                var currentPump = pumps.Dequeue();
                pumps.Enqueue(currentPump);
                starterPump = currentPump;

                totalPetrol = currentPump.petrolAmount;

                while (totalPetrol >= currentPump.distance)
                {
                    totalPetrol -= currentPump.distance;
                    currentPump = pumps.Dequeue();
                    pumps.Enqueue(currentPump);

                    if (currentPump == starterPump)
                    {
                        isComplete = true;
                        break;
                    }

                    totalPetrol += currentPump.petrolAmount;
                }

                if (isComplete)
                {
                    Console.WriteLine(currentPump.index);
                    break;
                }
            }
        }

        public class GasPump
        {
            public int petrolAmount;
            public int distance;
            public int index;

            public GasPump(int petrolAmount, int distance, int index)
            {
                this.petrolAmount = petrolAmount;
                this.distance = distance;
                this.index = index;
            }
        }
    }
}
