using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DragonArmy
{
    public class DragonStats
    {
        public int damage;
        public int health;
        public int armor;

        public DragonStats(int damage, int health, int armor)
        {
            this.damage = damage;
            this.health = health;
            this.armor = armor;
        }
    }

    public class DragonArmy
    {
        public static void Main()
        {
            var dragonsInfo = 
                new Dictionary<string, Dictionary<string, DragonStats>>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().
                    Split(new char[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries).
                    ToArray();

                var type = tokens[0];
                var name = tokens[1];
                var damage = 0;
                var health = 0;
                var armor = 0;

                if (tokens[2] != "null")
                {
                    damage = int.Parse(tokens[2]);
                }
                else
                {
                    damage = 45;
                }

                if (tokens[3] != "null")
                {
                    health = int.Parse(tokens[3]);
                }
                else
                {
                    health = 250;
                }

                if (tokens[4] != "null")
                {
                    armor = int.Parse(tokens[4]);
                }
                else
                {
                    armor = 10;
                }

                var dragonStats = new DragonStats(damage, health, armor);

                if (!dragonsInfo.ContainsKey(type))
                {
                    dragonsInfo[type] = new Dictionary<string, DragonStats>();
                }

                dragonsInfo[type][name] = dragonStats;
            }

            foreach (var dragonType in dragonsInfo)
            {
                var averageDamage = dragonType.Value.
                    Average(x => x.Value.damage);

                var averageHealth = dragonType.Value.
                    Average(x => x.Value.health);

                var averageArmor = dragonType.Value.
                    Average(x => x.Value.armor);

                Console.WriteLine("{0}::({1:f2}/{2:f2}/{3:f2})",
                    dragonType.Key,
                    averageDamage,
                    averageHealth,
                    averageArmor);

                foreach (var dragon in dragonType.Value.OrderBy(x => x.Key))
                {
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}",
                        dragon.Key,
                        dragon.Value.damage,
                        dragon.Value.health,
                        dragon.Value.armor);
                }
            }
        }
    }
}
