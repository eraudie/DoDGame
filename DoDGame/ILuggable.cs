﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoDGame
{
    interface ILuggable
    {
        int Weight { get; set; }
        void PutInBackPack();
    }
}
