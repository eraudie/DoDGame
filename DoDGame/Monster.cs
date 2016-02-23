using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoDGame
{
    class Monster : Character, ILuggable
    {
        public Monster(string name, int health, int attackStrength, int weight, string type) : base(name, health, attackStrength)
        {
            Type = type;
            MonsterCounter++;
        }
        #region Properties
        public static int MonsterCounter { get; set; }
        public string Type { get; set; }
        public int Weight { get; set; }
        #endregion
        public override void Fight(Character opponent)
        {
            opponent.Health -= Convert.ToInt32(this.AttackStrength * 0.1);
            Console.WriteLine($"The monster hits you and you now have {opponent.Health} HP."); // FLytta till GAme
        }
        public void PutInBackPack()
        {
            throw new NotImplementedException();
        }
    }
}