using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _05.ConvertFromBaseNToBase10
{
    public class CovertBasesV2
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split().
                ToArray();

            var targetBase = int.Parse(numbers[0]);
            var value = numbers[1];

            BigInteger result = 0;
            var pow = 0;

            for (int i = value.Length - 1; i >= 0; i--)
            {
                result += int.Parse(value[i].ToString()) * BigInteger.Pow(targetBase, pow);
                pow++;
            }

            Console.WriteLine(result);
        }
    }
}
