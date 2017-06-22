using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FindAndSumIntegers
{
    public class FindAndSumIntegers
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split().ToList();

            var n = 0L;
            var sum = 0L;

            input = input.Where(x => long.TryParse(x, out n)).ToList();

            if (input.Count > 0)
            {
                sum = input.Sum(y => long.Parse(y));
                Console.WriteLine(sum);
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}
