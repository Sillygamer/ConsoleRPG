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
        public Weapon CurrentWeapon;
        public List<Weapon> Weapons = new List<Weapon>();

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
                Program.DislayCurrentLocation(this);
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
                Program.DislayCurrentLocation(this);
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
        }//end of quests

        //weapon work
        public void UseWeapon(Weapon weapon)
        {


            Monster _currentMonster = GameEngine._currentMonster;
            Weapon currentWeapon = weapon;
            string fightMessage = "";

            // Determine the amount of damage to do to the monster
            int damageToMonster = RandomNumberGenerator.NumberBetween(currentWeapon.MinDamage, currentWeapon.MaxDamage);

            // Apply the damage to the monster's CurrentHitPoints
            _currentMonster.CurrentHitPoints -= damageToMonster;

            // Display message
            fightMessage += "You hit the " + _currentMonster.Name + " and do " + damageToMonster.ToString() + " points." + Environment.NewLine;
            Console.WriteLine(fightMessage);

            // Check if the monster is dead
            if (_currentMonster.CurrentHitPoints <= 0)
            {
                // Monster is dead
                fightMessage += Environment.NewLine;
                fightMessage += "You defeated the " + _currentMonster.Name + Environment.NewLine;

                // Give player experience points for killing the monster
                XPPoints += _currentMonster.RewardXP;
                fightMessage += "You receive " + _currentMonster.RewardXP.ToString() + " experience points" + Environment.NewLine;

                // Give player gold for killing the monster 
                Gold += _currentMonster.RewardGold;
                fightMessage += "You receive " + _currentMonster.RewardGold.ToString() + " gold" + Environment.NewLine;


                // Get random loot items from the monster
                List<Inventory> lootedItems = new List<Inventory>();

                // Add items to the lootedItems list, comparing a random number to the drop percentage
                foreach (Loot loot in _currentMonster.LootTable)
                {
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= loot.DropRate)
                    {
                        lootedItems.Add(new Inventory(loot.Details, 1));
                    }
                }

                // If no items were randomly selected, then add the default loot item(s).
                if (lootedItems.Count == 0)
                {
                    foreach (Loot lootItem in _currentMonster.LootTable)
                    {
                        if (lootItem.IsDefault)
                        {
                            lootedItems.Add(new Inventory(lootItem.Details, 1));
                        }
                    }
                }

                // Add the looted items to the player's inventory
                foreach (Inventory inventoryItem in lootedItems)
                {
                    AddItemToInventory(inventoryItem.Details);

                    if (inventoryItem.Quantity == 1)
                    {
                        fightMessage += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.Name + Environment.NewLine;
                    }
                    else
                    {
                        fightMessage += "You loot " + inventoryItem.Quantity.ToString() + " " + inventoryItem.Details.PlName + Environment.NewLine;
                    }
                }



                // Add a blank line to the messages box, just for appearance.
                fightMessage += Environment.NewLine;
                Console.WriteLine(fightMessage);

                // Move player to current location (to heal player and create a new monster to fight)
                MoveTo(CurrentLocation);
            }
            else
            {
                // Monster is still alive

                // Determine the amount of damage the monster does to the player
                int damageToPlayer = RandomNumberGenerator.NumberBetween(0, _currentMonster.MaxDamage);

                // Display message
                fightMessage += "The " + _currentMonster.Name + " did " + damageToPlayer.ToString() + " points of damage." + Environment.NewLine;

                // Subtract damage from player
                CurrentHitPoints -= damageToPlayer;

                Console.WriteLine(fightMessage);

                if (CurrentHitPoints <= 0)
                {
                    // Display message
                    fightMessage += "The " + _currentMonster.Name + " killed you." + Environment.NewLine;
                    Console.WriteLine(fightMessage);

                    // Move player to "Home"
                    MoveTo(World.LocationByID(World.LOCATION_ID_HOME));
                }
            }

        }
        public void UpdateWeapons()
        {
            Weapons.Clear();
            foreach(Inventory inventory in this.Inventorry)
            {
                if(inventory.Details is Weapon)
                {
                    if(inventory.Quantity > 0)
                    {
                        Weapons.Add((Weapon)inventory.Details);
                    }
                }
            }
        }
    }//end of class player
}
