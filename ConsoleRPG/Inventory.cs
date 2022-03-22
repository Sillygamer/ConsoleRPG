using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Inventory
    {
        public Item Details;
        public int Quantity;

        public Inventory(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
