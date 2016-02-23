using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace DoDGame
{
    class Weapon : Item
    {
        public Weapon(string name, int weight, string type) : base(name, weight)
        {
            Type = type;
        }
        public string Type { get; set; }
    }
}