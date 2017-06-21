using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomMinFunction
{
    public class CustomMinFunction
    {
        public static void Main()
        {
            var input = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            Func<int[], int> minFunc = numb => numb.Min();
            Console.WriteLine(minFunc(input));
        }
    }
}
