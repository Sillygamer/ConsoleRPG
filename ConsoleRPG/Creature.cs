using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleRPG
{
    public class Creature
    {

        public int CurrentHitPoints;
        public int MaxHitPoints;

        public Creature(int currentHitPoints, int maxHitPoints)
        {
            CurrentHitPoints = currentHitPoints;
            MaxHitPoints = maxHitPoints;

        }
        public Creature()
        {

        }
    }
}
