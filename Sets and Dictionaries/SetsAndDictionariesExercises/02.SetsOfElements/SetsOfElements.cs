using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SetsOfElements
{
    public class SetsOfElements
    {
        public static void Main()
        {
            var tokens = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var n = tokens[0];
            var m = tokens[1];

            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                firstSet.Add(currentNumber);
            }

            for (int i = 0; i < m; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());

                secondSet.Add(currentNumber);
            }

            var finalSet = firstSet.Intersect(secondSet);

            //foreach (var item in firstSet)
            //{
            //    if (secondSet.Contains(item))
            //    {
            //        finalSet.Add(item);
            //    }
            //}

            Console.WriteLine(string.Join(" ", finalSet));
        }
    }
}
