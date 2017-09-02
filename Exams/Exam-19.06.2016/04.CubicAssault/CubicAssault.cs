namespace _04.CubicAssault
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CubicAssault
    {
        public static void Main()
        {
            var regionData = new Dictionary<string, Meteor>();
            var pattern = @"(.+)\s*->\s*([A-z]+)\s*->\s*([0-9]+)";
            var regex = new Regex(pattern);

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "Count em all")
                {
                    break;
                }

                var blackMeteors = 0L;
                var redMeteors = 0L;
                var greenMeteors = 0L;

                var regionName = string.Empty;
                var meteorType = string.Empty;
                var meteorCount = 0L;

                if (regex.IsMatch(inputLine))
                {
                    var matches = regex.Matches(inputLine);

                    foreach (Match match in matches)
                    {
                        regionName = match.Groups[1].Value;
                        meteorType = match.Groups[2].Value;
                        meteorCount = long.Parse(match.Groups[3].Value);
                    }
                }

                if (!regionData.ContainsKey(regionName))
                {
                    regionData[regionName] = new Meteor();
                }

                if (meteorType == "Green")
                {
                    greenMeteors = meteorCount;

                    regionData[regionName].MeteorData["Green"] += greenMeteors;

                    if (regionData[regionName].MeteorData["Green"] >= 1_000_000)
                    {
                        regionData[regionName].MeteorData["Red"] += regionData[regionName].MeteorData["Green"] / 1_000_000;
                        if (regionData[regionName].MeteorData["Red"] >= 1_000_000)
                        {
                            regionData[regionName].MeteorData["Black"] += regionData[regionName].MeteorData["Red"] / 1_000_000;
                            regionData[regionName].MeteorData["Red"] %= 1_000_000; 
                        }

                        regionData[regionName].MeteorData["Green"] %= 1_000_000;
                    }                                  
                }
                else if (meteorType == "Red")
                {
                    redMeteors = meteorCount;

                    regionData[regionName].MeteorData["Red"] += redMeteors;

                    if (regionData[regionName].MeteorData["Red"] >= 1_000_000)
                    {
                        regionData[regionName].MeteorData["Black"] += regionData[regionName].MeteorData["Red"] / 1_000_000;
                        regionData[regionName].MeteorData["Red"] %= 1_000_000;
                    }
                }
                else
                {
                    blackMeteors = meteorCount;

                    regionData[regionName].MeteorData["Black"] += blackMeteors;
                }
            }

            var orderedData = regionData
                .OrderByDescending(r => r.Value.MeteorData["Black"])
                .ThenBy(r => r.Key.Length)
                .ThenBy(r => r.Key)
                .ToDictionary(x => x.Key, x => x.Value);

            foreach (var region in orderedData)
            {
                Console.WriteLine($"{region.Key}");

                foreach (var meteor in region.Value
                    .MeteorData.OrderByDescending(x => x.Value)
                    .ThenBy(x => x.Key))
                {
                    Console.WriteLine($"-> {meteor.Key} : {meteor.Value}");
                }
            }
        }
    }

    public class Meteor
    {
        public Meteor()
        {
            this.MeteorData = new Dictionary<string, long>
            {
                {"Black", 0L },
                {"Red", 0L },
                {"Green", 0L }
            };
        }

        public Dictionary<string, long> MeteorData { get; set; }
    }
}