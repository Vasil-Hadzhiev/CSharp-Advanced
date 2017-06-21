using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SumNumbers
{
    public class SumNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                ToList();

            var count = numbers.Count();
            var sum = numbers.Sum();

            Console.WriteLine(count);
            Console.WriteLine(sum);
        }
    }
}
