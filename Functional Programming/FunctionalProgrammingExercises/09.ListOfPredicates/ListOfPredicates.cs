using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.ListOfPredicates
{
    public class ListOfPredicates
    {
        public static void Main()
        {
            var rangeEnd = int.Parse(Console.ReadLine());

            int[] divisors = Console.ReadLine().
                Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToArray();

            Func<int, bool>[] predicates = divisors.Select(d => (Func<int, bool>)(n => n % d == 0)).ToArray();

            List<int> result = new List<int>();

            for (int i = 1; i <= rangeEnd; i++)
            {
                var isDivisible = true;

                foreach (var predicate in predicates)
                {
                    if (!predicate(i))
                    {
                        isDivisible = false;
                        break;
                    }
                }
                if (isDivisible)
                {
                    result.Add(i);
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
