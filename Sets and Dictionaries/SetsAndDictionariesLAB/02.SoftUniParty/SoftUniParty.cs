using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SoftUniParty
{
    public class SoftUniParty
    {
        public static void Main()
        {
            var vipGuests = new SortedSet<string>();
            var regularGuests = new SortedSet<string>();

            while (true)
            {
                var invitedGuest = Console.ReadLine();

                if (invitedGuest == "PARTY")
                {
                    break;
                }

                if (char.IsDigit(invitedGuest[0]))
                {
                    vipGuests.Add(invitedGuest);
                }
                else
                {
                    regularGuests.Add(invitedGuest);
                }
            }

            while (true)
            {
                var commingGuest = Console.ReadLine();

                if (commingGuest == "END")
                {
                    break;
                }

                if (vipGuests.Contains(commingGuest))
                {
                    vipGuests.Remove(commingGuest);
                }
                else if (regularGuests.Contains(commingGuest))
                {
                    regularGuests.Remove(commingGuest);
                }
            }

            var totalMissedGuests = vipGuests.Count + regularGuests.Count;

            Console.WriteLine(totalMissedGuests);

            foreach (var guest in vipGuests)
            {
                Console.WriteLine(guest);
            }

            foreach (var guest in regularGuests)
            {
                Console.WriteLine(guest);
            }
        }
    }
}
