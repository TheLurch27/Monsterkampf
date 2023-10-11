using System.Threading;

namespace Monsterkampf_Kevin
{
    class Monster
    {
        public float HP { get; set; }
        public float AP { get; set; }
        public float DP { get; set; }
        public float S { get; set; }
        public string Race { get; set; }

        public Monster(float hP, float aP, float dP, float s, string race)
        {
            HP = hP;
            AP = aP;
            DP = dP;
            S = s;
            Race = race;
        }

        public void attack(Monster target)
        {
            float damage = AP - target.DP;
            damage = Math.Max(damage, 0);

            target.HP -= damage;
            Console.WriteLine($"{Race} attacks and deals {damage} damage to {target.Race}.");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose 2 Character for the fight: ");
            Console.WriteLine("1 - Troll");
            Console.WriteLine("2 - Wizard");
            Console.WriteLine("3 - Goblin");

            int choice1, choice2;
            do
            {
                Console.Write("Choose Character 1: ");
                choice1 = int.Parse(Console.ReadLine());

                Console.Write("Choose Character 2: ");
                choice2 = int.Parse(Console.ReadLine());

                if (choice1 == choice2)
                {
                    Console.WriteLine("The monsters cannot be the same race. Please select again.");
                }
            } while (choice1 == choice2);

            Console.WriteLine("Enter the attributes for Monster 1 (HP, AP, DP, S): ");
            float hp1 = float.Parse(Console.ReadLine());
            float ap1 = float.Parse(Console.ReadLine());
            float dp1 = float.Parse(Console.ReadLine());
            float s1 = float.Parse(Console.ReadLine());

            Console.WriteLine("Enter the attributes for Monster 2 (HP, AP, DP, S): ");
            float hp2 = float.Parse(Console.ReadLine());
            float ap2 = float.Parse(Console.ReadLine());
            float dp2 = float.Parse(Console.ReadLine());
            float s2 = float.Parse(Console.ReadLine());

            Monster monster1 = null;
            Monster monster2 = null;

            switch (choice1)
            {
                case 1:
                    monster1 = new Monster(hp1, ap1, dp1, s1, "Troll");
                    break;
                case 2:
                    monster1 = new Monster(hp1, ap1, dp1, s1, "Wizard");
                    break;
                case 3:
                    monster1 = new Monster(hp1, ap1, dp1, s1, "Goblin");
                    break;
            }

            switch (choice2)
            {
                case 1:
                    monster2 = new Monster(hp2, ap2, dp2, s2, "Troll");
                    break;
                case 2:
                    monster2 = new Monster(hp2, ap2, dp2, s2, "Wizard");
                    break;
                case 3:
                    monster2 = new Monster(hp2, ap2, dp2, s2, "Goblin");
                    break;
            }

            int round = 1;
            while (monster1.HP > 0 && monster2.HP > 0)
            {
                Console.WriteLine($"Round {round}:");

                if (monster1.S >= monster2.S)
                {
                    monster1.attack(monster2);
                    if (monster2.HP > 0)
                    {
                        monster2.attack(monster1);
                    }
                }
                else
                {
                    monster2.attack(monster1);
                    if (monster1.HP > 0)
                    {
                        monster1.attack(monster2);
                    }
                }

                round++;
            }
            if (monster1.HP <= 0)
            {
                Console.WriteLine($"{monster2.Race} wins the fight in {round - 1} Rounds!");
            }
            else
            {
                Console.WriteLine($"{monster1.Race} wins the fight in {round - 1} Rounds!");
            }
        }
    }
}