using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Engine.Skills.AdvancedWeaponMoves;
using Game.Engine.CharacterClasses;

namespace Game.Engine.Skills.SkillFactories
{
    [Serializable]
    class AdvancedWeaponMoveFactory : SkillFactory
    {
        // this factory produces skills from AdvancedWeaponMoves directory
        public Skill CreateSkill(Player player)
        {
            List<Skill> playerSkills = player.ListOfSkills;
            Skill known = CheckContent(playerSkills);
            if (known == null) // no AdvancedWeaponMoves known - we will return one of them
            {
                SwordCleave s1 = new SwordCleave();
                SwordLunge s2 = new SwordLunge();
                SwordWhirlwind s3 = new SwordWhirlwind();
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level) tmp.Add(s1); // check level requirements
                if (s2.MinimumLevel <= player.Level) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else if (known.decoratedSkill == null) // a AdvancedWeaponMove has been already learned, use decorator to create a combo
            {
                SwordCleaveDecorator s1 = new SwordCleaveDecorator(known);
                SwordLungeDecorator s2 = new SwordLungeDecorator(known);
                SwordWhirlwindDecorator s3 = new SwordWhirlwindDecorator(known);
                List<Skill> tmp = new List<Skill>();
                if (s1.MinimumLevel <= player.Level && !(known is SwordCleave)) tmp.Add(s1); // check level requirements and don't double skills
                if (s2.MinimumLevel <= player.Level && !(known is SwordLunge)) tmp.Add(s2);
                if (s3.MinimumLevel <= player.Level && !(known is SwordWhirlwind)) tmp.Add(s3);
                if (tmp.Count == 0) return null;
                return tmp[Index.RNG(0, tmp.Count)];
            }
            else return null; // a combo of AdvancedWeaponMoves has been already learned - this factory doesn't offer double combos
        }

        private Skill CheckContent(List<Skill> skills) // wrapper method for checking
        {
            foreach (Skill skill in skills)
            {
                if (skill is SwordCleave || skill is SwordCleaveDecorator || skill is SwordLunge || skill is SwordLungeDecorator || skill is SwordWhirlwind || skill is SwordWhirlwindDecorator) return skill;
            }
            return null;
        }
    }
}
