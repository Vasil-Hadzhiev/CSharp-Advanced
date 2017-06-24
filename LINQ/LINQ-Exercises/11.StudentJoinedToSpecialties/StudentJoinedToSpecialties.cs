using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.StudentJoinedToSpecialties
{
    public class StudentSpecialty
    {
        public string SpecialtyName { get; set; }
        public string FacultyNumber { get; set; }

        public StudentSpecialty(string specialtyName, string facultyNumber)
        {
            this.SpecialtyName = specialtyName;
            this.FacultyNumber = facultyNumber;
        }
    }
    public class Student
    {
        public string StudentName { get; set; }
        public string FacultyNumber { get; set; }

        public Student(string studentName, string facultyNumber)
        {
            this.StudentName = studentName;
            this.FacultyNumber = facultyNumber;
        }
    }
    public class StudentJoinedToSpecialties
    {
        public static void Main()
        {
            var specialties = new List<StudentSpecialty>();
            var students = new List<Student>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Students:")
                {
                    break;
                }

                var tokens = input.Split();

                var specialtyName = tokens[0] + " " + tokens[1];
                var facultyNumber = tokens[2];

                var newFacultyData = new StudentSpecialty(specialtyName, facultyNumber);
                specialties.Add(newFacultyData);
            }

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                var tokens = input.Split();

                var studentName = tokens[1] + " " + tokens[2];
                var facultyNumber = tokens[0];

                var newStudent = new Student(studentName, facultyNumber);
                students.Add(newStudent);
            }

            var result = specialties.
                Join(students, x => x.FacultyNumber, y => y.FacultyNumber, 
                (x, y) => new
                {
                    FacultyNumber = x.FacultyNumber,
                    StudentName = y.StudentName,
                    SpecialtyName = x.SpecialtyName
                });

            foreach (var item in result.OrderBy(r => r.StudentName))
            {
                Console.WriteLine($"{item.StudentName} {item.FacultyNumber} {item.SpecialtyName}");
            }
        }
    }
}
