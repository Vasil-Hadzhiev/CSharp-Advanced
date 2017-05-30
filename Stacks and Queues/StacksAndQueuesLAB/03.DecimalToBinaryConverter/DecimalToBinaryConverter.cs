using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.DecimalToBinaryConverter
{
    public class DecimalToBinaryConverter
    {
        public static void Main()
        {
            var decimalNumber = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();

            if (decimalNumber == 0)
            {
                Console.WriteLine("0");
                return;
            }

            while (decimalNumber > 0)
            {
                var reminder = decimalNumber % 2;
                decimalNumber /= 2;

                stack.Push(reminder);
            }

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }

            Console.WriteLine();
        }
    }
}
