using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Potion: Item
    {
        public int AmountToHeal;

        public Potion(int id, string name, string plName, int buyGold, int sellGold, int amountToHeal):base(id, name, plName, buyGold, sellGold)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
