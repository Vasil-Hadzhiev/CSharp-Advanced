using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountSameValues
{
    public class CountSameValues
    {
        public static void Main()
        {
            var numbersDict = new SortedDictionary<double, int>();

            var numbers = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                Select(double.Parse).
                ToArray();

            for (int i = 0; i < numbers.Length; i++)
            {
                var currentNumber = numbers[i];

                if (!numbersDict.ContainsKey(currentNumber))
                {
                    numbersDict[currentNumber] = 0;
                }

                numbersDict[currentNumber]++;
            }

            foreach (var number in numbersDict)
            {
                Console.WriteLine($"{number.Key} - {number.Value} times");
            }
        }
    }
}
