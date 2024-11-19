using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game_World
{
    public class Potion : Item
    {
        public string Effect { get; set; }
        public int Duration { get; set; }

        public Potion(string name, ItemRarity rarity, string effect, int duration)
            : base(name, rarity)
        {
            Effect = effect;
            Duration = duration;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Potion: {Name} | Rarity: {Rarity} | Effect: {Effect} | Duration: {Duration}s");
        }
    }
}
