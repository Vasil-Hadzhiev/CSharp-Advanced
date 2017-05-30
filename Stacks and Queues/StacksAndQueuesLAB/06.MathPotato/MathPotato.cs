using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MathPotato
{
    public class MathPotato
    {
        public static void Main()
        {
            var players = Console.ReadLine().
                Split().
                ToArray();

            var queue = new Queue<string>(players);

            var n = int.Parse(Console.ReadLine());

            int cycle = 1;

            while (queue.Count != 1)
            {
                for (int i = 1; i < n; i++)
                {
                    var firstElement = queue.Peek();
                    queue.Enqueue(firstElement);
                    queue.Dequeue();
                }

                if (IsPrime(cycle))
                {
                    var primeElement = queue.Peek();
                    Console.WriteLine($"Prime {primeElement}");
                }
                else
                {
                    var elementToRemove = queue.Dequeue();
                    Console.WriteLine($"Removed {elementToRemove}");
                }

                cycle++;
            }

            Console.WriteLine($"Last is {queue.Peek()}");
        }

        private static bool IsPrime(int cycle)
        {
            var result = true;

            if (cycle == 1)
            {
                result = false;
            }
            else if (cycle == 2)
            {
                result = true;
            }
            else
            {
                for (int i = 2; i <= Math.Ceiling(Math.Sqrt(cycle)); i++)
                {
                    if (cycle % i == 0)
                    {
                        result = false;
                    }
                }
            }

            return result;
        }
    }

}
