using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentsByAge
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public Student(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }
    }
    public class StudentsByAge
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

                var studentTokens = input.Split();

                var firstName = studentTokens[0];
                var lastName = studentTokens[1];
                var age = int.Parse(studentTokens[2]);

                var student = new Student(firstName, lastName, age);

                students.Add(student);
            }

            students.
                Where(x => x.Age >= 18 && x.Age <= 24).
                ToList().
                ForEach(x => Console.WriteLine($"{x.FirstName} {x.LastName} {x.Age}"));
        }
    }
}
