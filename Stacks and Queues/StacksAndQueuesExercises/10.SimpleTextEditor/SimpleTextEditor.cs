using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    public class SimpleTextEditor
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var stack = new Stack<string>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split().
                    ToArray();

                var command = int.Parse(tokens[0]);

                if (command == 1)
                {
                    var text = tokens[1];
                    AddString(stack, text);
                }
                else if (command == 2)
                {
                    var elementsToErase = int.Parse(tokens[1]);
                    EraseElements(stack, elementsToErase);
                }
                else if (command == 3)
                {
                    var index = int.Parse(tokens[1]);
                    var element = GetElement(stack, index);
                    Console.WriteLine(element);
                }
                else
                {
                    UndoLastModification(stack);
                }
            }
        }

        private static void AddString(Stack<string> stack, string text)
        {
            if (stack.Count == 0)
            {
                stack.Push(text);
            }
            else
            {
                var currentString = stack.Peek();
                stack.Push(currentString + text);
            }
        }

        private static void EraseElements(Stack<string> stack, int elementsToErase)
        {
            var currentString = stack.Peek();
            var newString = currentString.Substring(0, currentString.Length - elementsToErase);
            stack.Push(newString);
        }

        private static char GetElement(Stack<string> stack, int index)
        {
            var currentString = stack.Peek();
            var elementAtIndex = currentString[index - 1];

            return elementAtIndex;
        }

        private static void UndoLastModification(Stack<string> stack)
        {
            stack.Pop();
        }
    }
}
