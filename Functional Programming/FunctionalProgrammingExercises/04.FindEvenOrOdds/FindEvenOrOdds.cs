using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FindEvenOrOdds
{
    public class FindEvenOrOdds
    {
        public static void Main()
        {
            var input = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            var numbers = new List<int>();

            for (int i = input[0]; i <= input[1]; i++)
            {
                numbers.Add(i);
            }

            var evenOrOdd = Console.ReadLine();

            Predicate<int> isEven = n => n % 2 == 0;
            Predicate<int> isOdd = n => n % 2 != 0;

            foreach (var number in numbers)
            {
                if (evenOrOdd == "even")
                {
                    if (isEven.Invoke(number))
                    {
                        Console.Write(number + " ");
                    }
                }
                else
                {
                    if (isOdd.Invoke(number))
                    {
                        Console.Write(number + " ");
                    }
                }
            }
        }
    }
}
