using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Player
    {
        public string Name { set; get; }
        public Location CurrentLocation { set; get; }

        public void MoveTo(Location loc)
        {
            CurrentLocation = loc;
        }

        public void MoveNorth()
        {
            if (CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
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
            }
            else
            {
                Console.WriteLine("You can't move west");
            }
        }//move west


    }//end of class player
}
