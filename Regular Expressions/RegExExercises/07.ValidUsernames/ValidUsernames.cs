using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _07.ValidUsernames
{
    public class ValidUsernames
    {
        public static void Main()
        {
            var usernames = Console.ReadLine().
                Split(new char[] { ' ', '(', ')', '/', '\\' },
                StringSplitOptions.RemoveEmptyEntries).
                ToArray();

            var pattern = @"^[A-z][A-z0-9_]{2,24}$";

            var regex = new Regex(pattern);

            var firstValidUsername = string.Empty;
            var secondValidUsername = string.Empty;

            var validUsernames = new List<string>();

            for (int i = 0; i < usernames.Length; i++)
            {
                var currentUsername = usernames[i];

                var match = regex.Match(currentUsername);

                if (match.Success)
                {
                    validUsernames.Add(currentUsername);
                }
            }

            int maxLength = int.MinValue;

            for (int i = 0; i < validUsernames.Count - 1; i++)
            {
                var currentUsername = validUsernames[i];
                var nextUsername = validUsernames[i + 1];

                var currentLength = currentUsername.Length + nextUsername.Length;

                if (currentLength > maxLength)
                {
                    maxLength = currentLength;
                    firstValidUsername = currentUsername;
                    secondValidUsername = nextUsername;
                }
            }

            Console.WriteLine(firstValidUsername);
            Console.WriteLine(secondValidUsername);
        }
    }
}
