using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Player: Creature
    {
        public string Name;
        public int Gold;
        public int XPPoints;
        public int Level;
        public Location CurrentLocation;
        public List<Inventory> Inventorry;
        public List<PlayerQuests> Quests;

        public Player(int currentHitPoints, int maxHitPoints, 
            string name, int gold, int xPPoints, int level)
            :base (currentHitPoints, maxHitPoints)
        {
            Name = name;
            Gold = gold;
            XPPoints = xPPoints;
            Level = level;
            Inventorry = new List<Inventory>();
            Quests = new List<PlayerQuests>();
        }
        public Player() { }

        public void MoveTo(Location loc)
        {
            if (loc.ItemRequiredToEnter != null)
            {
                bool playerHasRequireditem = false;
                foreach(Inventory ii in this.Inventorry)
                {
                    if(ii.Details.Id == loc.ItemRequiredToEnter.Id)
                    {
                        playerHasRequireditem = true;
                        break;
                    }
                }
                if (!playerHasRequireditem)
                {
                    Console.WriteLine("You must have a {0} to enter", loc.ItemRequiredToEnter.Name);
                    return;
                }
            }

            CurrentLocation = loc;
        }

        public void MoveNorth()
        {
            if (CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
                Program.DislayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You can't move north");
            }
        }//move north
        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
                Program.DislayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You can't move south");
            }
        }//move south
        public void MoveEast()
        {
            if (CurrentLocation.LocationToeast != null)
            {
                MoveTo(CurrentLocation.LocationToeast);
                Program.DislayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You can't move east");
            }
        }//move east
        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
                Program.DislayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You can't move west");
            }
        }//move west


    }//end of class player
}
