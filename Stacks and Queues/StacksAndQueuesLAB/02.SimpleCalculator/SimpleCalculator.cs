using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SimpleCalculator
{
    public class SimpleCalculator
    {
        public static void Main()
        {
            var input = Console.ReadLine().
                Split(' ').
                ToArray();

            var stack = new Stack<string>();

            var sum = int.Parse(input[0]);

            for (int i = 1; i < input.Length; i++)
            {
                var currentElement = input[i];

                stack.Push(currentElement);
            }

            while (stack.Count > 0)
            {
                var currentNumb = int.Parse(stack.Pop());
                var operation = stack.Pop();

                if (operation == "+")
                {
                    sum += currentNumb;
                }
                else
                {
                    sum -= currentNumb;
                }
            }

            Console.WriteLine(sum);
        }
    }
}
