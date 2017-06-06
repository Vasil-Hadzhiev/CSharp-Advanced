using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ParseURLs
{
    public class ParseURLs
    {
        public static void Main(string[] args)
        {
            var url = Console.ReadLine();
            var elements = url.
                Split(new[] { "://" }, 
                StringSplitOptions.RemoveEmptyEntries);

            if (!url.Contains("://") || elements.Length > 2)
            {
                Console.WriteLine("Invalid URL");
            }
            else
            {
                var protocol = elements[0];
                var dashIndex = elements[1].IndexOf("/");
                if (dashIndex == -1)
                {
                    Console.WriteLine("Invalid URL");
                    return;
                }
                var server = elements[1].Substring(0, dashIndex);
                var resources = elements[1].Substring(dashIndex + 1);

                Console.WriteLine($"Protocol = {protocol}");
                Console.WriteLine($"Server = {server}");
                Console.WriteLine($"Resources = {resources}");
            }
        }
    }
}
