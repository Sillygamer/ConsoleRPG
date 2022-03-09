using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class World
    {
        public static readonly string WorldName = "Minitopia";
        public static readonly`List<Location> Locations = new List<Location>();

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_FOREST_PATH = 2;
        public const int LOCATION_ID_LAB = 3;

        static World()
        {

        }
    }
}
