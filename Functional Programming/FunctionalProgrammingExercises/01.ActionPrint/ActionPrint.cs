using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ActionPrint
{
    public class ActionPrint
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var names = input.Split();

            Action<string> nameAction = PrintNames;

            foreach (var name in names)
            {
                nameAction(name);
            }
        }

        private static void PrintNames(string name)
        {
            Console.WriteLine(name);
        }
    }
}
