namespace _03.JediCodeX
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class JediCodeX
    {
        public static void Main()
        {
            var names = new List<string>();
            var msgs = new List<string>();

            var n = int.Parse(Console.ReadLine());
            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var inputLine = Console.ReadLine();

                sb.Append(inputLine);
            }

            var namePattern = Console.ReadLine();
            var msgPattern = Console.ReadLine();

            var nameRegex = new Regex(Regex.Escape(namePattern) + @"([A-Za-z]{" + namePattern.Length + @"})(?![A-Za-z])");
            var msgRegex = new Regex(Regex.Escape(msgPattern) + @"([A-Za-z0-9]{" + msgPattern.Length + @"})(?![A-Za-z0-9])");

            var nameMatches = nameRegex.Matches(sb.ToString());
            var msgMatches = msgRegex.Matches(sb.ToString());

            foreach (Match nameMatch in nameMatches)
            {
                names.Add(nameMatch.Groups[1].Value);
            }

            foreach (Match msgMatch in msgMatches)
            {
                msgs.Add(msgMatch.Groups[1].Value);
            }

            var indexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var output = new List<string>();

            var currentIndex = 0;

            for (int i = 0; i < indexes.Length; i++)
            {
                if (indexes[i] <= msgs.Count)
                {
                    output.Add($"{names[currentIndex]} - {msgs[indexes[i] - 1]}");
                    currentIndex++;
                }

                if (currentIndex >= names.Count)
                {
                    break;
                }
            }

            Console.WriteLine(string.Join("\n", output));
        }
    }
}