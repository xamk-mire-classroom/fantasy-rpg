namespace Game_World
{
    public abstract class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }

        // Strategy property
        public IActionStrategy ActionStrategy { get; set; }

        // State property
        private ICharacterState _currentState;

        public Character(string name)
        {
            Name = name;
            _currentState = new IdleState(); // Default state
        }

        // Method to change the character's state
        public void ChangeState(ICharacterState newState)
        {
            _currentState = newState;
        }

        // Handle the current state
        public void HandleState()
        {
            _currentState.HandleState(this);
        }

        public void PerformAction()
        {
            if (ActionStrategy != null)
            {
                ActionStrategy.PerformAction(this);
            }
            else
            {
                Console.WriteLine($"{Name} has no action strategy set!");
            }
        }

        public virtual void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}, Mana: {Mana}");
            Console.WriteLine($"Strength: {Strength}, Agility: {Agility}");
        }
    }
}
