using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AverageOfDoubles
{
    public class AverageOfDoubles
    {
        public static void Main()
        {
            var average = Console.ReadLine().
                Split().
                Select(double.Parse).
                ToList().
                Average();

            Console.WriteLine($"{average:f2}");
        }
    }
}
