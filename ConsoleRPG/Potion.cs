using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Potion: Item
    {
        public int AmountToHeal;

        public Potion(int id, string name, string plName, int amountToHeal):base(id, name, plName)
        {
            AmountToHeal = amountToHeal;
        }
    }
}
