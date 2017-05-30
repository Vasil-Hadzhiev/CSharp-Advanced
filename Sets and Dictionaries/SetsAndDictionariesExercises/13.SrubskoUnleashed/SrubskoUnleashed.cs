using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.SrubskoUnleashed
{
    public class SrubskoUnleashed
    {
        public static void Main()
        {
            var pattern = @"(.+)\s@(.+)\s(\d+)\s(\d+)";

            var regex = new Regex(pattern);

            var eventsInfo = new Dictionary<string, Dictionary<string, long>>();

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "End")
                {
                    break;
                }

                if (regex.IsMatch(inputLine))
                {
                    var matches = regex.Matches(inputLine);

                    foreach (Match match in matches)
                    {
                        var singer = match.Groups[1].Value;
                        var venue = match.Groups[2].Value;
                        var ticketPrice = int.Parse(match.Groups[3].Value);
                        var ticketCount = int.Parse(match.Groups[4].Value);

                        var totalMoney = ticketCount * ticketPrice;

                        if (!eventsInfo.ContainsKey(venue))
                        {
                            eventsInfo[venue] = new Dictionary<string, long>();
                        }

                        if (!eventsInfo[venue].ContainsKey(singer))
                        {
                            eventsInfo[venue][singer] = 0;
                        }

                        eventsInfo[venue][singer] += totalMoney;
                    }
                }
            }

            foreach (var venue in eventsInfo)
            {
                Console.WriteLine(venue.Key);

                var sortedSingers = venue.Value.
                    OrderByDescending(x => x.Value).
                    ToDictionary(x => x.Key, x => x.Value);

                foreach (var singer in sortedSingers)
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }
    }
}
