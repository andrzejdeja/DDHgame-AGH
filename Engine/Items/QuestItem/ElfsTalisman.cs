using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.QuestItem
{
    class ElfsTalisman : Item
    {
        public ElfsTalisman() : base("item0014")
        {
            GoldValue = 0;
            PublicName = "Elven Sorcerer's Talisman";
        }
    }
}
