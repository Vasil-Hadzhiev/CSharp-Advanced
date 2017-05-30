using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbersWithStack
{
    public class ReverseNumbersWithStack
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            var stack = new Stack<int>();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];
                stack.Push(currentNumber);
            }

            Console.Write($"{stack.Pop()}");
            while (stack.Count > 0)
            {
                Console.Write($" {stack.Pop()}");
            }
            Console.WriteLine();
        }
    }
}
