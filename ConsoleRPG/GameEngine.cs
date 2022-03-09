using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.1";

        public static void Initialize()
        {
            Console.WriteLine("Initializing game engine version {0}", Version);
            Console.WriteLine("\n\nWelcome to {0}", World.WorldName);
            Console.WriteLine();
        }
    }
}
