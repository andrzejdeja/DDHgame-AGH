using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters.MonsterFactories
{
    class QSDragonFactory : MonsterFactory
    {
        private int encounterNumber = 0; // how many times has this factory been used already?
        public override Monster Create(int playerLevel)
        {
            if (encounterNumber == 0)
            {
                encounterNumber++;
                return new QSDragon(playerLevel);
            }
            else return null;
        }
        public override System.Windows.Controls.Image Hint()
        {
            if (encounterNumber == 0) return new QSDragon(0).GetImage();
            else return null;
        }
    }
}
