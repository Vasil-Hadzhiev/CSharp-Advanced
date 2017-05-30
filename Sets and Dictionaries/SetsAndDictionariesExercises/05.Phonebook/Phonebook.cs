using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Phonebook
{
    public class Phonebook
    {
        public static void Main()
        {
            var phonebook = new Dictionary<string, string>();

            while (true)
            {
                var tokens = Console.ReadLine().
                    Split('-').
                    ToArray();

                if (tokens[0] == "search")
                {
                    break;
                }

                var name = tokens[0];
                var phone = tokens[1];

                if (!phonebook.ContainsKey(name))
                {
                    phonebook[name] = string.Empty;
                }

                phonebook[name] = phone;
            }

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                if (phonebook.ContainsKey(name))
                {
                    Console.WriteLine($"{name} -> {phonebook[name]}");
                }
                else
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
            }
        }
    }
}
