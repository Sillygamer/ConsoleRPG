using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public static class GameEngine
    {
        public static string Version = "0.0.3";
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
            if(_currentMonster != null)
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
                    standardMonster.RewardXP, standardMonster.RewardGold);

                foreach(Loot loot in standardMonster.LootTable)
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
            if(newLocation.IsHealing == true)
            {
                _player.CurrentHitPoints = _player.MaxHitPoints;
                Console.WriteLine("You have been healed");
            }
        }
    }


}
