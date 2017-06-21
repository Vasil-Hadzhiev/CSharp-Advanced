using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.UserLogs
{
    public class UserLogs
    {
        public static void Main()
        {
            var logsByUser = new SortedDictionary<string, Dictionary<string, int>>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                var logInfo = input.Split(' ');
                var IPinfo = logInfo[0].Split('=');
                var IP = IPinfo[1];
                var userInfo = logInfo[2].Split('=');
                var user = userInfo[1];

                if (!logsByUser.ContainsKey(user))
                {
                    logsByUser.Add(user, new Dictionary<string, int>());
                    logsByUser[user].Add(IP, 0);
                }
                else if (!logsByUser[user].ContainsKey(IP))
                {
                    logsByUser[user].Add(IP, 0);
                }
                logsByUser[user][IP]++;
            }
            foreach (var outerPair in logsByUser)
            {
                Console.WriteLine("{0}:", outerPair.Key);
                Console.WriteLine("{0}.", string.Join(", ", outerPair.
                    Value.
                    Select(kv => kv.Key + " => " + kv.Value)));
            }

        }
    }
}
