using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    [Serializable]
    class ElfChest : ConsoleInteraction
    {
        public bool visited = false;
        public ElfChest (GameSession session) : base(session)
        {
            Name = "interaction0005";
        }
        protected override void RunContent()
        {
            
            if (parentSession.TestForItem("Elven Priest's Key"))
            {
                parentSession.UpdateStat(7, 50); //EXP +50
                visited = true;
                parentSession.SendText("\nElven Priest was taking about this chest.");
                int rng = Index.RNG(0, 100);
                if (rng > 79)
                {
                    parentSession.SendText("\nThere is nothing... Except this big rat.");
                    parentSession.FightThisMonster(new Game.Engine.Monsters.MonsterFactories.RatFactory().Create(parentSession.currentPlayer.Level));
                    return;
                }
                if (rng > 49)
                {
                    int gold = rng * 3 + 50; //200-287
                    parentSession.SendText("\nHey! Some coins just found new owner. [" + gold + " gold]");
                    parentSession.currentPlayer.Gold += gold;
                    return;
                }
                parentSession.SendText("\nHe was right. There is something under this dust.");
                parentSession.AddRandomItem();
            }
            else
            {
                parentSession.SendText("\nElven Priest was taking about this chest.");
                parentSession.SendText("\nI need Elven Priest's Key...");
            }
        }
    }
}
