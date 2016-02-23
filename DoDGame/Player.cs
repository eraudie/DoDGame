using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDGame
{
    sealed class Player : Character
    {
        public Player(string name, int health, int attackStrength):base(name, health, attackStrength)
        {
            BackPack = new List<ILuggable>();
        }

        #region Properties
        public int X { get; set; } //Om vi inte vill styra vart spelaren ska positioneras första gången, så kan man låta dessa vara default.
        public int Y { get; set; }
        public List<ILuggable> BackPack { get; set; }
        #endregion

        #region Methods
        public override void Fight(Character opponent)
        {
            opponent.Health -= Convert.ToInt32(this.AttackStrength * 0.4);
            if (opponent.Health > 0)
                Console.WriteLine($"You hit the monster and they now have {opponent.Health} HP.");
            else
            {
                Console.WriteLine("You killed the monster! Hurray! Your health improves and you become stronger!");
                this.Health += 5;
                this.AttackStrength += 10;
            }
            
        }
        #endregion



    }
}
