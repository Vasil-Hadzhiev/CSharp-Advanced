using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentsResults
{
    public class StudentsResults
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());

            var studentInfo = new Dictionary<string, List<double>>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split(new char[] { '-' },
                    StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                var name = tokens[0].Trim();

                var studentResults = tokens[1].
                    Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(double.Parse).
                    ToList();

                var cAdv = studentResults[0];
                var cOOP = studentResults[1];
                var advOOP = studentResults[2];

                if (!studentInfo.ContainsKey(name))
                {
                    studentInfo[name] = new List<double>();
                }

                for (int j = 0; j < studentResults.Count; j++)
                {
                    studentInfo[name].Add(studentResults[j]);
                }
            }

            Console.WriteLine(string.Format("{0,-10}|{1,7}|{2,7}|{3,7}|{4,7}|",
                "Name",
                "CAdv",
                "COOP",
                "AdvOOP",
                "Average"));

            foreach (var student in studentInfo)
            {
                Console.WriteLine(string.Format("{0,-10}|{1,7:f2}|{2,7:f2}|{3,7:f2}|{4,7:f4}|",
                student.Key,
                student.Value[0],
                student.Value[1],
                student.Value[2],
                student.Value.Average()));
            }
        }
    }
}
