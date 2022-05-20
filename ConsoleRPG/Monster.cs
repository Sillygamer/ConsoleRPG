using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Monster: Creature
    {
        public string Name;
        public int Id;
        public int MaxDamage;
        public int MinDamage;
        public int HitRate;
        public int RewardXP;
        public int RewardGold;
        public List<Loot> LootTable;

        public Monster(int currentHitPoints, int maxHitPoints, string name,
            int id, int maxDamage, int minDamage, int rewardXP, int rewardGold, int hitRate)
            :base (currentHitPoints, maxHitPoints)
        {
            Name = name;
            Id = id;
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            RewardXP = rewardXP;
            RewardGold = rewardGold;
            HitRate = hitRate;
            LootTable = new List<Loot>();
        }
    }
}
