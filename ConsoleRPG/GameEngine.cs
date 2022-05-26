using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.6";
        public static Monster _currentMonster;
        public static void Initialize()
        {
            Console.WriteLine("Initializing game engine version {0}", Version);
            Console.WriteLine("\n\nWelcome to {0}", World.WorldName);
            Console.WriteLine();
        }

        public static void DebugInfo()
        {
            World.ListLocations();
            World.ListItems();
            World.ListMonsters();
            World.ListQuests();
            if (_currentMonster != null)
            {
                Console.WriteLine("Current Monster: {0}", _currentMonster.Name);
            }
            else
            {
                Console.WriteLine("There are no current monsters.");
            }

        }
        //quests
        public static void QuestProcessor(Player _player, Location newLocation)
        {
            string questMessage;
            // Does the location have a quest?
            if (newLocation.QuestAvailable != null)
            {
                // See if the player already has the quest, and if they've completed it
                bool playerAlreadyHasQuest = _player.HasThisQuest(newLocation.QuestAvailable);
                bool playerAlreadyCompletedQuest = _player.CompletedThisQuest(newLocation.QuestAvailable);

                // See if the player already has the quest
                if (playerAlreadyHasQuest)
                {
                    // If the player has not completed the quest yet
                    if (!playerAlreadyCompletedQuest)
                    {
                        // See if the player has all the items needed to complete the quest
                        bool playerHasAllItemsToCompleteQuest = _player.HasAllQuestCompletionItems(newLocation.QuestAvailable);

                        // The player has all items required to complete the quest
                        if (playerHasAllItemsToCompleteQuest)
                        {
                            // Display message
                            questMessage = Environment.NewLine;
                            questMessage += "You complete the '" + newLocation.QuestAvailable.Name + "' quest." + Environment.NewLine;

                            // Remove quest items from inventory
                            _player.RemoveQuestCompletionItems(newLocation.QuestAvailable);

                            // Give quest rewards
                            questMessage += "You receive: " + Environment.NewLine;
                            questMessage += newLocation.QuestAvailable.RewardXP.ToString() + " experience points" + Environment.NewLine;
                            questMessage += newLocation.QuestAvailable.RewardGold.ToString() + " gold" + Environment.NewLine;
                            questMessage += newLocation.QuestAvailable.RewardItem.Name + Environment.NewLine;
                            questMessage += Environment.NewLine;
                            Console.WriteLine(questMessage);

                            _player.XPPoints += newLocation.QuestAvailable.RewardXP;
                            _player.Gold += newLocation.QuestAvailable.RewardGold;

                            // Add the reward item to the player's inventory
                            _player.AddItemToInventory(newLocation.QuestAvailable.RewardItem);

                            // Mark the quest as completed
                            _player.MarkQuestCompleted(newLocation.QuestAvailable);
                        }
                    }
                }
                else
                {
                    // The player does not already have the quest

                    // Display the messages
                    questMessage = "You receive the " + newLocation.QuestAvailable.Name + " quest." + Environment.NewLine;
                    questMessage += newLocation.QuestAvailable.Description + Environment.NewLine;
                    questMessage += "To complete it, return with:" + Environment.NewLine;
                    foreach (QuestWin qci in newLocation.QuestAvailable.QuestWins)
                    {
                        if (qci.Quantity == 1)
                        {
                            questMessage += qci.Quantity.ToString() + " " + qci.Details.Name + Environment.NewLine;
                        }
                        else
                        {
                            questMessage += qci.Quantity.ToString() + " " + qci.Details.PlName + Environment.NewLine;
                        }
                    }
                    questMessage += Environment.NewLine;
                    Console.WriteLine(questMessage);

                    // Add the quest to the player's quest list
                    _player.Quests.Add(new PlayerQuests(newLocation.QuestAvailable, false));
                }
            }


        } //QuestProcessor

        public static void Stores(Player _player, Location location)
        {
            string storeMessage = "";

            if (location.Name == "Town square")
            {
                while (true)
                {
                    storeMessage += "\n1. weapon store";
                    storeMessage += "\n2. Potion Store";
                    storeMessage += "\n3. Magic Store";
                    storeMessage += "\n4. Item store";
                    Console.WriteLine(storeMessage);
                    Console.WriteLine("Which store would you like to go to?");
                    string storename = Console.ReadLine().Trim();
                    if (storename == "1")
                    {
                        location.StoreHere = World.StoreByID(1);

                    }
                    else if (storename == "2")
                    {
                        location.StoreHere = World.StoreByID(2);
                    }
                    else if (storename == "3")
                    {
                        location.StoreHere = World.StoreByID(3);
                    }
                    else if (storename == "4")
                    {
                        location.StoreHere = World.StoreByID(4);
                    }
                    else if (storename == "exit")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please choose a number to go to");
                    }//end of change stores

                    string store = "";

                    store += "\n 1. Buy \n2. Sell \n3. exit";
                    Console.WriteLine(store);
                    Console.WriteLine("\n What would you like to do?");
                    string answer = Console.ReadLine().Trim();
                    if (answer == "1")
                    {
                        while (true)
                        {
                            foreach (StoreItems si in location.StoreHere.storeItems)
                            {
                                Console.WriteLine("\n{0} : {1}", si.Details.Name, si.Quantity);
                                Console.WriteLine("\n\tprice: {1}", si.Details.BuyGold);
                            }
                            Console.WriteLine("\nWhat would you like to buy");
                            string buying = Console.ReadLine().Trim();
                            if (buying == "exit")
                            {
                                break;
                            }
                            StoreItems buyingItem = location.StoreHere.storeItems.SingleOrDefault(x => x.Details.Name.ToLower() == buying || x.Details.PlName.ToLower() == buying);
                            if (buyingItem == null)
                            {
                                Console.WriteLine("you cant make an item up");
                            }
                            else
                            {
                                Console.WriteLine("How Many?");
                                string number = Console.ReadLine().Trim();

                                int result = Int32.Parse(number);
                                Inventory stuff = new Inventory(World.ItemByID(buyingItem.Details.Id), result);
                                _player.Inventorry.Add(stuff);
                                buyingItem.Quantity -= result;
                                _player.Gold -= buyingItem.Details.BuyGold * result;
                                Console.WriteLine("{0} Bought", buyingItem.Details.Name);
                            }



                        }
                    }
                    else if (answer == "2")
                    {
                        while (true)
                        {
                            foreach (Inventory ii in _player.Inventorry)
                            {
                                Console.WriteLine("\n{0} : {1}", ii.Details.Name, ii.Quantity);
                                Console.WriteLine("\n\tselling price: {1}", ii.Details.SellGold);
                            }
                            Console.WriteLine("\nWhat would you like to sell");
                            string selling = Console.ReadLine().Trim();
                            if (selling == "exit")
                            {
                                break;
                            }
                            Inventory sellingItem = _player.Inventorry.SingleOrDefault(x => x.Details.Name.ToLower() == selling || x.Details.PlName.ToLower() == selling);
                            if (sellingItem == null)
                            {
                                Console.WriteLine("you cant make an item up");
                            }
                            else
                            {
                                Console.WriteLine("How Many?");
                                string number = Console.ReadLine().Trim();

                                int result = Int32.Parse(number);



                                sellingItem.Quantity -= result;
                                if (sellingItem.Quantity == 0)
                                {
                                    _player.Inventorry.Remove(sellingItem);
                                }
                                _player.Gold += sellingItem.Details.SellGold * result;
                                Console.WriteLine("{0} sold", sellingItem.Details.Name);
                            }
                        }


                    }
                    else if (answer == "3")
                    {
                        break;
                    }

                }

            }
        }



        public static void MonsterProcessor(Player _player, Location newLocation)
        {
            string monstermessage = "";
            if (newLocation.MonsterHere != null)
            {
                monstermessage += "You see a " + newLocation.MonsterHere.Name + "\n";
                Console.WriteLine(monstermessage);
                Monster standardMonster = World.MonsterByID(newLocation.MonsterHere.Id);
                _currentMonster = new Monster(standardMonster.CurrentHitPoints, standardMonster.MaxHitPoints, standardMonster.Name,
                    standardMonster.Id, standardMonster.MaxDamage, standardMonster.MinDamage,
                    standardMonster.RewardXP, standardMonster.RewardGold, standardMonster.HitRate);

                foreach (Loot loot in standardMonster.LootTable)
                {
                    _currentMonster.LootTable.Add(loot);
                }
            }
            else
            {
                _currentMonster = null;
            }
        }// end of monster


        public static void Heal(Player _player, Location newLocation)
        {
            if (newLocation.IsHealing == true)
            {
                _player.CurrentHitPoints = _player.MaxHitPoints;
                Console.WriteLine("You have been healed");
            }
        }

        public static void UseSpawner(Player _player, Location location)
        {
            if (location.Name == "Alchemist's garden")
            {
                location.MonsterNumber = 5;
                location.MonsterHere = World.MonsterByID(World.MONSTER_ID_RAT);

            }
            else if (location.Name == "Farmer's field")
            {
                location.MonsterNumber = 6;
                location.MonsterHere = World.MonsterByID(World.MONSTER_ID_SNAKE);
            }
            else if (location.Name == "Forest")
            {
                location.MonsterNumber = 7;
                location.MonsterHere = World.MonsterByID(World.MONSTER_ID_GIANT_SPIDER);
            }
            else
            {
                int monsterType = RandomNumberGenerator.NumberBetween(1, 3);
                if (monsterType == 1)
                {
                    location.MonsterNumber = RandomNumberGenerator.NumberBetween(1, 10);
                    location.MonsterHere = World.MonsterByID(World.MONSTER_ID_RAT);
                }
                else if (monsterType == 2)
                {
                    location.MonsterNumber = RandomNumberGenerator.NumberBetween(1, 10);
                    location.MonsterHere = World.MonsterByID(World.MONSTER_ID_SNAKE);
                }
                else
                {
                    location.MonsterNumber = RandomNumberGenerator.NumberBetween(1, 10);
                    location.MonsterHere = World.MonsterByID(World.MONSTER_ID_GIANT_SPIDER);
                }
            }
        }
    }  
}


  


