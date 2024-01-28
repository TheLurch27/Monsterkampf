using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void Attack(Monster target)
        {
            float damage = AP - target.DP;
            damage = Math.Max(damage, 0);

            target.HP -= damage;
            Console.WriteLine($"{Race} attacks and deals {damage} damage to {target.Race}.");
        }
    }
}
