﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MatchingBrackets
{
    public class MatchingBrackets
    {
        public static void Main()
        {
            var input = Console.ReadLine();
            var stack = new Stack<int>();

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '(')
                {
                    stack.Push(i);
                }
                else if (input[i] == ')')
                {
                    var index = stack.Pop();
                    var expression = input.Substring(index, i - index + 1);
                    Console.WriteLine(expression);
                }
            }
        }
    }
}
