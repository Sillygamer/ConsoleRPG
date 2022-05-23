using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Item
    {
        public int Id;
        public string Name;
        public string PlName;
        public int BuyGold;
        public int SellGold;

        public Item(int id, string name, string plName, int buyGold, int sellGold)
        {
            Id = id;
            Name = name;
            PlName = plName;
            BuyGold = buyGold;
            SellGold = sellGold;
        }
        public Item()
        {

        }
    }
}
