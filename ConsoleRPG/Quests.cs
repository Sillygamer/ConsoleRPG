using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Quests
    {
        public int Id;
        public string Name;
        public string Description;
        public int RewardXP;
        public int RewardGold;
        public Item RewardItem;
        public List<QuestWin> QuestWins;

        public Quests(int id, string name, string description, int rewardXP, int rewardGold, Item rewardItem, List<QuestWin> questWins)
        {
            Id = id;
            Name = name;
            Description = description;
            RewardXP = rewardXP;
            RewardGold = rewardGold;
            RewardItem = rewardItem;
            QuestWins = questWins;
        }
    }
}
