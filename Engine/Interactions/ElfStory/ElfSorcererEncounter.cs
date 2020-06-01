using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSorcererEncounter : ConsoleInteraction
    {
        public IElfStrategy Strategy { get; set; }
        public ElfSorcererEncounter(GameSession ses) : base(ses)
        {
            Name = "interaction0009";
            Strategy = new ElfHostileStrategy(); // start with hostile strategy
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession); // execute strategy
        }
    }
}
