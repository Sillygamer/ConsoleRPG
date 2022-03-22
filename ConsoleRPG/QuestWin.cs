using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class QuestWin
    {
        public Item Details;
        public int Quantity;

        public QuestWin(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
