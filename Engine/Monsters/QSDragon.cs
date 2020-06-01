using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Monsters
{
    [Serializable]
    class QSDragon : Monster
    {
        public int MaxHealth { get; }

        public QSDragon(int Level)
        {
            Health = 350 + 4 * Level;
            Strength = 30 + Level;
            Armor = 10;
            Precision = 50;
            MagicPower = 40 + Level;
            Stamina = 500;
            XPValue = (500 - 4 * Level > 100) ? 500 - 4 * Level : 100;
            Name = "monster0003";
            BattleGreetings = "You chose death!";

            MaxHealth = Health;
        }
        public override List<StatPackage> BattleMove()
        {
            string call = "";
            if (Stamina == 400)
            {
                call = "I am not even tired! ";
            }
            else if (Stamina == 200)
            {
                call = "Stop anoying me! ";
            }
            else if (Stamina == 0)
            {
                call = "I can't stand it anymore, just kill me!";
            }
            if (Stamina > 0)
            {
                Stamina -= 10;
                int param = Index.RNG(0, 100) > (Health > 0.2 * MaxHealth ? 9 : 19) ? 1 : 2;
                if (Index.RNG(0, 100) > (Health > 0.2 * MaxHealth ? 29 : 44))
                {
                    //normal attack
                    return new List<StatPackage>() { new StatPackage("incised", (10 + Strength) * param, call + "Dragon cuts (" + ((10 + Strength) * param) + ((param > 1) ? " critical" : "") + " incised damage)") };
                } else
                {
                    //magic attack
                    return new List<StatPackage>() { new StatPackage("fire", (20 + MagicPower) * param, "Fire breath! (" + ((20 + MagicPower) * param) + ((param > 1) ? " critical" : "") + " fire damage)") };
                }
            }
            else
            {
                return new List<StatPackage>() { new StatPackage("none", 0, call) };
            }
        }

        public override void React(List<StatPackage> packs)
        {
            float param = (Health > MaxHealth * 0.2) ? 1.0f : 0.5f;
            foreach (StatPackage pack in packs)
            {
                Health -= (int)(pack.HealthDmg * param);
                Strength -= (int)(pack.StrengthDmg * param);
                Armor -= (int)(pack.ArmorDmg * param);
                Precision -= (int)(pack.PrecisionDmg * param);
                MagicPower -= (int)(pack.MagicPowerDmg * param);
            }
        }
    }
}
