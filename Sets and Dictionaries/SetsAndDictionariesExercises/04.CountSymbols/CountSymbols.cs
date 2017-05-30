using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CountSymbols
{
    public class CountSymbols
    {
        public static void Main()
        {
            var symbols = new SortedDictionary<char, int>();

            var input = Console.ReadLine();

            for (int i = 0; i < input.Length; i++)
            {
                var currentSymbol = input[i];

                if (!symbols.ContainsKey(currentSymbol))
                {
                    symbols[currentSymbol] = 0;
                }

                symbols[currentSymbol]++;
            }

            //var sortedSymbols = symbols.
            //    OrderBy(x => x.Key).
            //    ToDictionary(x => x.Key, x => x.Value);

            foreach (var symbol in symbols)
            {
                Console.WriteLine($"{symbol.Key}: {symbol.Value} time/s");
            }
        }
    }
}
