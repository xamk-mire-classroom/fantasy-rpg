using System;

namespace Game_World
{
    public class HealCommand : ICommand
    {
        private readonly Character _character;

        public HealCommand(Character character)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
        }

        public void Execute()
        {
            if (_character == null)
            {
                Console.WriteLine("No character available to heal.");
                return;
            }

            Console.WriteLine($"{_character.Name} heals for {_character.HealAmount} health points!");
            _character.Health += _character.HealAmount;

            // Optional: Prevent exceeding maximum health
            if (_character.Health > _character.MaxHealth)
            {
                _character.Health = _character.MaxHealth;
                Console.WriteLine($"{_character.Name} is now at full health!");
            }
        }
    }
}
