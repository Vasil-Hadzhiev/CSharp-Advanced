using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KnightsOfHonor
{
    public class KnightsOfHonor
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var names = input.Split();

            Action<string> knightsAction = PrintKnights;

            foreach (var knight in names)
            {
                PrintKnights(knight);
            }
        }

        private static void PrintKnights(string name)
        {
            Console.WriteLine($"Sir {name}");
        }
    }
}
