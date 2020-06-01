using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class Demon : Monster
    {
        public Demon(int Level)
        {
            Health = 150 + 4 * Level;
            Strength = 20 + Level;
            Armor = 10;
            Precision = 50;
            MagicPower = 0;
            Stamina = 120;
            XPValue = (200 - Level > 50) ? 200 - Level : 50;
            Name = "monster0004";
            BattleGreetings = "Aggggrh!";
        }
        public override List<StatPackage> BattleMove()
        {
            string call = "";
            if (Stamina == 0)
            {
                call = "Aggggrh!";
            }
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage("incised", (10 + Strength), call + "Demon cuts! (" + (10 + Strength) + " incised damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, call + "Demon is tired") };
            }
        }
    }
}
