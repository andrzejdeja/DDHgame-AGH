using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.QuestItem
{
    class ElfsSack : Item
    {
        public ElfsSack() : base("item0013")
        {
            GoldValue = 10;
            PublicName = "Elven Priest's Sack";
        }
    }

}
