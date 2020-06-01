using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    [Serializable]
    class ElfCave : ConsoleInteraction
    {
        public bool visited = false;
        public ElfCave(GameSession ses) : base(ses)
        {
            Name = "interaction0011";
        }
        protected override void RunContent()
        {

            if (parentSession.TestForItem("Elven Sorcerer's Talisman"))
            {
                visited = true;
                parentSession.SendText("\nI feel magic, but talisman is working. I can pass.");
                parentSession.FightThisMonster(new Game.Engine.Monsters.MonsterFactories.QSDragonFactory().Create(parentSession.currentPlayer.Level));
                int rng = Index.RNG(0, 100) + 25;
                parentSession.UpdateStat(7, 150); //EXP +150
                int gold = rng * 4 + 150;
                parentSession.SendText("\nHey! Some coins just found new owner. [" + gold + " gold]");
                parentSession.currentPlayer.Gold += gold;
                if (rng < 74)
                {
                    parentSession.SendText("\nLucky me. There is an item.");
                    parentSession.AddRandomItem();
                }
            }
            else
            {
                parentSession.SendText("\nI feel magic that stops me. I can't go in.");
            }
        }
    }

        
}
