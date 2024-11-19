using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public abstract class Item
    {
        public string Name { get; set; }
        public ItemRarity Rarity { get; set; }

        protected Item(string name, ItemRarity rarity)
        {
            Name = name;
            Rarity = rarity;
        }

        public abstract void DisplayStats();
    }
}
