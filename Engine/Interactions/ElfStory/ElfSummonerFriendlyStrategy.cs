using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSummonerFriendlyStrategy : IElfStrategy
    {
        public bool visited = false;

        public void Execute(GameSession parentSession)
        {
            if (!visited)
            {
                parentSession.SendText("\nHello, my friend. I think I can help you out. I can summon monsters... for a money.");
                int choice = parentSession.ListBoxInteractionChoice(new List<string>() { "Great!", "Maybe some other time" });
                switch (choice)
                {
                    case 0:
                        visited = true;
                        summon(parentSession);
                        break;
                    default:
                        parentSession.SendText("\nOk, maybe some other time.");
                        break;
                }
            }
            else
            {
                parentSession.SendText("\nWelcome back!");
                summon(parentSession);
            }
        }

        protected void summon(GameSession parentSession)
        {
            int choice = parentSession.ListBoxInteractionChoice(new List<string>() { "Rat [2 gold]", "Demon [10 gold]" });
            switch (choice)
            {
                case 0:
                    if (parentSession.currentPlayer.Gold >= 2)
                    {
                        parentSession.FightThisMonster(new Game.Engine.Monsters.MonsterFactories.RatFactory().Create(parentSession.currentPlayer.Level));
                    }
                    break;
                case 1:
                    if (parentSession.currentPlayer.Gold >= 10)
                    {
                        parentSession.FightThisMonster(new Game.Engine.Monsters.MonsterFactories.DemonFactory().Create(parentSession.currentPlayer.Level));
                    }
                    break;
                default:
                    break;
            }
        }
    }
}
