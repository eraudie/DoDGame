using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameObjects;

namespace Characters
{
    abstract public class Character: GameObject    
    {
        public Character(string name, int health, int attackStrength, bool isAlive = true) : base(name)
        {
            Health = health;
            AttackStrength = attackStrength;
            IsAlive = isAlive;
            
        }

        public int Health { get; set; }
        public int AttackStrength { get; set; }
        public bool IsAlive { get; set; }

        public abstract void Fight(Character opponent);

    }
}
