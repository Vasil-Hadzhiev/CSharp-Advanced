namespace _01.Regeh
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;

    public class Regeh
    {
        public static void Main()
        {
            var numbers = new List<int>();

            var pattern = @"\[\w+<(\d+)REGEH(\d+)>\w+\]";

            var regex = new Regex(pattern);

            var input = Console.ReadLine();

            var result = string.Empty;

            var matches = regex.Matches(input);

            var currentIndex = 0;

            foreach (Match match in matches)
            {
                var firstNumber = int.Parse(match.Groups[1].Value);
                var secondNumber = int.Parse(match.Groups[2].Value);

                currentIndex += firstNumber;

                if (currentIndex >= input.Length)
                {
                    currentIndex %= input.Length;
                    currentIndex += 1;
                }

                result += input[currentIndex];

                currentIndex += secondNumber;

                if (currentIndex >= input.Length)
                {
                    currentIndex %= input.Length;
                    currentIndex += 1;
                }

                result += input[currentIndex];
            }

            Console.WriteLine(result);
        }
    }
}