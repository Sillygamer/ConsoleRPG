using System;
//Andrea Compton 2022
namespace ConsoleRPG
{
    class Program
    {
        private static Player _player = new Player();
        static void Main(string[] args)
        {
            GameEngine.Initialize();
            //name of player
            Console.WriteLine("What is your name?");
            string NAme = Console.ReadLine().Trim();
            Console.WriteLine("\nWelcome {0}", NAme);
            _player.Name = NAme;
            //list locations in world
           // World.ListLocations();
            //set location
            _player.MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
            /*display current location
                Location tmpLocation = _player.CurrentLocation;
                Console.WriteLine("\n\nYou are at {0}", tmpLocation.Name);
                Console.WriteLine("{0}\n",tmpLocation.Description);
            */
            while (true)
            {
                Console.Write("> ");
                string userImput = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(userImput))
                {
                    continue;
                }
                string cleanedInput = userImput.ToLower();

                if(cleanedInput == "exit"|| cleanedInput == "quit")
                {
                    break;
                }
                ParseInput(cleanedInput);

            }//end of while


        }//main
        public static void ParseInput(string input)
        {
            if (input.Contains("help"))
            {
                //help
                Console.WriteLine("Help is coming later...stay tuned.");
            } else if(input.Contains("look"))
            {
                // display current location
                DislayCurrentLocation();
            }
            else if(input.Contains("north"))
            {
                //north
                _player.MoveNorth();
            }
            else if (input.Contains("south"))
            {
                //south
                _player.MoveSouth();
            }
            else if (input.Contains("east"))
            {
                //east
                _player.MoveEast();
            }
            else if (input.Contains("west"))
            {
                //west
                _player.MoveWest();
            }
            else
            {
                //anything else
                Console.WriteLine("I don't understand. Sorry!");
            }
        }//end of parse

        private static void DislayCurrentLocation()
        {
            Console.WriteLine("\nYou are at {0}", _player.CurrentLocation.Name);
            if (_player.CurrentLocation.Description != "")
            {
                Console.WriteLine("{0}\n",_player.CurrentLocation.Description);
            }
        }
    }
}
