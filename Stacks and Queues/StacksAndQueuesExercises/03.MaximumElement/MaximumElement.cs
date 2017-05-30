using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    public class MaximumElement
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<int>();
            var maxStack = new Stack<int>();

            var maxElement = int.MinValue;

            for (int i = 0; i < n; i++)
            {
                var query = Console.ReadLine().
                    Split().
                    Select(int.Parse).
                    ToArray();

                if (query.Length > 1)
                {
                    var element = query[1];
                    stack.Push(element);

                    if (maxStack.Count == 0)
                    {
                        maxStack.Push(element);
                    }
                    else if (maxStack.Peek() >= element)
                    {
                        maxStack.Push(maxStack.Peek());
                    }
                    else
                    {
                        maxStack.Push(element);
                    }
                }
                else if (query[0] == 2)
                {
                    stack.Pop();
                    maxStack.Pop();
                }
                else if (query[0] == 3)
                {
                    Console.WriteLine(maxStack.Peek());
                }
            }
        }
    }
}
