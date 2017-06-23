using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsByFirstAndLastName
{
    public class StudentsByFirstAndLastName
    {
        public static void Main()
        {
            var students = new List<string[]>();

            while (true)
            {
                var names = Console.ReadLine();

                if (names == "END")
                {
                    break;
                }

                students.Add(names.Split());
            }

            students.
                Where(x => x[0].
                CompareTo(x[1]) == -1).
                ToList().
                ForEach(x => Console.WriteLine(x[0] + " " + x[1]));
        }
    }
}
