using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PoisonousPlants
{
    public class PoisonousPlants
    {
        public static void Main()
        {
            var plants = int.Parse(Console.ReadLine());

            var pesticides = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToList();

            var queue = new Queue<int>();

            pesticides.Reverse();

            var days = 0;

            foreach (var item in pesticides)
            {
                queue.Enqueue(item);
            }

            while (true)
            {
                var plantsAtStartOfTheDay = queue.Count();
                var count = 0;

                while (count != plantsAtStartOfTheDay - 1)
                {
                    var currentPlant = queue.Dequeue();
                    var nextPlant = queue.Peek();

                    if (currentPlant <= nextPlant)
                    {
                        queue.Enqueue(currentPlant);
                    }
                    count++;
                }
                var lastPlant = queue.Dequeue();
                queue.Enqueue(lastPlant);

                var plantsAtEndOfTheDay = queue.Count();

                if (plantsAtEndOfTheDay == plantsAtStartOfTheDay)
                {
                    break;
                }

                days++;
            }

            Console.WriteLine(days);
        }
    }
}
