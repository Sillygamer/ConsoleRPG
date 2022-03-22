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

        public Item(int id, string name, string plName)
        {
            Id = id;
            Name = name;
            PlName = plName;
        }
        public Item()
        {

        }
    }
}
