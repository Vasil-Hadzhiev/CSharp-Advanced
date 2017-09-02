namespace _01.CubicArtillery
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CubicArtillery
    {
        public static void Main()
        {
            var bunkerCapacity = int.Parse(Console.ReadLine());

            var bunkers = new Queue<char>();
            var weapons = new Queue<int>();

            var freeCapacity = bunkerCapacity;

            while (true)
            {
                var inputLine = Console.ReadLine();

                if (inputLine == "Bunker Revision")
                {
                    break;
                }

                var tokens = inputLine
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int i = 0; i < tokens.Length; i++)
                {
                    var currentToken = tokens[i];

                    var n = 0;

                    if (int.TryParse(currentToken, out n))
                    {
                        var weaponCapacity = int.Parse(currentToken);

                        var isWeaponContained = false;

                        while (bunkers.Count > 1)
                        {
                            if (freeCapacity >= weaponCapacity)
                            {
                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                                isWeaponContained = true;
                                break;
                            }

                            if (weapons.Count == 0)
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> Empty");
                            }
                            else
                            {
                                Console.WriteLine($"{bunkers.Peek()} -> {string.Join(", ", weapons)}");
                            }

                            bunkers.Dequeue();
                            weapons.Clear();
                            freeCapacity = bunkerCapacity;
                        }

                        if (!isWeaponContained && bunkers.Count == 1)
                        {
                            if (bunkerCapacity >= weaponCapacity)
                            {
                                if (freeCapacity < weaponCapacity)
                                {
                                    while (freeCapacity < weaponCapacity)
                                    {
                                        var removedWeapon = weapons.Dequeue();
                                        freeCapacity += removedWeapon;
                                    }
                                }

                                weapons.Enqueue(weaponCapacity);
                                freeCapacity -= weaponCapacity;
                            }
                        }
                    }
                    else
                    {
                        bunkers.Enqueue(char.Parse(currentToken));
                    }
                }
            }
        }
    }
}