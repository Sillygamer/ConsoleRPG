using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Loot
    {
        public Item Details;
        public int DropRate;
        public bool IsDefault;

        public Loot(Item details, int dropRate, bool isDefault)
        {
            Details = details;
            DropRate = dropRate;
            IsDefault = isDefault;
        }
    }
}
