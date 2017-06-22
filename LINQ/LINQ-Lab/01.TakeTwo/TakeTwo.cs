using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.TakeTwo
{
    public class TakeTwo
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                Where(x => x >= 10 && x <= 20).
                Distinct().
                Take(2).
                ToList();

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
