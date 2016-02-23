using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Characters;
using Items;

namespace GameObjects
{
    public class Room
    {
        #region Properties
        public Monster MonsterInRoom { get; set; }
        public Item ItemInRoom { get; set; }
        #endregion
    }

}
