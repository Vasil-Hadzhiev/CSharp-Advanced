using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.UpperStrings
{
    public class UpperStrings
    {
        public static void Main()
        {
            var words = Console.ReadLine().
                Split();

            words.
                Select(s => s.ToUpper()).
                ToList().
                ForEach(s => Console.Write(s + " "));

            Console.WriteLine();
        }
    }
}
