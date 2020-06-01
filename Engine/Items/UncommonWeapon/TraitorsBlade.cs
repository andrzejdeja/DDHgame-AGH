using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Engine.Items.UncommonWeapon
{
    class TraitorsBlade : Sword
    {
        //Player focuses on attacking, becoming vulnerable
        public TraitorsBlade() : base("item0010")
        {
            StrMod = 70;
            PrMod = 10;
            GoldValue = 110;
            PublicName = "Traitor's Blade";
            PublicTip = "Increases dealt damage by 30% and received damage by 20%.";
        }

        public override StatPackage ModifyOffensive(StatPackage pack, List<string> otherItems)
        {
            if (pack.DamageType == "stab" || pack.DamageType == "incised")
            {
                pack.HealthDmg = (int)(pack.HealthDmg * 1.3f);
            }
            return pack;
        }

        public override StatPackage ModifyDefensive(StatPackage pack, List<string> otherItems)
        {
            pack.HealthDmg = (int)(pack.HealthDmg * 1.2f);
            return pack;
        }
    }
}
