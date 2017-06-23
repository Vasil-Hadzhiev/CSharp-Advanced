using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentsByGroup
{
    public class StudentsByGroup
    {
        public static void Main()
        {
            var studentsInfo = new Dictionary<string[], int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split();

                var firstName = tokens[0];
                var secondName = tokens[1];

                var fullName = new string[2];

                fullName[0] = firstName;
                fullName[1] = secondName;

                var group = int.Parse(tokens[2]);

                if (!studentsInfo.ContainsKey(fullName))
                {
                    studentsInfo[fullName] = 0;
                }

                studentsInfo[fullName] = group;
            }

            studentsInfo = studentsInfo.
                Where(x => x.Value == 2).
                OrderBy(x => x.Key[0]).
                ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in studentsInfo)
            {
                Console.WriteLine(string.Join(" ", student.Key));
            }
        }
    }
}
