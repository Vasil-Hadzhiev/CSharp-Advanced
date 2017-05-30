using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AcademyGraduation
{
    public class AcademyGraduation
    {
        public static void Main()
        {
            var numberOfStudents = int.Parse(Console.ReadLine());

            var studentsGrades = new Dictionary<string, List<double>>();

            for (int i = 0; i < numberOfStudents; i++)
            {
                var name = Console.ReadLine();
                var grades = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(double.Parse).
                    ToArray();

                if (!studentsGrades.ContainsKey(name))
                {
                    studentsGrades[name] = new List<double>();
                }

                foreach (var grade in grades)
                {
                    studentsGrades[name].Add(grade);
                }
            }

            var sortedStudentGrades = studentsGrades.
                OrderBy(x => x.Key).
                ToDictionary(x => x.Key, x => x.Value);

            foreach (var student in sortedStudentGrades)
            {
                Console.WriteLine($"{student.Key} is graduated with {student.Value.Average()}");
            }
        }
    }
}
