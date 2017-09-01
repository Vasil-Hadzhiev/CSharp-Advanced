namespace _01.JediMeditation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class JediMeditation
    {
        public static void Main()
        {
            var masters = new Queue<string>();
            var knights = new Queue<string>();
            var padawans = new Queue<string>();
            var toshkoAndSlav = new Queue<string>();
            var yoda = 0;

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine()
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int j = 0; j < input.Length; j++)
                {
                    var currentJedi = input[j];

                    if (currentJedi.StartsWith("m"))
                    {
                        masters.Enqueue(currentJedi);
                    }
                    else if (currentJedi.StartsWith("k"))
                    {
                        knights.Enqueue(currentJedi);
                    }
                    else if (currentJedi.StartsWith("p"))
                    {
                        padawans.Enqueue(currentJedi);
                    }
                    else if (currentJedi.StartsWith("y"))
                    {
                        yoda++;
                    }
                    else
                    {
                        toshkoAndSlav.Enqueue(currentJedi);
                    }
                }
            }

            var finalOrder = new Queue<string>();

            if (yoda == 0)
            {
                Console.WriteLine(
                    string.Join(" ", toshkoAndSlav) + " " +
                    string.Join(" ", masters) + " " +
                    string.Join(" ", knights) + " " +
                    string.Join(" ", padawans));
            }
            else
            {
                Console.WriteLine(
                    string.Join(" ", masters) + " " +
                    string.Join(" ", knights) + " " +
                    string.Join(" ", toshkoAndSlav) + " " +
                    string.Join(" ", padawans));
            }
        }
    }
}