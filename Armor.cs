using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{

    public class Armor : Item
    {
        public int Defense { get; set; }
        public int Durability { get; set; }

        public Armor(string name, ItemRarity rarity, int defense, int durability)
            : base(name, rarity)
        {
            Defense = defense;
            Durability = durability;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Armor: {Name} | Rarity: {Rarity} | Defense: {Defense} | Durability: {Durability}");
        }
    }
}
