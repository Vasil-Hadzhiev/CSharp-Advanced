using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandsOfCards
{
    public class HandsOfCards
    {
        public static void Main()
        {
            var cardsPower = new Dictionary<char, int>()
            {
                {'2', 2 },
                {'3', 3 },
                {'4', 4 },
                {'5', 5 },
                {'6', 6 },
                {'7', 7 },
                {'8', 8 },
                {'9', 9 },
                {'J', 11 },
                {'Q', 12 },
                {'K', 13 },
                {'A', 14 }
            };

            var cardType = new Dictionary<char, int>()
            {
                {'S', 4 },
                {'H', 3 },
                {'D', 2 },
                {'C', 1 }
            };

            var players = new Dictionary<string, HashSet<string>>();

            var playerScore = new Dictionary<string, int>();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "JOKER")
                {
                    break;
                }

                var tokens = input.Split(':');

                var name = tokens[0];
                var cards = tokens[1].
                    Split(new char[] { ' ', ',' },
                    StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                if (!players.ContainsKey(name))
                {
                    players[name] = new HashSet<string>();
                }

                if (!playerScore.ContainsKey(name))
                {
                    playerScore[name] = 0;
                }

                foreach (var card in cards)
                {
                    players[name].Add(card);
                }                 
            }

            foreach (var player in players)
            {
                var totalPower = 0;

                foreach (var card in player.Value)
                {
                    if (card.Length == 2)
                    {
                        var power = card[0];
                        var type = card[1];

                        totalPower += (cardsPower[power] * cardType[type]);
                    }
                    else
                    {
                        var type = card[2];
                        totalPower += (10 * cardType[type]);
                    }
                }

                playerScore[player.Key] = totalPower;
            }

            foreach (var player in playerScore)
            {
                Console.WriteLine($"{player.Key}: {player.Value}");
            }
        }
    }
}
