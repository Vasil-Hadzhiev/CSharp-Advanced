using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.UniqueUsernames
{
    public class UniqueUsernames
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var usernames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                var name = Console.ReadLine();

                usernames.Add(name);
            }

            foreach (var name in usernames)
            {
                Console.WriteLine(name);
            }
        }
    }
}
