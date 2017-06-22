using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BoundedNumbers
{
    public class BoundedNumbers
    {
        public static void Main()
        {
            var bounds = Console.ReadLine().
                Split().
                Select(long.Parse).
                ToArray();

            var lowerBound = bounds[0];
            var upperBound = bounds[1];

            if (lowerBound > upperBound)
            {
                var temp = upperBound;
                upperBound = lowerBound;
                lowerBound = temp;
            }

            var numbers = Console.ReadLine().
                Split().
                Select(long.Parse).
                ToArray();

            numbers = numbers.
                Where(x => x >= lowerBound && x <= upperBound).
                ToArray();

            if (numbers.Length > 0)
            {
                Console.WriteLine(string.Join(" ", numbers));
            }
        }
    }
}
