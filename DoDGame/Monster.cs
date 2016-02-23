using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDGame
{
    class Monster : Character, ILuggable
    {
        public Monster(string name, int health, int attackStrength, string type, int weight): base(name, health, attackStrength)
        {
            Weight = weight;
            Type = type;
            MonsterCounter++;
        }
        public static int MonsterCounter { get; set; }
        public string Type { get; set; }

        public int Weight { get; set; }
        public override void Fight(Character opponent)
        {
            opponent.Health -= Convert.ToInt32(this.AttackStrength * 0.1);
            Console.WriteLine($"The monster hits you and you now have {opponent.Health} HP."); // FLytta till GAme
        }

        public void PutInBackBack()
        {

        }
        #region Properties
        #endregion

    }
}
