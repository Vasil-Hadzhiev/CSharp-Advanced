using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BasicQueueOperations
{
    public class BasicQueueOperations
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var elementsToQueue = tokens[0];
            var elementsToDequeue = tokens[1];
            var checkElement = tokens[2];

            var elements = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var queue = new Queue<int>();

            for (int i = 0; i < elementsToQueue; i++)
            {
                var currentElement = elements[i];
                queue.Enqueue(currentElement);
            }

            for (int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (queue.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(checkElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }
        }
    }
}
