using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.PeriodicTable
{
    public class PeriodicTable
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var chemicalCompounds = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < tokens.Length; j++)
                {
                    chemicalCompounds.Add(tokens[j]);
                }
            }

            var sortedCompounds = chemicalCompounds.
                OrderBy(x => x);

            Console.WriteLine(string.Join(" ", sortedCompounds));
        }
    }
}
