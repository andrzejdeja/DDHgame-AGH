using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSoldierHostileStrategy : IElfStrategy
    {
        public void Execute(GameSession parentSession)
        {
            parentSession.SendText("\nHey! Yes, you. Come here. Are you looking for problems? Gold or iron, buddy. What is your choice?");
            int choice = parentSession.ListBoxInteractionChoice(new List<string>() { "Sure, here you go. [pay 15 gold]", "Suuuure. [fight]" });
            switch (choice)
            {
                case 0:
                    if (parentSession.currentPlayer.Gold >= 15)
                    {
                        parentSession.currentPlayer.Gold -= 15;
                        break;
                    }
                    parentSession.SendText("\nAre you trying to disrespect me? That is not even 15 gold!");
                    parentSession.FightThisMonster(new Game.Engine.Monsters.CruelDemon(parentSession.currentPlayer.Level)); //TODO: place holder, change to new enemy
                    break;
                default:
                    parentSession.FightThisMonster(new Game.Engine.Monsters.CruelDemon(parentSession.currentPlayer.Level)); //TODO: place holder, change to new enemy
                    break;
            }
        }
    }
}
