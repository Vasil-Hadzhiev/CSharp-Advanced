using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    public class LegendaryFarming
    {
        public static void Main()
        {
            var legendaryMaterials = new Dictionary<string, int>()
            {
                {"shards", 0 },
                {"fragments", 0 },
                {"motes", 0 }
            };

            var junkMaterials = new Dictionary<string, int>();

            var farmingComplete = false;

            while (true)
            {
                var currentMaterials = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                for (int i = 0; i < currentMaterials.Length - 1; i += 2)
                {
                    var quantity = int.Parse(currentMaterials[i]);
                    var type = currentMaterials[i + 1].ToLower();

                    if (legendaryMaterials.ContainsKey(type))
                    {
                        legendaryMaterials[type] += quantity;

                        if (legendaryMaterials[type] >= 250)
                        {
                            farmingComplete = true;
                            break;
                        }
                    }
                    else
                    {
                        if (!junkMaterials.ContainsKey(type))
                        {
                            junkMaterials[type] = 0;
                        }

                        junkMaterials[type] += quantity;
                    }                  
                }

                if (farmingComplete)
                {
                    break;
                }
            }

            var legendaryMaterial = legendaryMaterials.
                OrderByDescending(x => x.Value).
                First().
                Key;

            var legendaryItem = ObtainedLegendaryItem(legendaryMaterial);

            Console.WriteLine($"{legendaryItem} obtained!");

            legendaryMaterials[legendaryMaterial] -= 250;

            var sortedLegendaryMaterials = legendaryMaterials.
                OrderByDescending(x => x.Value).
                ThenBy(x => x.Key).
                ToDictionary(x => x.Key, x => x.Value);

            foreach (var material in sortedLegendaryMaterials)
            {
                Console.WriteLine($"{material.Key}: {material.Value}");
            }

            var sortedJunkMaterials = junkMaterials.
                OrderBy(x => x.Key).
                ToDictionary(x => x.Key, x => x.Value);

            foreach (var junk in sortedJunkMaterials)
            {
                Console.WriteLine($"{junk.Key}: {junk.Value}");
            }
        }

        private static string ObtainedLegendaryItem(string legendaryMaterial)
        {
            var result = string.Empty;

            if (legendaryMaterial == "shards")
            {
                result = "Shadowmourne";
            }
            else if (legendaryMaterial == "fragments")
            {
                result = "Valanyr";
            }
            else
            {
                result = "Dragonwrath";
            }

            return result;
        }
    }
}
