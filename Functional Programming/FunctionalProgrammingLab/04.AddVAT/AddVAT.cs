using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AddVAT
{
    public class AddVAT
    {
        public static void Main()
        {
            var prices = Console.ReadLine().
                Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(double.Parse).
                ToList();

            var vatPrices = prices.Select(x => x += x * (20.0 / 100.0));

            foreach (var item in vatPrices)
            {
                Console.WriteLine($"{item:f2}");
            }
        }
    }
}
