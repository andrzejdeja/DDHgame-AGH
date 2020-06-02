using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    [Serializable]
    class ElfHerbs : ConsoleInteraction
    {
        public bool visited = false;
        public ElfHerbs(GameSession session) : base(session)
        {
            Name = "interaction0006";
            this.Enterable = false;
        }
        protected override void RunContent()
        {
            parentSession.SendText("\nElven Priest was taking about this herb.");
            if(parentSession.TestForItem("Elven Sack"))
            {
                parentSession.UpdateStat(7, 50); //EXP +50
                visited = true;
                Enterable = false;
            }
            else
            {
                parentSession.SendText("\nI need Elven Sack...");
            }
        }
    }
}
