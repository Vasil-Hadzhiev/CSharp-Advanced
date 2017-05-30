using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RecursiveFibonacci
{
    public class RecursiveFibonacci
    {
        private static ulong[] lookUpArray;

        public static void Main()
        {
            lookUpArray = new ulong[50];
            lookUpArray[0] = 1;
            lookUpArray[1] = 1;

            var n = ulong.Parse(Console.ReadLine());
            var result = getFibonacci(n);

            Console.WriteLine(result);
        }

        public static ulong getFibonacci(ulong n)
        {
            if (n <= 2)
            {
                return 1;
            }

            if (lookUpArray[n - 1] != 0)
            {
                return lookUpArray[n - 1];
            }

            lookUpArray[n - 1] = getFibonacci(n - 1) + getFibonacci(n - 2);
            return lookUpArray[n - 1];
        }
    }
}
