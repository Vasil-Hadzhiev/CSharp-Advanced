using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.PredicateForNames
{
    public class PredicateForNames
    {
        public static void Main()
        {
            var length = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Predicate<string> isShorter = name => name.Length <= length;
            Action<string> namesAction = PrintNames; 

            var result = names.Where(name => isShorter(name));

            foreach (var name in result)
            {
                namesAction(name);
            }

        }

        private static void PrintNames(string name)
        {
            Console.WriteLine(name);
        }
    }
}
