using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _12.LittleJohn
{
    public class LittleJohn
    {
        public static void Main()
        {
            var validArrow = @"\>{1,3}\-{5}\>{1,2}";
            var largeArrowPattern = @"\>{3}\-{5}\>{2}";
            var meduimArrowPattern = @"\>{2}\-{5}\>{1}";
            var smallArrowPattern = @"\>{1}\-{5}\>{1}";

            int largeCount = 0;
            int mediumCount = 0;
            int smallCount = 0;

            for (int i = 0; i < 4; i++)
            {
                var input = Console.ReadLine();

                var validArrows = Regex.Matches(input, validArrow);

                foreach (Match arrow in validArrows)
                {
                    var largeArrow = Regex.Match(arrow.ToString(), largeArrowPattern);
                    var mediumArrow = Regex.Match(arrow.ToString(), meduimArrowPattern);
                    var smallArrow = Regex.Match(arrow.ToString(), smallArrowPattern);

                    if (largeArrow.Success)
                    {
                        largeCount++;
                    }
                    else if (mediumArrow.Success)
                    {
                        mediumCount++;

                    }
                    else if (smallArrow.Success)
                    {
                        smallCount++;
                    }
                }
            }

            var concatenatedCounts = "" + smallCount + mediumCount + largeCount;
            var binary = Convert.ToString(int.Parse(concatenatedCounts), 2);
            var binaryReversed = new string(binary.ToCharArray().Reverse().ToArray());
            var concatenatedResult = "" + binary + binaryReversed;
            var decimalResult = Convert.ToInt32(concatenatedResult, 2).ToString();
            Console.WriteLine(decimalResult);
        }
    }
}
