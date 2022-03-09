using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class World
    {
        public static readonly string WorldName = "Minitopia";
        public static readonly List<Location> Locations = new List<Location>();

        public const int LOCATION_ID_HOME = 1;
        public const int LOCATION_ID_FOREST_PATH = 2;
        public const int LOCATION_ID_LAB = 3;

        static World()
        {
            PopulateLocations();
        }

        private static void PopulateLocations()
        {
            Location home = new Location(LOCATION_ID_HOME, "Home", "you sit by a fireplace on a comfy chair.");
            Location forestPath = new Location(LOCATION_ID_FOREST_PATH, "Forest Path", "a wooded path with lots of ferns");
            Location lab = new Location(LOCATION_ID_LAB, "Lab", "a lab with lots of beakers and experiments");

            home.LocationToNorth = forestPath;
            forestPath.LocationToeast = lab;
            lab.LocationToWest = forestPath;
            forestPath.LocationToSouth = home;

            Locations.Add(home);
            Locations.Add(forestPath);
            Locations.Add(lab);


        }

        public static void ListLocations()
        {
            Console.WriteLine("These are the locations in world: ");
            foreach(Location loc in Locations)
            {
                Console.WriteLine("\t{0}", loc.Name);
            }
        }
    }
}
