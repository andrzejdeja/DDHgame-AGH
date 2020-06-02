using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Engine.Interactions.ElfStory;

namespace Game.Engine.Interactions.InteractionFactories
{
    [Serializable]
    class ElfFactory : InteractionFactory
    {
        public List<Interaction> CreateInteractionsGroup(GameSession parentSession)
        {
            List<ElfSoldierEncounter> soldiers = new List<ElfSoldierEncounter>();
            for(int i = 0; i < 8; i++)
                soldiers.Add(new ElfSoldierEncounter(parentSession));

            List<ElfHerbs> herbs = new List<ElfHerbs>();
            for (int i = 0; i < 8; i++)
                herbs.Add(new ElfHerbs(parentSession));

            List<ElfCave> caves = new List<ElfCave>();
            for (int i = 0; i < 5; i++)
                caves.Add(new ElfCave(parentSession));

            List<ElfChest> chests = new List<ElfChest>();
            for (int i = 0; i < 8; i++)
                chests.Add(new ElfChest(parentSession));

            ElfSorcererEncounter sorcerer = new ElfSorcererEncounter(parentSession, caves);
            ElfSummonerEncounter summoner = new ElfSummonerEncounter(parentSession);
            ElfPriestEncounter priest = new ElfPriestEncounter(parentSession, soldiers, herbs, sorcerer, summoner);

            List<Interaction> ret = new List<Interaction>() { sorcerer, summoner, priest };
            ret.AddRange(soldiers);
            ret.AddRange(herbs);
            ret.AddRange(caves);
            ret.AddRange(chests);
            return ret;
        }
    }
}
