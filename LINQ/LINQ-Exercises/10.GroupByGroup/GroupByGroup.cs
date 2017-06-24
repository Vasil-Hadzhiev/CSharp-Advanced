using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.GroupByGroup
{
    public class Person
    {
        public string Name { get; set; }
        public int Group { get; set; }

        public Person(string name, int group)
        {
            this.Name = name;
            this.Group = group;
        }
    }
    public class GroupByGroup
    {
        public static void Main()
        {
            var personData = new List<Person>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split();
                var name = tokens[0] + " " + tokens[1];
                var group = int.Parse(tokens[2]);

                var person = new Person(name, group);
                personData.Add(person);
            }

            var sortedPersonData = personData.
                GroupBy(x => x.Group).
                OrderBy(x => x.Key).
                ToDictionary(x => x.Key);

            foreach (var person in sortedPersonData)
            {
                var names = person.
                    Value.
                    Select(x => x.Name);

                Console.WriteLine($"{person.Key} - {string.Join(", ", names)}");
            }
        }
    }
}
