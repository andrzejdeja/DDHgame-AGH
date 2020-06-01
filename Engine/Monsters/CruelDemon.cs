using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class CruelDemon : Monster
    {
        public int MaxHealth { get; }

        public CruelDemon(int Level)
        {
            Health = 230 + 4 * Level;
            Strength = (int)((20 + Level) * 1.2);
            Armor = 25;
            Precision = 50;
            MagicPower = 0;
            Stamina = 180;
            XPValue = (300 - Level > 50) ? 300 - Level : 50;
            Name = "monster0006";
            BattleGreetings = "Time to die! Aggggrh!";

            MaxHealth = Health;
        }
        public override List<StatPackage> BattleMove()
        {
            string call = "";
            if (Stamina == 0)
            {
                call = "Don't you dare! Aggggrh!";
            }
            float param = Health > 0.2 * MaxHealth ? 1.0f : 1.2f;
            if (Stamina > 0)
            {
                Stamina -= 10;
                return new List<StatPackage>() { new StatPackage("incised", (int)((10 + Strength) * param), call + "Demon cuts! (" + (int)((10 + Strength) * param) + " incised damage)") };
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, call + "Cruel Demon is tired") };
            }
        }
    }
}
