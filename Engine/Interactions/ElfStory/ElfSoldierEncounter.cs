using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSoldierEncounter : ListBoxInteraction
    {
        public IElfStrategy Strategy { get; set; }
        public ElfSoldierEncounter(GameSession session) : base(session)
        {
            Name = "interaction0008";
            Strategy = new ElfSoldierHostileStrategy(); // start with hostile strategy
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession); // execute strategy
        }
    }
}
