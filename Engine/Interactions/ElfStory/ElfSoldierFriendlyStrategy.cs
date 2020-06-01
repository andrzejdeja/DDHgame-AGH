using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSoldierFriendlyStrategy : IElfStrategy
    {
        public void Execute(GameSession parentSession)
        {
            parentSession.SendText("\nHey! How is it going?");
            int rng = Index.RNG(0, 100);
            if (rng < 5)
            {
                parentSession.SendText("\nI found that item, but I don't need it. You can take it.");
                parentSession.AddRandomItem();
                return;
            }
        }
        
    }
}
