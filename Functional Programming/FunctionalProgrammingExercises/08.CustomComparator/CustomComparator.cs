using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.CustomComparator
{
    public class CustomComparator
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            Array.Sort(numbers,
            (a, b) =>
            {
                int remainderA = Math.Abs(a) % 2;
                int remainderB = Math.Abs(b) % 2;

                if (remainderA != remainderB)
                {
                    return remainderA.CompareTo(remainderB);
                }
                else
                {
                    return a.CompareTo(b);
                } 
            });

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
