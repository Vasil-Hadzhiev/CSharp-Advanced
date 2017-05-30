using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    public class StackFibonacci
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());

            if (n == 0)
            {
                Console.WriteLine(0);
                return;
            }

            var stack = new Stack<long>();

            stack.Push(0);
            stack.Push(1);

            for (int i = 1; i < n; i++)
            {
                var currentNumber = stack.Pop();
                var previousNumber = stack.Peek();
                var nextNumber = currentNumber + previousNumber;

                stack.Push(currentNumber);
                stack.Push(nextNumber);
            }

            Console.WriteLine(stack.Peek());
        }
    }
}
