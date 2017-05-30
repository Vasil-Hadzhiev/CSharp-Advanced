using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PopulationCounter
{
    public class PopulationCounter
    {
        public static void Main()
        {
            var countriesInfo = 
                new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "report")
                {
                    break;
                }

                var tokens = input.Split('|');

                var city = tokens[0];
                var country = tokens[1];
                var population = long.Parse(tokens[2]);

                if (!countriesInfo.ContainsKey(country))
                {
                    countriesInfo[country] = new Dictionary<string, long>();
                }

                countriesInfo[country].Add(city, population);
            }

            var sortedCountries = countriesInfo.
                OrderByDescending(x => x.Value.Sum(y => y.Value)).
                ToDictionary(x => x.Key, x => x.Value);

            foreach (var country in sortedCountries)
            {
                var totalPopulation = country.Value.
                    Sum(x => x.Value);

                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");

                var sortedCities = country.Value.
                    OrderByDescending(x => x.Value).
                    ToDictionary(x => x.Key, x => x.Value);

                foreach (var city in sortedCities)
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }                   
            }
        }
    }
}
