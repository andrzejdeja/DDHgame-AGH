using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    interface IElfStrategy
    {
        void Execute(GameSession session);
    }
}
