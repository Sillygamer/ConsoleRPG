using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Weapon : Item
    {
        public int MaxDamage;
        public int MinDamage;

        public Weapon(int id, string name, string plName, int buyGold, int sellGold, int maxDamage, int minDamage):base(id, name, plName, buyGold, sellGold)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
        }
    }
}
