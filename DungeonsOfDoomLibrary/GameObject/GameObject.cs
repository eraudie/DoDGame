﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameObjects
{
    abstract public class GameObject
    {
        public GameObject(string name)
        {
            Name = name;
        }
        public string Name { get; set; }

    }
}
