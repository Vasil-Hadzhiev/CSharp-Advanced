using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.MinEvenNumber
{
    public class MinEvenNumber
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(double.Parse).
                Where(x => x % 2 == 0).
                ToList();

            if (numbers.Count > 0)
            {
                var minNumber = numbers.Min();
                Console.WriteLine($"{minNumber:f2}");
            }
            else
            {
                Console.WriteLine("No match");
            }           
        }
    }
}
