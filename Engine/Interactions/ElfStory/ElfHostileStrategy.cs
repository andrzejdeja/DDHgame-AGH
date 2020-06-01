using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfHostileStrategy : IElfStrategy
    {
        public void Execute(GameSession parentSession)
        {
            parentSession.SendText("\nI don't know you. Leave me alone.");
        }
    }
}