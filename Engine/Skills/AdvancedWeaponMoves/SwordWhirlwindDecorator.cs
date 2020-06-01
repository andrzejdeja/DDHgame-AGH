using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.AdvancedWeaponMoves
{
    [Serializable]
    class SwordWhirlwindDecorator : SkillDecorator
    {
        public SwordWhirlwindDecorator(Skill skill) : base("Sword Whirlwind", 20, 1, skill)
        {
            MinimumLevel = Math.Max(10, skill.MinimumLevel) + 5;
            PublicName = "COMBO - Sword Whirlwind [requires sword]: 0.24*Str + 0.64*Pr damage [incised] AND " + decoratedSkill.PublicName.Replace("COMBO: ", "");
            RequiredItem = "Sword";
        }
        public override List<StatPackage> BattleMove(Player player)
        {
            StatPackage response = new StatPackage("incised");
            response.HealthDmg = (int)(0.24 * player.Strength) + (int)(0.64 * player.Precision);
            // applying CustomText only once is sufficient
            response.CustomText = "You use Sword Whirlwind! (" + ((int)(0.24 * player.Strength) + (int)(0.64 * player.Precision)) + " incised damage)"; List<StatPackage> combo = decoratedSkill.BattleMove(player);
            combo.Add(response);
            return combo;
        }
    }
}
