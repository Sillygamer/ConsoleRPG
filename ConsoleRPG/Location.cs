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
        public Location LocationToNorth;
        public Location LocationToSouth;
        public Location LocationToeast;
        public Location LocationToWest;

        public Location(int iD, string name, string description,
            Item itemRequiredToEnter = null, Quests questAvailable = null,
            Monster monsterHere = null)
        {
            ID = iD;
            Name = name;
            Description = description;
            ItemRequiredToEnter = itemRequiredToEnter;
        }


    }


}
