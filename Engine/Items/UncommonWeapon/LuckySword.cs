using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.UncommonWeapon
{
    class LuckySword : Sword
    {
        //Has 15% for critical hit
        private int critChance;
        public LuckySword() : base("item0009")
        {
            critChance = 15;
            StrMod = 30;
            PrMod = 10;
            GoldValue = 130;
            PublicName = "Lucky";
            PublicTip = "Grants 15% for critical hit.";
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                pack.HealthDmg *= (Index.RNG(0,100) > critChance - 1) ? 1 : 2;
            }
            return pack;
        }
    }
}
