using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Store
    {
        public int Id;
        public string Name;
        public string Description;
        public List<StoreItems> storeItems;

        public Store(int id, string name, string description, List<StoreItems> storeItems)
        {
            Id = id;
            Name = name;
            Description = description;
            this.storeItems = storeItems;
        }

        public Store(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
            storeItems = new List<StoreItems>();
        }
    }
}
