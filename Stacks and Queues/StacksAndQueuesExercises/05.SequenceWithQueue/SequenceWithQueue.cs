using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CalculateSequenceWithQueue
{
    public class CalculateSequenceWithQueue
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            var queue = new Queue<long>();
            var handyQueue = new Queue<long>();

            queue.Enqueue(n);
            handyQueue.Enqueue(n);

            var firstCalc = 0L;
            var secondCalc = 0L;
            var thirdCalc = 0L;

            while (true)
            {
                firstCalc = handyQueue.Peek() + 1;
                secondCalc = handyQueue.Peek() * 2 + 1;
                thirdCalc = handyQueue.Peek() + 2;

                queue.Enqueue(firstCalc);
                if (queue.Count == 50)
                {
                    break;
                }
                queue.Enqueue(secondCalc);
                queue.Enqueue(thirdCalc);

                handyQueue.Dequeue();

                handyQueue.Enqueue(firstCalc);
                handyQueue.Enqueue(secondCalc);
                handyQueue.Enqueue(thirdCalc);
            }

            Console.WriteLine(string.Join(" ", queue));
        }
    }
}
