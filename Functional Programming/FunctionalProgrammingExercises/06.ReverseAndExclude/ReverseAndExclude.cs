using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReverseAndExclude
{
    public class ReverseAndExclude
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var divisor = int.Parse(Console.ReadLine());

            Action<int[]> reverse = nums => Array.Reverse(nums);
            Func<int[], int[]> isDivisible = collection => collection.Where(x => x % divisor != 0).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            reverse.Invoke(numbers);
            numbers = isDivisible.Invoke(numbers);
            print.Invoke(numbers);
        }
    }
}
