using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Interactions.ElfStory
{
    [Serializable]
    class ElfPriestEncounter : ListBoxInteraction
    {
        private List<ElfSoldierEncounter> soldiers = new List<ElfSoldierEncounter>();
        private List<ElfHerbs> herbs = new List<ElfHerbs>();
        private ElfSorcererEncounter sorcerer;
        private ElfSummonerEncounter summoner;
        private int visited = 0;
        private DateTime starttime = DateTime.MinValue;
        public ElfPriestEncounter(GameSession session, List<ElfSoldierEncounter> _soldiers, List<ElfHerbs> _herbs, ElfSorcererEncounter _sorcerer, ElfSummonerEncounter _summoner) : base(session)
        {
            Name = "interaction0007";
            this.soldiers = _soldiers;
            this.herbs = _herbs;
            this.sorcerer = _sorcerer;
            this.summoner = _summoner;
        }
        protected override void RunContent()
        {
            if (visited == -1) //priest died
            {
                parentSession.SendText("\nNice corpse you got there");
                return;
            }
            if (visited == 1) // resolve quest
            {
                long time = (long)((TimeSpan)(DateTime.Now - starttime)).TotalSeconds;
                //long time = 100;
                if (time > 600)
                {
                    visited = -1;
                    foreach (ElfHerbs e in herbs) e.active = false;
                    parentSession.SendText("\nYou are late. Priest died.");
                    parentSession.FightThisMonster(new Game.Engine.Monsters.CruelDemon(parentSession.currentPlayer.Level));
                    return;
                }
                int count = 0;
                foreach (ElfHerbs e in herbs)
                    count += e.visited ? 1 : 0;
                if ( count > 3)
                {
                    parentSession.SendText("\nYou came back! Thank you. I will get better in a second. Elfs won't forget that you helped me!");
                    parentSession.UpdateStat(7, 750); //EXP +750
                    visited = 2;
                    foreach (ElfHerbs e in herbs) e.active = false;
                    foreach (ElfSoldierEncounter e in soldiers) e.Strategy = new ElfSoldierFriendlyStrategy();
                    sorcerer.Strategy = new ElfSorcererFriendlyStrategy();
                    summoner.Strategy = new ElfSummonerFriendlyStrategy();
                }
                else
                {
                    parentSession.SendText("\nWhat are you doing? Don't waste time...");
                }
                return;
            } 
            if (visited == 2) // priest lived
            {
                parentSession.SendText("\nOh, it's you again. I've got a key for you. If you ever find elves chest try opening it with it.");
                parentSession.AddThisItem(new Game.Engine.Items.QuestItem.ElfsChestKey());
                visited = 3;
                return;
            }
            if (visited > 2) // priest gave key
            {
                parentSession.SendText("\nHow are you doing today?");
                return;
            }
            // first encounter
            parentSession.SendText("\nI... Need your helppp... Take this sack and bring me 4 herbs... I am dying...");
            // get player choice
            int choice = GetListBoxChoice(new List<string>() { "Sure, no problem!", "I haven't got time for you, old man."});
            switch (choice)
            {
                case 0:
                    starttime = DateTime.Now;
                    parentSession.AddThisItem(new Game.Engine.Items.QuestItem.ElfsSack());
                    foreach (ElfHerbs e in herbs) e.active = true;
                    parentSession.SendText("\nHurry... I will die in 10 minutes...");
                    visited = 1;
                    break;
                default:
                    parentSession.SendText("\nFool! I curse you!");
                    visited = -1;
                    break;
            }
        }
    }
}
