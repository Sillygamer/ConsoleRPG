using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Location
    {
        public int ID;
        public string Name;
        public string Description;
        public Location LocationToNorth;
        public Location LocationToSouth;
        public Location LocationToeast;
        public Location LocationToWest;

        public Location(int iD, string name, string description)
        {
            ID = iD;
            Name = name;
            Description = description;
        }


    }


}
