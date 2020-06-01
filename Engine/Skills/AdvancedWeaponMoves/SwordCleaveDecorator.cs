using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class SwordCleaveDecorator : SkillDecorator
    {
        public SwordCleaveDecorator(Skill skill) : base("Sword Cleave", 20, 1, skill)
        {
            MinimumLevel = Math.Max(10, skill.MinimumLevel) + 5;
            PublicName = "COMBO - Sword Cleave [requires sword]: 0.56*Str + 0.18*Pr damage [incised] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Sword";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            response.HealthDmg = (int)(0.56 * player.Strength) + (int)(0.18 * player.Precision);
            // applying CustomText only once is sufficient
            response.CustomText = "You use Sword Cleave! (" + ((int)(0.56 * player.Strength) + (int)(0.18 * player.Precision)) + " incised damage)";
            List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}