using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SortEvenNumbers
{
    public class SortEvenNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split(new char[] { ' ', ',' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(int.Parse).
                Where(x => x % 2 == 0).
                ToList();

            numbers.Sort();
            Console.WriteLine(string.Join(", ", numbers));               
        }
    }
}
