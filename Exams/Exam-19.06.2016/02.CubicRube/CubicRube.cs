namespace _02.CubicRube
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicRube
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var cube = new int[n * n * n];

            var combinations = new List<string>();

            var sum = 0L;
            var cells = n * n * n;

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "Analyze")
                {
                    break;
                }

                var tokens = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(long.Parse)
                    .ToArray();

                if (tokens.Take(3).Any(x => x < 0) || tokens[3] == 0)
                {
                    continue;
                }

                var coordinates = tokens[0] + " " + tokens[1] + " " + tokens[2];
                var particles = tokens[3];

                if (!combinations.Contains(coordinates))
                {
                    combinations.Add(coordinates);
                    cells--;
                    sum += particles;
                }
            }

            Console.WriteLine(sum);
            Console.WriteLine(cells);
        }
    }
}