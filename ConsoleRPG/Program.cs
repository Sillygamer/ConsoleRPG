using System;
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
            }
            else if (input.Contains("look") || input == "l")
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
            else if (input.Contains("quests"))
            {
                if (_player.Quests.Count == 0)
                {
                    Console.WriteLine("You have no quests right now");
                }
                else
                {
                    foreach (PlayerQuests playerQuests in _player.Quests)
                    {
                        Console.WriteLine("{0}: {1}", playerQuests.Details.Name,
                            playerQuests.IsCompleted ? "Completed" : "Incomplete");
                        if (playerQuests.IsCompleted == false)
                        {
                            Console.WriteLine("{0}", playerQuests.Details.Description);
                            Console.WriteLine("Gold :{0}", playerQuests.Details.RewardGold);
                            Console.WriteLine("Xp: {0}", playerQuests.Details.RewardXP);
                            if (playerQuests.Details.RewardItem != null)
                            {
                                Console.WriteLine("Reward Item: {0}", playerQuests.Details.RewardItem.Name);
                            }
                        }
                        Console.WriteLine("\n\n");
                    }
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
                        Console.Write("Developer command> ");
                        string userImput = Console.ReadLine().Trim();
                        if (string.IsNullOrWhiteSpace(userImput))
                        {
                            continue;
                        }
                        string cleanedInput = userImput.ToLower();

                        if (cleanedInput == "exit" || cleanedInput == "quit")
                        {
                            Console.WriteLine("Exited cheatmode.");
                            break;
                        }
                        else if (cleanedInput.Contains("give"))
                        {
                            Console.WriteLine("what would you like to give?");
                            string give = Console.ReadLine().Trim().ToLower();
                            if (give == "apass")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory aPass = new Inventory(World.ItemByID(World.ITEM_ID_ADVENTURER_PASS), x);
                                _player.Inventorry.Add(aPass);
                                Console.WriteLine("Given apass");
                            }
                            else if (give == "potion")
                            {
                                Console.WriteLine("which potion would you like to give?");
                                string potion = Console.ReadLine().Trim().ToLower();
                                if (potion == "health")
                                {
                                    Console.WriteLine("How Many?");
                                    string Npotion = Console.ReadLine().Trim().ToLower();
                                    int x = Int32.Parse(Npotion);
                                    Console.WriteLine("Given health potion");
                                    Inventory healthPotion = new Inventory(World.ItemByID(World.ITEM_ID_HEALING_POTION), x);
                                    _player.Inventorry.Add(healthPotion);
                                }
                                else
                                {
                                    Console.WriteLine("More options coming soon!!!");
                                }
                            }
                            else if (give == "rat tail")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory ratTail = new Inventory(World.ItemByID(World.ITEM_ID_RAT_TAIL), x);
                                _player.Inventorry.Add(ratTail);
                                Console.WriteLine("Given rat tail");
                            }
                            else if (give == "fur")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory fur = new Inventory(World.ItemByID(World.ITEM_ID_PIECE_OF_FUR), x);
                                _player.Inventorry.Add(fur);
                                Console.WriteLine("Given fur");
                            }
                            else if (give == "snake skin")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory snakeSkin = new Inventory(World.ItemByID(World.ITEM_ID_SNAKESKIN), x);
                                _player.Inventorry.Add(snakeSkin);
                                Console.WriteLine("Given snake skin");
                            }
                            else if (give == "snake fang")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory snakeFang = new Inventory(World.ItemByID(World.ITEM_ID_SNAKE_FANG), x);
                                _player.Inventorry.Add(snakeFang);
                                Console.WriteLine("Given snake fang");
                            }
                            else if (give == "rusty sword")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory sword = new Inventory(World.ItemByID(World.ITEM_ID_RUSTY_SWORD), x);
                                _player.Inventorry.Add(sword);
                                Console.WriteLine("Given sword");
                            }
                            else if (give == "club")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory Club = new Inventory(World.ItemByID(World.ITEM_ID_CLUB), x);
                                _player.Inventorry.Add(Club);
                                Console.WriteLine("Given Club");
                            }
                            else if (give == "spider fang")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory spiderFang = new Inventory(World.ItemByID(World.ITEM_ID_SPIDER_FANG), x);
                                _player.Inventorry.Add(spiderFang);
                                Console.WriteLine("Given spider fang");
                            }
                            else if (give == "spider silk")
                            {
                                Console.WriteLine("How Many?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                Inventory spidersilk = new Inventory(World.ItemByID(World.ITEM_ID_SPIDER_SILK), x);
                                _player.Inventorry.Add(spidersilk);
                                Console.WriteLine("Given spider silk");
                            }
                            else
                            {
                                Console.WriteLine("More options coming soon!!!");
                            }//end of else

                        }//end of give
                        else if (cleanedInput == "heal")
                        {
                            _player.CurrentHitPoints = _player.MaxHitPoints;
                            Console.WriteLine("you have been healed");
                        }
                    }//end of while

                }//end of code
                else if (code != "A2314rAinbOw11")
                {
                    Console.WriteLine("sorry wrong code");
                }
            }//end of cheat mode
            else
            {
                //anything else
                Console.WriteLine("I don't understand. Sorry!");
            }
            
            }//end of parse
        public static void DislayCurrentLocation(Player _player)
        {
            Console.WriteLine("\nYou are at {0}", _player.CurrentLocation.Name);
            if (_player.CurrentLocation.Description != "")
            {
                Console.WriteLine("\t{0}\n", _player.CurrentLocation.Description);
            }
        }

    } 
}
