using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.QuestItem
{
    class ElfsChestKey : Item
    {
        public ElfsChestKey() : base("item0012")
        {
            GoldValue = 0;
            PublicName = "Elven Priest's Key";
        }
    }
}
