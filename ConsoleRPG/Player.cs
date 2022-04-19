using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Player: Creature
    {
        public string Name;
        public int Gold;
        public int XPPoints;
        public int Level;
        public Location CurrentLocation;
        public List<Inventory> Inventorry;
        public List<PlayerQuests> Quests;

        public Player(int currentHitPoints, int maxHitPoints, 
            string name, int gold, int xPPoints, int level)
            :base (currentHitPoints, maxHitPoints)
        {
            Name = name;
            Gold = gold;
            XPPoints = xPPoints;
            Level = level;
            Inventorry = new List<Inventory>();
            Quests = new List<PlayerQuests>();
        }
        public Player() { }

        public void MoveTo(Location loc)
        {
            if (loc.ItemRequiredToEnter != null)
            {
                bool playerHasRequireditem = false;
                foreach(Inventory ii in this.Inventorry)
                {
                    if(ii.Details.Id == loc.ItemRequiredToEnter.Id)
                    {
                        playerHasRequireditem = true;
                        break;
                    }
                }
                if (!playerHasRequireditem)
                {
                    Console.WriteLine("You must have a {0} to enter", loc.ItemRequiredToEnter.Name);
                    return;
                }
            }

            CurrentLocation = loc;
            GameEngine.QuestProcessor(this, loc);
            GameEngine.MonsterProcessor(this, loc);
            GameEngine.Heal(this, loc);
        }

        public void MoveNorth()
        {
            if (CurrentLocation.LocationToNorth != null)
            {
                MoveTo(CurrentLocation.LocationToNorth);
                Program.DislayCurrentLocation(this);
            }
            else
            {
                Console.WriteLine("You can't move north");
            }
        }//move north
        public void MoveSouth()
        {
            if (CurrentLocation.LocationToSouth != null)
            {
                MoveTo(CurrentLocation.LocationToSouth);
                Program.DislayCurrentLocation(this);
            }
            else
            {
                Console.WriteLine("You can't move south");
            }
        }//move south
        public void MoveEast()
        {
            if (CurrentLocation.LocationToeast != null)
            {
                MoveTo(CurrentLocation.LocationToeast);
                Program.DislayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You can't move east");
            }
        }//move east
        public void MoveWest()
        {
            if (CurrentLocation.LocationToWest != null)
            {
                MoveTo(CurrentLocation.LocationToWest);
                Program.DislayCurrentLocation();
            }
            else
            {
                Console.WriteLine("You can't move west");
            }
        }//move west


        //quest work
        public bool HasThisQuest(Quests quests)
        {
            foreach (PlayerQuests playerQuest in Quests)
            {
                if (playerQuest.Details.Id == quests.Id)
                {
                    return true;
                }
            }

            return false;
        }

        public bool CompletedThisQuest(Quests quests)
        {
            foreach (PlayerQuests playerQuests in Quests)
            {
                if (playerQuests.Details.Id == quests.Id)
                {
                    return playerQuests.IsCompleted;
                }
            }

            return false;
        }

        public bool HasAllQuestCompletionItems(Quests quests)
        {
            // See if the player has all the items needed to complete the quest here
            foreach (QuestWin qci in quests.QuestWins)
            {
                bool foundItemInPlayersInventory = false;

                // Check each item in the player's inventory, to see if they have it, and enough of it
                foreach (Inventory ii in Inventorry)
                {
                    if (ii.Details.Id == qci.Details.Id) // The player has the item in their inventory
                    {
                        foundItemInPlayersInventory = true;

                        if (ii.Quantity < qci.Quantity) // The player does not have enough of this item to complete the quest
                        {
                            return false;
                        }
                    }
                }

                // The player does not have any of this quest completion item in their inventory
                if (!foundItemInPlayersInventory)
                {
                    return false;
                }
            }

            // If we got here, then the player must have all the required items, and enough of them, to complete the quest.
            return true;
        }

        public void RemoveQuestCompletionItems(Quests quests)
        {
            foreach (QuestWin qci in quests.QuestWins)
            {
                foreach (Inventory ii in Inventorry)
                {
                    if (ii.Details.Id == qci.Details.Id)
                    {
                        // Subtract the quantity from the player's inventory that was needed to complete the quest
                        ii.Quantity -= qci.Quantity;
                        break;
                    }
                }
            }
        }


        public void AddItemToInventory(Item itemToAdd)
        {
            foreach (Inventory ii in Inventorry)
            {
                if (ii.Details.Id == itemToAdd.Id)
                {
                    // They have the item in their inventory, so increase the quantity by one
                    ii.Quantity++;

                    return; // We added the item, and are done, so get out of this function
                }
            }

            // They didn't have the item, so add it to their inventory, with a quantity of 1
            Inventorry.Add(new Inventory(itemToAdd, 1));
        }

        public void MarkQuestCompleted(Quests quests)
        {
            // Find the quest in the player's quest list
            foreach (PlayerQuests pq in Quests)
            {
                if (pq.Details.Id == quests.Id)
                {
                    // Mark it as completed
                    pq.IsCompleted = true;

                    return; // We found the quest, and marked it complete, so get out of this function
                }
            }
        }
    }//end of class player
}
