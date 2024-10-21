
using Game_World;



public interface IActionStrategy
{
    void PerformAction(Character character);






    // MeleeAction class implementing the IActionStrategy interface
    public class MeleeAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} performs a melee attack!");
        }
    }

    // RangedAction class implementing the IActionStrategy interface
    public class RangedAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} shoots an arrow!");
        }
    }

    // MagicAction class implementing the IActionStrategy interface
    public class MagicAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} casts a spell!");
        }
    }

    // HealAction class implementing the IActionStrategy interface
    public class HealAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} heals for 20 HP!");
        }
    }
}
