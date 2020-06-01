using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Game.Engine.Items.UncommonWeapon;

namespace Game.Engine.Items.ItemFactories
{
    [Serializable]
    class UncommonWeaponFactory : ItemFactory
    {
        public Item CreateItem()
        {
            List<Item> uncommonWeapon = new List<Item>()
            {
                new LuckySword(),
                new TraitorsBlade(),
                new VampiricFalchion()
            };
            return uncommonWeapon[Index.RNG(0, uncommonWeapon.Count)];
        }
        public Item CreateNonMagicItem()
        {
            List<Item> uncommonWeapon = new List<Item>()
            {
                new LuckySword(),
                new TraitorsBlade(),
                new VampiricFalchion()
            };
            return uncommonWeapon[Index.RNG(0, uncommonWeapon.Count)];
        }
        public Item CreateNonWeaponItem()
        {
            return null;
        }
    }
}
