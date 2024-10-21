namespace Game_World
{
    // Abstract base class Character
    public abstract class Character
    {
        // Properties common to all characters
        public string Name { get; private set; }
        public int Health { get; protected set; }
        public int Mana { get; protected set; }
        public int Strength { get; protected set; }
        public int Agility { get; protected set; }

        // Private fields to manage the state and action strategy
        private ICharacterState _currentState;
        private IActionStrategy _actionStrategy;

        // Constructor to initialize the name
        protected Character(string name)
        {
            Name = name;
            _currentState = new IdleState(); // Default state is idle
        }

        // Method to display character stats
        public void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}, Health: {Health}, Mana: {Mana}, Strength: {Strength}, Agility: {Agility}");
        }

        // Method to change the current state of the character
        public void SetState(ICharacterState newState)
        {
            _currentState = newState;
        }

        // Method to change the current action strategy
        public void SetActionStrategy(IActionStrategy newStrategy)
        {
            _actionStrategy = newStrategy;
        }

        // Method to execute the current state's behavior
        public void HandleState()
        {
            _currentState.HandleState(this);
        }

        // Method to perform the current action strategy
        public void PerformAction()
        {
            _actionStrategy?.PerformAction(this);
        }
    }

    // Derived class Warrior with specific stats
    public class Warrior : Character
    {
        public Warrior(string name) : base(name)
        {
            Health = 150;
            Mana = 50;
            Strength = 100;
            Agility = 30;
        }
    }

    // Derived class Mage with specific stats
    public class Mage : Character
    {
        public Mage(string name) : base(name)
        {
            Health = 80;
            Mana = 150;
            Strength = 20;
            Agility = 40;
        }
    }

    // Derived class Archer with specific stats
    public class Archer : Character
    {
        public Archer(string name) : base(name)
        {
            Health = 100;
            Mana = 75;
            Strength = 70;
            Agility = 80;
        }
    }

    // Interface for character state (part of the State Pattern)
    public interface ICharacterState
    {
        void HandleState(Character character);
    }

    // IdleState (Concrete state when character is idle)
    public class IdleState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is idle and doing nothing.");
        }
    }

    // ActionState (Concrete state when character is ready to perform an action)
    public class ActionState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is ready to perform an action.");
            character.PerformAction();
        }
    }

    // DefendingState (Concrete state when character is defending)
    public class DefendingState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is defending and cannot perform other actions.");
        }
    }

    // Interface for action strategies (part of the Strategy Pattern)
    public interface IActionStrategy
    {
        void PerformAction(Character character);
    }

    // Concrete strategy for melee action
    public class MeleeAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} performs a melee attack!");
        }
    }

    // Concrete strategy for magic action
    public class MagicAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} casts a magic spell!");
        }
    }

    // Concrete strategy for healing action
    public class HealAction : IActionStrategy
    {
        public void PerformAction(Character character)
        {
            Console.WriteLine($"{character.Name} heals and restores health.");
        }
    }
}
