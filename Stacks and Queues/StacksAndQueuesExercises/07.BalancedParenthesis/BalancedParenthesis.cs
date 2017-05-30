using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.BalancedParentheses
{
    public class BalancedParentheses
    {
        public static void Main()
        {
            var parentheses = Console.ReadLine().Trim();

            parentheses = Regex.Replace(parentheses, @"\s+", "");

            var firstHalf = new Queue<char>();
            var secondHalf = new Stack<char>();

            if (parentheses.Length % 2 != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            for (int i = 0; i < parentheses.Length / 2; i++)
            {
                firstHalf.Enqueue(parentheses[i]);
            }

            for (int i = parentheses.Length / 2; i < parentheses.Length; i++)
            {
                secondHalf.Push(parentheses[i]);
            }

            var isBalanced = true;

            while (true)
            {
                if (firstHalf.Count == 0)
                {
                    break;
                }

                if (firstHalf.Peek() == '{')
                {
                    if (secondHalf.Peek() != '}')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (firstHalf.Peek() == '[')
                {
                    if (secondHalf.Peek() != ']')
                    {
                        isBalanced = false;
                        break;
                    }
                }
                else if (firstHalf.Peek() == '(')
                {
                    if (secondHalf.Peek() != ')')
                    {
                        isBalanced = false;
                        break;
                    }
                }

                firstHalf.Dequeue();
                secondHalf.Pop();
            }

            if (isBalanced)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
