using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FixEmails
{
    public class FixEmails
    {
        public static void Main()
        {
            var emailsDict = new Dictionary<string, string>();

            while (true)
            {
                var name = Console.ReadLine();

                if (name == "stop")
                {
                    break;
                }

                var email = Console.ReadLine();

                if (email.ToLower().EndsWith("us") || email.ToLower().EndsWith("uk"))
                {
                    continue;
                }

                if (!emailsDict.ContainsKey(name))
                {
                    emailsDict[name] = string.Empty;
                }

                emailsDict[name] = email;
            }

            foreach (var item in emailsDict)
            {
                Console.WriteLine($"{item.Key} -> {item.Value}");
            }
        }
    }
}
