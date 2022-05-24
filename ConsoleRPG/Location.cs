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
        public Item ItemRequiredToEnter;
        public Quests QuestAvailable;
        public Monster MonsterHere;
        public bool IsHealing;
        public Location LocationToNorth;
        public Location LocationToSouth;
        public Location LocationToeast;
        public Location LocationToWest;
        public Store StoreHere;

        public Location(int iD, string name, string description,
            Item itemRequiredToEnter = null, Quests questAvailable = null,
            Monster monsterHere = null, bool isHealing = false, Store storeHere = null)
        {
            ID = iD;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
        }


    }


}
