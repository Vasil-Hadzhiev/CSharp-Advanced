using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _04.ConvertBase10ToBaseN
{
    public class ConvertBases
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split().
                ToArray();

            var targetBase = int.Parse(numbers[0]);
            var value = BigInteger.Parse(numbers[1]);

            var result = ConvertFromTenToNBase(targetBase, value);
            Console.WriteLine(result);
        }

        private static string ConvertFromTenToNBase(int targetBase, BigInteger value)
        {
            var converted = string.Empty;

            while (value > 0)
            {
                converted = value % targetBase + converted;
                value /= targetBase;
            }

            return converted;
        }
    }
}
