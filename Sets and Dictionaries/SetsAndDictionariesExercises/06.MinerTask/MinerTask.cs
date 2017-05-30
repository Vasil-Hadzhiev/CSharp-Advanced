using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MinerTask
{
    public class MinerTask
    {
        public static void Main()
        {
            var resources = new Dictionary<string, int>();

            while (true)
            {
                var currentResource = Console.ReadLine();

                if (currentResource == "stop")
                {
                    break;
                }

                var quantity = int.Parse(Console.ReadLine());

                if (!resources.ContainsKey(currentResource))
                {
                    resources[currentResource] = 0;
                }

                resources[currentResource] += quantity;
            }

            foreach (var item in resources)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
