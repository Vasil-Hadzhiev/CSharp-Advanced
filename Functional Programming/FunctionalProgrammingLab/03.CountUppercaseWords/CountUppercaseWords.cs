using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CountUppercaseWords
{
    public class CountUppercaseWords
    {
        public static void Main()
        {
            var words = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                ToList();

            var upper = words.Where(x => char.IsUpper(x[0]));

            foreach (var word in upper)
            {
                Console.WriteLine(word);
            }
        }
    }
}
