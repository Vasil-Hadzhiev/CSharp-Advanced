using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.ExcellentStudents
{
    public class Student
    {
        public string Name { get; set; }
        public List<int> Grades { get; set; }

        public Student(string name, List<int> grades)
        {
            this.Name = name;
            this.Grades = grades;
        }
    }
    public class ExcellentStudents
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
                var name = tokens[0] + " " + tokens[1];

                for (int i = 2; i < tokens.Length; i++)
                {
                    grades.Add(int.Parse(tokens[i]));
                }

                var student = new Student(name, grades);
                students.Add(student);
            }

            students.
                Where(x => x.Grades.Contains(6)).
                ToList().
                ForEach(x => Console.WriteLine(x.Name));
        }
    }
}
