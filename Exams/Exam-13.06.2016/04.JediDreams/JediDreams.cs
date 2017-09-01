namespace _04.JediDreams
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class JediDreams
    {
        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());

            var methods = new Dictionary<string, List<string>>();

            var methodPattern = new Regex(@"static\s+.+?\s+([A-Z]{1}[a-zA-Z]+)\s*\(");
            var invokeMethodPattern = new Regex(@"([A-Z]{1}[a-zA-Z]+)\s*\(");

            string currentMethod = string.Empty;

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                if (methodPattern.IsMatch(inputLine))
                {
                    var methodMatch = methodPattern.Match(inputLine);

                    currentMethod = methodMatch.Groups[1].Value;

                    if (!methods.ContainsKey(currentMethod))
                    {
                        methods.Add(currentMethod, new List<string>());
                    }
                }
                else if (invokeMethodPattern.IsMatch(inputLine) && currentMethod != string.Empty)
                {
                    var invokedMethodMatches = invokeMethodPattern.Matches(inputLine);

                    foreach (Match invokedMethodMatch in invokedMethodMatches)
                    {
                        methods[currentMethod].Add(invokedMethodMatch.Groups[1].Value);
                    }
                }
            }

            var sorted = methods
                .OrderByDescending(entry => entry.Value.Count)
                .ThenBy(entry => entry.Key);

            foreach (var item in sorted)
            {
                if (item.Value.Count > 0)
                {
                    Console.WriteLine("{0} -> {1} -> {2}", item.Key, item.Value.Count, string.Join(", ", item.Value.OrderBy(elem => elem)));
                }
                else
                {
                    Console.WriteLine("{0} -> None", item.Key);
                }
            }
        }
    }
}