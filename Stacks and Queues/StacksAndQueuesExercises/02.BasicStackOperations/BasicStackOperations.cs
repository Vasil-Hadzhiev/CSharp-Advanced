using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    public class BasicStackOperations
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var elementsToPush = tokens[0];
            var elementsToPop = tokens[1];
            var checkElement = tokens[2];

            var elements = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < elementsToPush; i++)
            {
                var currentElement = elements[i];
                stack.Push(currentElement);
            }

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(checkElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}
