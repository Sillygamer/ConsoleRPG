﻿using System;
//Andrea Compton 2022
namespace ConsoleRPG
{
    class Program
    {
        private static Player _player = new Player(10, 10, "NAme", 20, 0, 1);
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

            Inventory sword = new Inventory(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), 1);
            _player.Inventorry.Add(sword);



            while (true)
            {
                Console.Write("> ");
                string userImput = Console.ReadLine().Trim();
                if (string.IsNullOrWhiteSpace(userImput))
                {
                    continue;
                }
                string cleanedInput = userImput.ToLower();

                if (cleanedInput == "exit" || cleanedInput == "quit")
                {
                    break;
                }
                ParseInput(cleanedInput);

            }//end of while


        }//main
        public static void ParseInput(string input)
        {
            if (input.Contains("help") || input == "h")
            {
                //help
                Console.WriteLine("Help is coming later...stay tuned.");
            } else if (input.Contains("look") || input == "l")
            {
                // display current location
                DislayCurrentLocation();
            }
            else if (input.Contains("north") || input == "n")
            {
                //north
                _player.MoveNorth();
            }
            else if (input.Contains("south") || input == "s")
            {
                //south
                _player.MoveSouth();
            }
            else if (input.Contains("east") || input == "e")
            {
                //east
                _player.MoveEast();
            }
            else if (input.Contains("west") || input == "w")
            {
                //west
                _player.MoveWest();
            }
            else if (input.Contains("debug"))
            {
                Console.WriteLine("Developer Code:");
                string code = Console.ReadLine().Trim();
                if (code == "A12Bananna36")
                {
                    GameEngine.DebugInfo();

                }
                else
                {
                    Console.WriteLine("sorry wrong code");
                }
            }
            else if (input.Contains("inventory") || input == "i")
            {
                Console.WriteLine("Current Inventory:");
                foreach (Inventory invItem in _player.Inventorry)
                {
                    Console.WriteLine("\n\t{0} : {1}", invItem.Details.Name, invItem.Quantity);
                }
            }
            else if (input.Contains("stats"))
            {
                Console.WriteLine("\nStats for {0}", _player.Name);
                Console.WriteLine("\tHP: \t\t{0} out of {1}", _player.CurrentHitPoints, _player.MaxHitPoints);
                Console.WriteLine("\tXP: \t\t{0}", _player.XPPoints);
                Console.WriteLine("\tLevel: \t\t{0}", _player.Level);
                Console.WriteLine("\tGold: \t\t{0}", _player.Gold);
            }
            else if (input == "cheatcode")
            {
                Console.WriteLine("Developer Code:");
                string code = Console.ReadLine().Trim();
                if (code == "A2314rAinbOw11")
                {
                    while (true)
                    {
                        Console.Write("> ");
                        string userImput = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(userImput))
                        {
                            continue;
                        }
                        string cleanedInput = userImput.ToLower();

                        if (cleanedInput == "exit" || cleanedInput == "quit")
                        {
                            break;
                        }
                        else if (cleanedInput.Contains("give"))
                        {
                            Console.WriteLine("what would you like to give?");
                            string give = Console.ReadLine().Trim().ToLower();
                            if (give == "apass")
                            {
                                Console.WriteLine("Given apass");
                                Inventory aPass = new Inventory(World.ItemByID(World.ITEM_ID_ADVENTURER_PASS), 1);
                                _player.Inventorry.Add(aPass);
                            }
                            else
                            {
                                Console.WriteLine("More options coming soon!!!");
                            }
                        }
                    }

                } else if (code != "A2314rAinbOw11")
                {
                    Console.WriteLine("sorry wrong code");
                }
                else
                {
                    //anything else
                    Console.WriteLine("I don't understand. Sorry!");
                }
            }//end of parse
        }
        public static void DislayCurrentLocation()
        {
            Console.WriteLine("\nYou are at {0}", _player.CurrentLocation.Name);
            if (_player.CurrentLocation.Description != "")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description);
            }
        }

    } 
}
