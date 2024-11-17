using System;

namespace Game_World
{
    public class AttackCommand : ICommand
    {
        private readonly Character _attacker; // Use consistent naming
        private readonly Character _target;

        public AttackCommand(Character attacker, Character target)
        {
            _attacker = attacker;
            _target = target;
        }

        public void Execute()
        {
            if (_target == null || _attacker == null)
            {
                Console.WriteLine("Invalid attack. Either attacker or target is missing.");
                return;
            }

            Console.WriteLine($"{_attacker.Name} attacks {_target.Name} for {_attacker.AttackPower} damage!");
            _target.Health -= _attacker.AttackPower;

            // Optionally check if target is defeated
            if (_target.Health <= 0)
            {
                Console.WriteLine($"{_target.Name} has been defeated!");
                _target.Health = 0; // Prevent negative health
            }
        }
    }
}
