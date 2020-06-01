using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items
{
    class VampiricFalchion : Sword
    {
        //Heals for 15% of dealt damage, before debuffs.
        //(By decreasing incoming dmg. Couldn't find another solution, not involving redesigning Battle logic.)
        private int hpStolen;
        public VampiricFalchion() : base("item0011")
        {
            hpStolen = 0;
            StrMod = 35;
            PrMod = 20;
            GoldValue = 150;
            PublicName = "Vampiric Falchion";
            PublicTip = "Heals for 15% of dealt damage";
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                hpStolen = (int)(pack.HealthDmg * 0.15f + 0.5f);
            }
            return pack;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            pack.HealthDmg -= hpStolen;
            hpStolen = 0;
            return pack;
        }
    }
}
