using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MapDistricts
{
    public class MapDistricts
    {
        public static void Main()
        {
            var input = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var cityDict = new Dictionary<string, List<long>>();

            foreach (var item in input)
            {
                var cityInfo = item.Split(':');
                var name = cityInfo[0];
                var population = long.Parse(cityInfo[1]);

                if (!cityDict.ContainsKey(name))
                {
                    cityDict[name] = new List<long>();
                }

                cityDict[name].Add(population);
            }

            var minimumPopulation = long.Parse(Console.ReadLine());

            cityDict = cityDict.
                Where(x => x.Value.Sum() > minimumPopulation).
                OrderByDescending(x => x.Value.Sum()).
                ToDictionary(x => x.Key, x => x.Value);

            if (cityDict.Any())
            {
                foreach (var city in cityDict)
                {
                    Console.WriteLine("{0}: {1}",
                        city.Key,
                        string.Join(" ", city.Value.
                        OrderByDescending(x => x).
                        Take(5)));
                }
            }          
        }
    }
}
