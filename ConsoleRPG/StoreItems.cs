using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class StoreItems
    {
        public Item Details;
        public int Quantity;

        public StoreItems(Item details, int quantity)
        {
            Details = details;
            Quantity = quantity;
        }
    }
}
