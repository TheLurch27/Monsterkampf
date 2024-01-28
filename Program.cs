using System.Threading;

namespace Monsterkampf_Kevin
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose 2 Characters for the fight: ");
            
            Console.WriteLine("1 - Troll");
            Console.WriteLine("2 - Wizard");
            Console.WriteLine("3 - Goblin");

            int choice1, choice2;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Choose Character 1: ");
                choice1 = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Choose Character 2: ");
                choice2 = int.Parse(Console.ReadLine());

                if (choice1 == choice2)
                {
                    Console.WriteLine("The monsters cannot be the same race. Please select again.");
                    Console.ReadKey();
                    Console.Clear();


                }
            } while (choice1 == choice2);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Enter the attributes for Monster 1 (Life points (HP), Attack strength (AP), Defense points (DP), Speed (S)): ");
            Console.Write("HP = ");
            float hp1 = float.Parse(Console.ReadLine());
            Console.Write("AP = ");
            float ap1 = float.Parse(Console.ReadLine());
            Console.Write("DP = ");
            float dp1 = float.Parse(Console.ReadLine());
            Console.Write("S = ");
            float s1 = float.Parse(Console.ReadLine());

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Enter the attributes for Monster 2 (Life points (HP), Attack strength (AP), Defense points (DP), Speed (S)): ");
            Console.Write("HP = ");
            float hp2 = float.Parse(Console.ReadLine());
            Console.Write("AP = ");
            float ap2 = float.Parse(Console.ReadLine());
            Console.Write("DP = ");
            float dp2 = float.Parse(Console.ReadLine());
            Console.Write("S = ");
            float s2 = float.Parse(Console.ReadLine());
            Console.ForegroundColor = ConsoleColor.White;

            Monster monster1 = null;
            Monster monster2 = null;

            // Das erste arme Schwein ähh Monster wird erstellt.
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

            // Hier wird das zweite Monster für den Kampf erstellt. (Macht ja sonst auch keinen Sinn) ^^
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
                    monster1.Attack(monster2);
                    if (monster2.HP > 0)
                    {
                        monster2.Attack(monster1);
                    }
                }
                else
                {
                    monster2.Attack(monster1);
                    if (monster1.HP > 0)
                    {
                        monster1.Attack(monster2);
                    }
                }

                round++;
            }
            if (monster1.HP <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{monster2.Race} wins the fight in {round - 1} Rounds!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"{monster1.Race} wins the fight in {round - 1} Rounds!");
            }
        }
    }
}