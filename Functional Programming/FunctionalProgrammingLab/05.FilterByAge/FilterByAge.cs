using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterByAge
{
    public class FilterByAge
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var dataDict = new Dictionary<string, int>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries);

                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                FillDict(dataDict, name, age);
            }

            var condition = Console.ReadLine();
            var givenAge = int.Parse(Console.ReadLine());
            var format = Console.ReadLine();

            var sortedData = new Dictionary<string, int>();

            sortedData = SortData(dataDict, condition, givenAge);

            ExecuteOutput(sortedData, format);
        }

        private static void ExecuteOutput(Dictionary<string, int> sortedData, string format)
        {
            if (format == "name age")
            {
                foreach (var kvp in sortedData)
                {
                    Console.WriteLine($"{kvp.Key} - {kvp.Value}");
                }
            }
            else if (format == "name")
            {
                foreach (var name in sortedData)
                {
                    Console.WriteLine($"{name.Key}");
                }
            }
            else
            {
                foreach (var age in sortedData)
                {
                    Console.WriteLine($"{age.Value}");
                }
            }
        }

        private static Dictionary<string, int> SortData(Dictionary<string, int> dataDict, string condition, int givenAge)
        {
            Dictionary<string, int> sortedData;
            if (condition == "younger")
            {
                sortedData = dataDict.
                    Where(x => x.Value <= givenAge).
                    ToDictionary(x => x.Key, x => x.Value);
            }
            else
            {
                sortedData = dataDict.
                    Where(x => x.Value >= givenAge).
                    ToDictionary(x => x.Key, x => x.Value);
            }

            return sortedData;
        }

        private static void FillDict(Dictionary<string, int> dataDict, string name, int age)
        {
            if (!dataDict.ContainsKey(name))
            {
                dataDict[name] = new int();
            }
            dataDict[name] = age;
        }
    }
}
