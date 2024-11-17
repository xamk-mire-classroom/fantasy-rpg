using System;
using System.Collections.Generic;

namespace Game_World
{
    public class GameController
    {
        private readonly Dictionary<ConsoleKey, ICommand> _keyMappings = new Dictionary<ConsoleKey, ICommand>();

        public GameController(Character character, Character target)
      
            {
                // Initialize key mappings for character commands
                _keyMappings[ConsoleKey.A] = new AttackCommand(character, target);    // AttackCommand requires target
                _keyMappings[ConsoleKey.D] = new DefendCommand(character);            // DefendCommand only requires character
                _keyMappings[ConsoleKey.H] = new HealCommand(character, 20);          // HealCommand requires healing amount

                // MoveCommand requires both character and new position
                Position newPosition = new Position(5, 10); // Example position
                _keyMappings[ConsoleKey.M] = new MoveCommand(character, newPosition);  // Create MoveCommand with a position

               
            }

        

        public void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKey key = Console.ReadKey(intercept: true).Key;

                if (key == ConsoleKey.Q)
                {
                    Console.WriteLine("Exiting the game...");
                    Environment.Exit(0);
                }

                if (_keyMappings.TryGetValue(key, out ICommand command))
                {
                    command.Execute();
                }
                else
                {
                    Console.WriteLine("Invalid key. No action mapped to this key.");
                }
            }
        }

        // Method for custom key mappings
        public void SetKeyMapping(ConsoleKey key, ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), "Command cannot be null");

            _keyMappings[key] = command;
        }

        // Displays all current key mappings (Optional: For debugging or showing controls)
        public void DisplayMappings()
        {
            Console.WriteLine("Key Mappings:");
            foreach (var mapping in _keyMappings)
            {
                Console.WriteLine($"{mapping.Key} => {mapping.Value.GetType().Name}");
            }
        }
    }
}
