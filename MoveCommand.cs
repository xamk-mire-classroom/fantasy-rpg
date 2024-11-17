using System;

namespace Game_World
{
    public class MoveCommand : ICommand
    {
        private readonly Character _character;
        private readonly Position _newPosition;

        public MoveCommand(Character character, Position newPosition)
        {
            _character = character ?? throw new ArgumentNullException(nameof(character));
            _newPosition = newPosition ?? throw new ArgumentNullException(nameof(newPosition));
        }

        public void Execute()
        {
            if (_character == null || _newPosition == null)
            {
                Console.WriteLine("Move action failed: Character or position is invalid.");
                return;
            }

            Console.WriteLine($"{_character.Name} moves to ({_newPosition.X}, {_newPosition.Y})!");
            _character.Position = _newPosition;
        }
    }
}
