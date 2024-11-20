namespace Game_World
{
    public abstract class Character
    {
        // Character Properties
        public string Name { get; set; }
        public int Health { get; set; }
        public int Mana { get; set; }
        public int Strength { get; set; }
        public int Agility { get; set; }
        public Inventory Inventory { get; private set; }

        // Strategy Pattern Property
        public IActionStrategy ActionStrategy { get; set; }

        // State Pattern Property
        private ICharacterState _currentState;

        // Default Constructor
        public Character(string name)
        {
            // Validate name
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Character name cannot be null or empty.");

            Name = name;
            Health = 100; // Default health
            Mana = 50;    // Default mana
            Strength = 20; // Default strength
            Agility = 15;  // Default agility

            _currentState = new IdleState(); // Default state
            Inventory = new Inventory();     // Initialize Inventory
        }

        // Overloaded Constructor for Custom Initialization
        public Character(string name, int health, int mana, int strength, int agility) : this(name)
        {
            Health = health;
            Mana = mana;
            Strength = strength;
            Agility = agility;
        }

        // Method to Change the Character's State
        public void ChangeState(ICharacterState newState)
        {
            if (newState == null)
                throw new ArgumentNullException(nameof(newState), "State cannot be null.");
            _currentState = newState;
        }

        // Handle the Current State
        public void HandleState()
        {
            if (_currentState == null)
            {
                Console.WriteLine($"{Name} is in an undefined state.");
                return;
            }

            _currentState.HandleState(this);
        }

        // Perform an Action Using the Strategy Pattern
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

        // Display Character Stats and Inventory
        public virtual void DisplayStats()
        {
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health} | Mana: {Mana}");
            Console.WriteLine($"Strength: {Strength} | Agility: {Agility}");
            Console.WriteLine("\nInventory:");
            Inventory.ListItems();
        }

        // Helper Method to Display Character's Current State
        public void DisplayCurrentState()
        {
            if (_currentState != null)
                Console.WriteLine($"{Name} is currently {_currentState.GetType().Name}.");
            else
                Console.WriteLine($"{Name} has no defined state.");
        }

        // Method to Add Item to Inventory
        public void AddItemToInventory(Item item)
        {
            Inventory.AddItem(item);
        }

        // Method to Remove Item from Inventory
        public void RemoveItemFromInventory(string itemName)
        {
            Inventory.RemoveItem(itemName);
        }
    }
}
