using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FilterStudentsByPhone
{
    public class Student
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }

        public Student(string firstName, string lastName, string phoneNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.PhoneNumber = phoneNumber;
        }
    }
    public class FilterStudentsByPhone
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
                var phoneNumber = studentTokens[2];

                var student = new Student(firstName, lastName, phoneNumber);

                students.Add(student);
            }

            students.
                Where(x => x.PhoneNumber.StartsWith("02") || x.PhoneNumber.StartsWith("+3592")).
                ToList().
                ForEach(x => Console.WriteLine(x.FirstName + " " + x.LastName));
        }
    }
}
