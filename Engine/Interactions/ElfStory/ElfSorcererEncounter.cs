using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSorcererEncounter : ConsoleInteraction
    {
        private List<ElfCave> caves = new List<ElfCave>();
        public IElfStrategy Strategy { get; set; }
        public ElfSorcererEncounter(GameSession session, List<ElfCave> caves) : base(session)
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
