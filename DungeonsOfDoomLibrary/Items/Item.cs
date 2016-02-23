using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameObjects;
using Interfaces;

namespace Items
{
    public class Item: GameObject, ILuggable
    {
        public Item(string name, int weight):base(name)
        {
            Weight = weight;
        }
        public int Weight { get; set; }
    }
}
