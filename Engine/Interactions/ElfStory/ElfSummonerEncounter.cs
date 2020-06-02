using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSummonerEncounter : ConsoleInteraction
    {
        public IElfStrategy Strategy { get; set; }
        public ElfSummonerEncounter(GameSession session) : base(session)
        {
            Name = "interaction0010";
            Strategy = new ElfHostileStrategy(); // start with default strategy
        }
        protected override void RunContent()
        {
            Strategy.Execute(parentSession); // execute strategy
        }
    }
}
