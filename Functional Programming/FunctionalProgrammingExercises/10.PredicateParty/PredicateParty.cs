using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PredicateParty
{
    public class PredicateParty
    {
        public static void Main()
        {
            var names = Console.ReadLine().
                Split(new char[] { ' ' },
                StringSplitOptions.RemoveEmptyEntries).
                ToList();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                var tokens = input.Split();

                var command = tokens[0];
                var criteria = tokens[1];
                var stringOrLength = tokens[2];

                Predicate<string> predicateStartsWith = s => s.StartsWith(stringOrLength);
                Predicate<string> predicateEndsWith = s => s.EndsWith(stringOrLength);
                Predicate<string> predicateLength = s => s.Length == int.Parse(stringOrLength);

                if (command == "Remove")
                {
                    switch (criteria)
                    {
                        case "StartsWith":
                            names.RemoveAll(predicateStartsWith);
                            break;
                        case "EndsWith":
                            names.RemoveAll(predicateEndsWith);
                            break;
                        case "Length":
                            names.RemoveAll(predicateLength);
                            break;
                        default:
                            break;
                    }
                }
                else if (command == "Double")
                {
                    var toBeAdded = new List<string>();

                    switch (criteria)
                    {
                        case "StartsWith":
                            toBeAdded = names.FindAll(predicateStartsWith);
                            names.AddRange(toBeAdded);
                            break;
                        case "EndsWith":
                            toBeAdded = names.FindAll(predicateEndsWith);
                            names.AddRange(toBeAdded);
                            break;
                        case "Length":

                            toBeAdded = names.FindAll(predicateLength);

                            foreach (string person in toBeAdded)
                            {
                                int index = names.LastIndexOf(person);
                                names.Insert(index, person);
                            }
                            break;
                    }
                }
            }

            if (names.Count > 0)
            {
                Console.WriteLine("{0} are going to the party!",
                    string.Join(", ", names));
            }
            else
            {
                Console.WriteLine("Nobody is going to the party!");
            }
        }
    }
}
