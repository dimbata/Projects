using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nether_Realms
{
    public class Startup
    {
        public static void Main()
        {
            List<Demon> demons = new List<Demon>();
            List<string> demonNames = Console.ReadLine().Split(',').Select(x => x.Trim()).ToList();
            foreach (var demonName in demonNames)
            {
                demons.Add(new Demon(demonName, CalculateHealth(demonName), CalculateDamage(demonName)));
            }
            var orderedDemons = demons.OrderBy(x => x.name);
            foreach (var demon in orderedDemons)
            {
                Console.WriteLine($"{demon.name} - {demon.health} health, {demon.damage:F2} damage");
            }
        }

        public static long CalculateHealth(string name)
        {
            char[] forbiddenChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '.' };
            long health = 0;
            foreach (var item in name)
            {
                if (!forbiddenChars.Contains(item))
                {
                    health += item;
                }
            }

            return health;
        }

        public static double CalculateDamage(string name)
        {
            double damage = 0;
            char[] allowedChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', '+', '-', '*', '/', '.' };
            List<string> numbers = new List<string>();
            List<char> modifiers = new List<char>();
            StringBuilder temp = new StringBuilder();
            for (int i = 0; i < name.Length; i++)
            {
                if (name[i] == '+' || name[i] == '-')
                {
                    temp.Append(name[i]);
                    while (i < name.Length - 1 && Char.IsDigit(name[i + 1]))
                    {
                        temp.Append(name[i + 1]);
                        i++;
                        if (i < name.Length - 1 && name[i + 1] == '.')
                        {
                            temp.Append('.');
                            i++;
                        }
                    }
                    numbers.Add(temp.ToString());
                    temp.Clear();

                }
                else if (Char.IsDigit(name[i]))
                {
                    temp.Append(name[i]);
                    while (i < name.Length - 1 && (Char.IsDigit(name[i + 1]) || name[i+1] == '.' ))
                    {
                        if (temp[temp.Length - 1] == '.' && name[i+1] == '.')
                        {
                            i++;
                            continue;
                        }
                        temp.Append(name[i + 1]);
                        i++;
                        
                    }
                    numbers.Add(temp.ToString());
                    temp.Clear();
                }
                else if (name[i] == '*' || name[i] == '/')
                {
                    modifiers.Add(name[i]);
                }
            }

            foreach (var number in numbers)
            {
                if (number == "-" || number == "+")
                {
                    continue;
                }
                damage += double.Parse(number.Trim('.'));
            }

            foreach (var modifier in modifiers)
            {
                if (modifier == '*')
                {
                    damage *= 2;
                }
                else
                {
                    damage /= 2;
                }
            }

            return damage;
        }
    }

    public class Demon
    {
        public string name;
        public long health;
        public double damage;

        public Demon(string name, long health, double damage)
        {
            this.name = name;
            this.health = health;
            this.damage = damage;
        }
    }
}
