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
            Location home = new Location(LOCATION_ID_HOME, "Home", "You sit by a fireplace on a comfy chair.");
            Location forestPath = new Location(LOCATION_ID_FOREST_PATH, "A Forest Path", "A wooded path with lots of ferns");
            Location lab = new Location(LOCATION_ID_LAB, "The Lab", "A lab with lots of beakers and experiments");

            home.LocationToNorth = forestPath;
            forestPath.LocationToeast = lab;
            lab.LocationToWest = forestPath;
            forestPath.LocationToSouth = home;

            Locations.Add(home);
            Locations.Add(forestPath);
            Locations.Add(lab);


        }

        public static Location LocationByID(int id)
        {
            foreach (Location loc in Locations)
            {
                if (loc.ID == id)
                {
                    return loc;
                }
            }
            return null;
        }


        public static void ListLocations()
        {
            Console.WriteLine("\n\nThese are the locations in the world: ");
            foreach(Location loc in Locations)
            {
                Console.WriteLine("\t{0}", loc.Name);
            }
        }
    }
}
