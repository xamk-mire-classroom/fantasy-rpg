using System;
using System.Collections.Generic;

namespace Game_World
{
    class Program
    {
        static void Main(string[] args)
        {
            // Singleton GameWorld
            var gameWorld = GameWorld.Instance;
            gameWorld.UpdateGameState("Night", "Rainy");
            Console.WriteLine($"Time of Day: {gameWorld.TimeOfDay}, Weather: {gameWorld.Weather}");

            // Character Creation using Factory
            Character warrior = CharacterFactory.CreateCharacter("Warrior", "Conan");
            Character mage = CharacterFactory.CreateCharacter("Mage", "Gandalf");
            Character archer = CharacterFactory.CreateCharacter("Archer", "Legolas");

            // Display character stats
            warrior.DisplayStats();
            mage.DisplayStats();
            archer.DisplayStats();

            // Set strategies and states
            warrior.SetActionStrategy(new MeleeAction());
            warrior.SetState(new ActionState());
            warrior.HandleState();

            mage.SetActionStrategy(new MagicAction());
            mage.SetState(new ActionState());
            mage.HandleState();

            archer.SetState(new DefendingState());
            archer.HandleState();

            // Create items using factories
            CreateItems();

            // Initialize GameController
            GameController gameController = new GameController();

            // Command Setup for Warrior
            SetupCharacterCommands(gameController, warrior, mage);




            Console.WriteLine("\nGame started! Press keys to control your character (Q to quit):");
            gameController.MapKey(ConsoleKey.A, new AttackCommand(warrior, mage)); // A for Attack
            gameController.MapKey(ConsoleKey.H, new HealCommand(warrior));         // H for Heal
            gameController.MapKey(ConsoleKey.M, new MoveCommand(warrior, new Position(5, 5))); // M for Move
            gameController.MapKey(ConsoleKey.D, new DefendCommand(warrior));       // D for Defend
           

            while (true)
            {
                gameController.HandleInput();
            }
        }

        // Creates items using factories and displays them
        static void CreateItems()
        {
            // Create Weapon, Potion, and Armor
            Weapon sword = new Weapon("Excalibur", ItemRarity.Legendary, 150, WeaponTypeEnum.Melee);
            Potion healingPotion = new Potion("Healing Potion", ItemRarity.Common, "Restores 50 health", 30);
            Armor dragonArmor = new Armor("Dragon Plate", ItemRarity.Rare, 100, 200);

            // Display item information
            sword.DisplayInfo();        // Output: Item: Excalibur, Rarity: Legendary, Damage: 150, Weapon Type: Melee
            healingPotion.DisplayInfo(); // Output: Item: Healing Potion, Rarity: Common, Effect: Restores 50 health
            dragonArmor.DisplayInfo();   // Output: Item: Dragon Plate, Rarity: Rare, Defense: 100, Durability: 200
        }

        // Setup Commands for a Character
        static void SetupCharacterCommands(GameController gameController, Character character, Character target)
        {
            ICommand attackCommand = new AttackCommand(character, target);
            ICommand defendCommand = new DefendCommand(character);
            ICommand healCommand = new HealCommand(character);
            ICommand moveCommand = new MoveCommand(character, new Position(3, 3));

            gameController.MapKey(ConsoleKey.A, attackCommand); // A => Attack
            gameController.MapKey(ConsoleKey.D, defendCommand); // D => Defend
            gameController.MapKey(ConsoleKey.H, healCommand);   // H => Heal
            gameController.MapKey(ConsoleKey.M, moveCommand);   // M => Move

            Console.WriteLine("\nCommands have been set for the character.");
        }
    }
}
