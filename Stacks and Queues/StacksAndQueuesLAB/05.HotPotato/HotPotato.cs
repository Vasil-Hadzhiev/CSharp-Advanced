using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HotPotato
{
    public class HotPotato
    {
        public static void Main()
        {
            var players = Console.ReadLine().
                Split(' ').
                ToArray();

            var queue = new Queue<string>(players);

            var n = int.Parse(Console.ReadLine());

            while (queue.Count != 1)
            {
                for (int i = 0; i < n - 1; i++)
                {
                    var firstElement = queue.Peek();
                    queue.Enqueue(firstElement);
                    queue.Dequeue();
                }
                var elementToRemove = queue.Dequeue();
                Console.WriteLine($"Removed {elementToRemove}");
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }
    }
}
