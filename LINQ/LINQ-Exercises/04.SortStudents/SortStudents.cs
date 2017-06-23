using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortStudents
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
    public class SortStudents
    {
        public static void Main()
        {
            var students = new List<Student>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var fullName = input.Split();

                var firstName = fullName[0];
                var lastName = fullName[1];

                var student = new Student(firstName, lastName);
                students.Add(student);
            }

            students.
                OrderBy(x => x.LastName).
                ThenByDescending(x => x.FirstName).
                ToList().
                ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));
        }
    }
}
