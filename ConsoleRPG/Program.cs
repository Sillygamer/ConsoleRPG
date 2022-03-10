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
            World.ListLocations();
            //current location
            Location tmpLocation = World.LocationByID(1);
            Console.WriteLine("\n\nYou are at {0}", tmpLocation.Name);
            Console.WriteLine(tmpLocation.Description);

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
                Console.WriteLine("Help is coming later...stay tuned.");
            }
        }
    }
}
