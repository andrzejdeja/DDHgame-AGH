using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class SwordWhirlwind : Skill
    {
        public SwordWhirlwind() : base("Sword Wirlwind", 35, 10)
        {
            PublicName = "Sword Whirlwind [requires sword]: 0.24*Str + 0.64*Pr damage [incised]";
            RequiredItem = "Sword";
        }

        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            response.HealthDmg = (int)(0.24 * player.Strength) + (int)(0.64 * player.Precision);
            // applying CustomText only once is sufficient
            response.CustomText = "You use Sword Whirlwind! (" + ((int)(0.24 * player.Strength) + (int)(0.64 * player.Precision)) + " incised damage)";
            return new List<StatPackage>() { response };
        }

    }
}