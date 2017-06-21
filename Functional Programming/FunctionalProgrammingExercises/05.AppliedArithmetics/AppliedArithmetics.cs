using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AppliedArithmetics
{
    public class AppliedArithmetics
    {
        public static void Main()
        {
            var numbers = Console.ReadLine().
                Split().
                Select(int.Parse).
                ToArray();

            Func<int[], int[]> add = n => n.Select(x => x += 1).ToArray();
            Func<int[], int[]> multiply = n => n.Select(x => x *= 2).ToArray();
            Func<int[], int[]> subtract = n => n.Select(x => x -= 1).ToArray();
            Action<int[]> print = nums => Console.WriteLine(string.Join(" ", nums));

            while (true)
            {
                var command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                switch (command)
                {
                    case "add":
                        numbers = add.Invoke(numbers);
                        break;
                    case "multiply":
                        numbers = multiply.Invoke(numbers);
                        break;
                    case "subtract":
                        numbers = subtract.Invoke(numbers);
                        break;
                    case "print":
                        print.Invoke(numbers);
                        break;
                    default:
                        break;
                }
            }
        }   
    }
}
