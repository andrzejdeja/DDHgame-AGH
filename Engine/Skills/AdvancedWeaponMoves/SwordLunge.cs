using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class SwordLunge : Skill
    {
        public SwordLunge() : base("Sword Lunge", 25, 10)
        {
            PublicName = "Sword lunge [requires sword]: 0.12*Str + 0.28*Pr damage [stab] and then 0.12*Str + 0.22*Pr damage [incised]";
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response1 = new StatPackage("stab");
            response1.HealthDmg = (int)(0.12 * player.Strength) + (int)(0.28 * player.Precision);
            StatPackage response2 = new StatPackage("incised");
            response2.HealthDmg = (int)(0.12 * player.Strength) + (int)(0.22 * player.Precision);
            // applying CustomText only once is sufficient
            response2.CustomText = "You use Sword Lunge! (" + ((int)(0.12 * player.Strength) + (int)(0.28 * player.Precision)) + " stab damage, " + ((int)(0.12 * player.Strength) + (int)(0.22 * player.Precision)) + " incised damage)";
            return new List<StatPackage>() { response1, response2 };
        }
    }
}

