using System;

namespace Game_World
{
    public class DefendCommand : ICommand
    {
        private readonly Character _character;

        public DefendCommand(Character character)
        {
            _character = character;
        }

        public void Execute()
        {
            if (_character == null)
            {
                Console.WriteLine("Invalid action. Character is missing.");
                return;
            }

            Console.WriteLine($"{_character.Name} defends!");
            _character.EnterDefensiveStance();
        }
    }
}
