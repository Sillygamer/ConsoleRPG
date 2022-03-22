using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class PlayerQuests
    {
        public Quests Details;
        public bool IsCompleted;

        public PlayerQuests(Quests details, bool isCompleted)
        {
            Details = details;
            IsCompleted = isCompleted;
        }
    }
}
