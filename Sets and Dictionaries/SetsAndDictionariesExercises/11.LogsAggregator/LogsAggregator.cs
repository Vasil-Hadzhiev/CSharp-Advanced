using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.LogsAggregator
{
    public class LogsAggregator
    {
        public static void Main()
        {
            var userInfo =
                new Dictionary<string, int>();

            var ipInfo =
                new Dictionary<string, HashSet<string>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                var ip = tokens[0];
                var name = tokens[1];
                var duration = int.Parse(tokens[2]);

                if (!userInfo.ContainsKey(name))
                {
                    userInfo[name] = 0;
                }

                userInfo[name] += duration;

                if (!ipInfo.ContainsKey(name))
                {
                    ipInfo[name] = new HashSet<string>();
                }

                ipInfo[name].Add(ip);
            }

            var sortedUserInfo = userInfo.
                OrderBy(x => x.Key).
                ToDictionary(x => x.Key, x => x.Value);

            foreach (var user in sortedUserInfo)
            {
                var ipAddresses = ipInfo[user.Key].
                    OrderBy(x => x).
                    ToList();

                Console.WriteLine("{0}: {1} [{2}]",
                    user.Key,
                    user.Value,
                    string.Join(", ", ipAddresses));
            }
        }
    }
}
