using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FormattingNumbers
{
    public class FormattingNumbers
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split(new char[] { ' ', '\t' }, 
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var a = int.Parse(numbers[0]);
            var b = double.Parse(numbers[1]);
            var c = double.Parse(numbers[2]);

            var hexValue = Convert.ToString(a, 16);
            var binaryValue = Convert.ToString(a, 2);
            binaryValue = binaryValue.PadLeft(10, '0');

            Console.WriteLine("|{0}|{1}|{2,10:f2}|{3,-10:f3}|",
                hexValue.PadRight(10, ' ').ToUpper(),
                binaryValue.Substring(0, 10),
                b,
                c);
        }
    }
}
