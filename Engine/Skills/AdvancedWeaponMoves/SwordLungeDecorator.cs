using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class SwordLungeDecorator : SkillDecorator
    {
        public SwordLungeDecorator(Skill skill) : base("Sword Ludge", 20, 1, skill)
        {
            MinimumLevel = Math.Max(10, skill.MinimumLevel) + 5;
            PublicName = "COMBO - Sword lunge [requires sword]: 0.12*Str + 0.28*Pr damage [stab] and then 0.12*Str + 0.22*Pr damage [incised] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
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
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response1);
            combo.Add(response2);
            return combo;
        }
    }
}
