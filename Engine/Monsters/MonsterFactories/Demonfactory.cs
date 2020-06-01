using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    class DemonFactory : MonsterFactory
    {
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new Demon(playerLevel);
            }
            else if (encounterNumber == 1) 
            {
                encounterNumber++;
                return new AngryDemon(playerLevel);
            }
            else if (encounterNumber == 2) 
            {
                encounterNumber++;
                return new CruelDemon(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new Demon(0).GetImage();
            else if (encounterNumber == 1) return new AngryDemon(0).GetImage();
            else if (encounterNumber == 2) return new CruelDemon(0).GetImage();
            else return null;
        }
    }
}
