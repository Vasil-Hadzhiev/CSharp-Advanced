using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StudentsEnrolledIn2014Or2015
{
    public class Student
    {
        public string FacultyNumber { get; set; }
        public List<int> Grades { get; set; }

        public Student(string facultyNumber, List<int> grades)
        {
            this.FacultyNumber = facultyNumber;
            this.Grades = grades;
        }
    }
    public class StudentsEnrolled
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

                var tokens = input.Split();

                var grades = new List<int>();
                var facultyNumber = tokens[0];

                for (int i = 1; i < tokens.Length; i++)
                {
                    grades.Add(int.Parse(tokens[i]));
                }

                var student = new Student(facultyNumber, grades);
                students.Add(student);
            }

            students.
                Where(x => x.FacultyNumber.EndsWith("14") || x.FacultyNumber.EndsWith("15")).
                ToList().
                ForEach(x => Console.WriteLine(string.Join(" ", x.Grades)));
        }
    }
}
