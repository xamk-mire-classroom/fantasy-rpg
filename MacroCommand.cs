using System;
using System.Collections.Generic;

namespace Game_World
{
    public class MacroCommand : ICommand
    {
        private readonly List<ICommand> _commands = new List<ICommand>();

        // Adds a command to the macro
        public void AddCommand(ICommand command)
        {
            if (command == null)
                throw new ArgumentNullException(nameof(command), "Command cannot be null");

            _commands.Add(command);
        }

        // Executes all commands in sequence
        public void Execute()
        {
            if (_commands.Count == 0)
            {
                Console.WriteLine("No commands to execute in the macro.");
                return;
            }

            foreach (var command in _commands)
            {
                command.Execute();
            }
        }

        // Clears the commands from the macro
        public void ClearCommands()
        {
            _commands.Clear();
        }

        // Returns the number of commands in the macro
        public int Count => _commands.Count;
    }
}
