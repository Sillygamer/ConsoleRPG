using System;
using System.Linq;
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
                Console.WriteLine("\nYou can move 'north', 'south', 'east', or 'west' ('n', 's', 'e', 'w')." +
                    "\nUse 'a' or 'attack' to  hit your opponent." +
                    "\nSay 'equip (weapon name)' to equip a weapon." +
                    "\nSay 'l' or 'look' to see your surroundings." +
                    "\nSay 'i' to see your inventory." +
                    "\nSay 'stats' to see currnt info." +
                    "\nSay 'talk' to start quests and shop");
            }
            else if (input.Contains("look") || input == "l")
            {
                // display current location
                DislayCurrentLocation(_player);
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
                    Console.WriteLine("Self destruct in 3.. 2.. 1..");
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
                    Console.WriteLine("You can't make a quest from thin air");
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
                                    Console.WriteLine("Are you trying to make your own potion?");
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
                            else if (give == "Gold")
                            {
                                Console.WriteLine("How Much?");
                                string Number = Console.ReadLine().Trim().ToLower();
                                int x = Int32.Parse(Number);
                                _player.Gold += x;
                                Console.WriteLine("Given gold");
                            }
                            else
                            {
                                Console.WriteLine("Are you trying to make your own item?");
                            }//end of else

                        }//end of give
                        else if (cleanedInput == "heal")
                        {
                            _player.CurrentHitPoints = _player.MaxHitPoints;
                            Console.WriteLine("You are healed now get on with your life.");
                        }
                    }//end of while

                }//end of code
                else if (code != "A2314rAinbOw11")
                {
                    Console.WriteLine("Self destruct in 3.. 2.. 1..");
                }
            }//end of cheat mode
            else if (input.Contains("attack") || input == "a")
            {
                if (_player.CurrentLocation.MonsterHere == null)
                {
                    Console.WriteLine("Are you trying to attack air? There is nothing there!");
                }
                else
                {
                    if (_player.CurrentWeapon == null)
                    {
                        Console.WriteLine("You can't attack with your bare fists!!!");
                    }
                    else
                    {
                        _player.UseWeapon(_player.CurrentWeapon, _player.CurrentLocation);
                    }
                }
            }
            else if (input.StartsWith("equip "))
            {
                _player.UpdateWeapons();
                string inputWeaponName = input.Substring(6).Trim();
                if (string.IsNullOrEmpty(inputWeaponName))
                {
                    Console.WriteLine("You can't equip air!");
                }
                else
                {
                    Weapon weaponToEquip = _player.Weapons.SingleOrDefault(x => x.Name.ToLower() == inputWeaponName || x.PlName.ToLower() == inputWeaponName);

                    if (weaponToEquip == null)
                    {
                        Console.WriteLine("You can't make a weapon up!!");
                    }
                    else
                    {
                        _player.CurrentWeapon = weaponToEquip;
                        Console.WriteLine("Equiped your {0}. Hope you don't die.", _player.CurrentWeapon.Name);
                    }
                }
            }
            else if (input.StartsWith("use "))
            {
                string inputName = input.Substring(4).Trim();
                if (string.IsNullOrEmpty(inputName))
                {
                    Console.WriteLine("You can't drink air!");
                }
                else
                {
                    Inventory thing = _player.Inventorry.SingleOrDefault(x => x.Details.Name.ToLower() == inputName || x.Details.PlName.ToLower() == inputName);
                    if (thing == null)
                    {
                        Console.WriteLine("You can't make a potion up!!");
                    }
                    else
                    {
                        if (thing.Details.Name == "Monster Spawner" || thing.Details.PlName == "Monster Spawners")
                        {
                            GameEngine.UseSpawner(_player, _player.CurrentLocation);
                        }
                        else
                        {
                            Console.WriteLine("You can't use that!!");
                        }
                    }
                }
            }
            else if (input.StartsWith("drink "))
            {
                _player.UpdatePotions();
                string inputItemName = input.Substring(6).Trim();
                if (string.IsNullOrEmpty(inputItemName))
                {
                    Console.WriteLine("You can't drink air!");
                }
                else
                {
                    Potion ItemToUse = _player.Potions.SingleOrDefault(x => x.Name.ToLower() == inputItemName || x.PlName.ToLower() == inputItemName);
                    Inventory Potion = _player.Inventorry.SingleOrDefault(x => x.Details.Name.ToLower() == inputItemName || x.Details.PlName.ToLower() == inputItemName);
                    if (ItemToUse == null)
                    {
                        Console.WriteLine("You can't make a potion up!!");
                    }
                    else if (ItemToUse.AmountToHeal >= 1)
                    {
                        if (_player.CurrentHitPoints == _player.MaxHitPoints)
                        {
                            Console.WriteLine("You already have maximum health!");
                        }
                        else
                        {
                            Console.WriteLine("you have healed {0} hit points", ItemToUse.AmountToHeal);

                            _player.CurrentHitPoints += ItemToUse.AmountToHeal;
                            _player.Inventorry.Remove(Potion);
                            _player.Potions.Remove(ItemToUse);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Can't use that!");
                    }
                }
            }
            else if (input == "weapons")
            {
                _player.UpdateWeapons();
                Console.WriteLine("List of Weapons");
                foreach (Weapon w in _player.Weapons)
                {
                    Console.WriteLine("\t{0}", w.Name);
                }
            }
            else if (input == "talk")
            {
                
                if (_player.CurrentLocation.QuestAvailable != null)
                {
                    
                    Console.WriteLine("hello {0}, would you like to talk about quests?",_player.Name);
                    String option = Console.ReadLine().Trim().ToLower();
                    if (option == "y" || option == "yes")
                    {
                        GameEngine.QuestProcessor(_player, _player.CurrentLocation);
                    }//end of quest
                    else if (option == "n" || option == "no")
                    {
                        if (_player.CurrentLocation.StoreHere != null)
                        {

                            Console.WriteLine("Hi {0},would you like to go the the shop?", _player.Name);
                            String option2 = Console.ReadLine().Trim().ToLower();
                            if (option2 == "y" || option2 == "yes")
                            {
                                GameEngine.Stores(_player, _player.CurrentLocation);
                            }//end of store
                            else if (option2 == "n" || option2 == "no")
                            {
                                Console.WriteLine("Bye {0}", _player.Name);
                            }//no goodbye
                            else
                            {
                                Console.WriteLine("Its a yes or no question");
                            }//end of store question
                        }//end of no
                        else
                        {
                            Console.WriteLine("Bye {0}", _player.Name);
                        }//end of talk



                    }
                    else
                    {
                        Console.WriteLine("Its a yes or no question");
                    }

                }
                else
                {
                    if (_player.CurrentLocation.Name == "Town square")
                    {

                        Console.WriteLine("hi {0},Would you like to go the the shop?",_player.Name);
                        string option2 = Console.ReadLine().Trim().ToLower();
                        if (option2 == "y" || option2 == "yes")
                        {
                            GameEngine.Stores(_player, _player.CurrentLocation);
                        }//end of store
                        else if (option2 == "n" || option2 == "no")
                        {
                            Console.WriteLine("Bye {0}",_player.Name);
                        }//no goodbye
                        else
                        {
                        Console.WriteLine("Its a yes or no question");
                        }//end of store question
                    }
                }

            }
            else
            {
                //anything else
                Console.WriteLine("What language is that?!");
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
