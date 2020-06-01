using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class AngryDemon : Monster
    {
        public AngryDemon(int Level)
        {
            Health = 200 + 4 * Level;
            Strength = (int)((20 + Level) * 1.2);
            Armor = 15;
            Precision = 50;
            MagicPower = 0;
            Stamina = 150;
            XPValue = (250 - Level > 50) ? 250 - Level : 50;
            Name = "monster0005";
            BattleGreetings = "I'm back! Aggggrh!";
        }
        public override List<StatPackage> BattleMove()
        {
            string call = "";
            if (Stamina == 0)
            {
                call = "Not again! Aggggrh!";
            }
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage("incised", (10 + Strength), call + "Demon cuts! (" + (10 + Strength) + " incised damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, call + "Angry Demon is tired") };
            }
        }
    }
}
