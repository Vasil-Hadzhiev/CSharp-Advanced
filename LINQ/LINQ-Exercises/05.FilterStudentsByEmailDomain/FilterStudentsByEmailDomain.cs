using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterStudentsByEmailDomain
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public Student(string firstName, string lastName, string email)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = Email;
        }
    }
    public class FilterStudentsByEmailDomain
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
                var email = studentTokens[2];

                if (!email.Contains("@gmail.com"))
                {
                    continue;
                }

                var student = new Student(firstName, lastName, email);

                students.Add(student);
            }

            students.
                ToList().
                ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));
        }
    }
}
