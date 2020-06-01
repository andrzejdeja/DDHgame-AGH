using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    class ElfSorcererFriendlyStrategy : IElfStrategy
    {
        public bool visited = false;

        public void Execute(GameSession parentSession)
        {
            if (!visited)
            {
                parentSession.SendText("\nHey! Priest told me about you. Do adventures interest you?");
                int choice = parentSession.ListBoxInteractionChoice(new List<string>() { "What is the deal?", "I am bussy right now" });
                switch (choice)
                {
                    case 0:
                        parentSession.SendText("\nOur ancestors hid our tresury in five caves and sealed them with magic, but it's dangerous place. I will give you talisman, that lets you in.");
                        parentSession.AddThisItem(new Game.Engine.Items.QuestItem.ElfsTalisman());
                        visited = true;
                        break;
                    default:
                        parentSession.SendText("\nOk, I can wait");
                        break;
                }
            }
            else
            {
                parentSession.SendText("\nHow are you doing, friend?");
            }
        }
    }
}
