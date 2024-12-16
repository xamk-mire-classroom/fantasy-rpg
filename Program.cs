using System;
using System.Collections.Generic;

namespace Game_World
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the single instance of GameWorld
            GameWorld gameWorld = GameWorld.Instance;

            // Modify the game state
            gameWorld.TimeOfDay = "Evening";
            gameWorld.Weather = "Rainy";

            // Display the updated state
            Console.WriteLine("\nGame State:");
            gameWorld.DisplayState();

            // Character Creation
            Character character = CreateCharacter();

            // Inventory Management
            ManageInventory(character);

            // Enemy Creation
            List<Enemy> enemies = CreateEnemies();

            // Start Combat
            StartCombat(character, enemies);

            Console.WriteLine("\nThank you for playing!");
            Console.ReadLine(); // Wait for user input before closing
        }

        // Character Creation
        static Character CreateCharacter()
        {
            Console.WriteLine("\nWelcome to the Character Creation!");

            Console.Write("Enter character name: ");
            string characterName = Console.ReadLine();

            Console.Write("Enter character type (Warrior, Mage, Archer): ");
            string characterType = Console.ReadLine();

            try
            {
                Character character = CharacterFactory.CreateCharacter(characterType, characterName);
                Console.WriteLine("\nCharacter Created!");
                character.DisplayStats();
                return character;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"\nError: {e.Message}");
                return CreateCharacter(); // Retry on invalid input
            }
        }

        // Inventory Management Function
        static void ManageInventory(Character character)
        {
            bool managingInventory = true;

            while (managingInventory)
            {
                Console.WriteLine("\nInventory Management:");
                Console.WriteLine("1. Add Item");
                Console.WriteLine("2. View Inventory");
                Console.WriteLine("3. Remove Item");
                Console.WriteLine("4. Exit Inventory Management");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddItemToInventory(character);
                        break;

                    case "2":
                        character.Inventory.ListItems();
                        break;

                    case "3":
                        Console.Write("Enter the name of the item to remove: ");
                        string itemName = Console.ReadLine();
                        character.Inventory.RemoveItem(itemName);
                        break;

                    case "4":
                        managingInventory = false;
                        Console.WriteLine("Exiting Inventory Management...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        // Add Item to Inventory
        static void AddItemToInventory(Character character)
        {
            Console.WriteLine("Select item type to add: 1. Weapon, 2. Defensive, 3. Utility");
            string itemTypeChoice = Console.ReadLine();

            try
            {
                switch (itemTypeChoice)
                {
                    case "1":
                        Console.Write("Enter Weapon Name: ");
                        string weaponName = Console.ReadLine();
                        Console.Write("Enter Weapon Damage: ");
                        int weaponDamage = int.Parse(Console.ReadLine());
                        Weapon weapon = new Weapon(weaponName, ItemRarity.Common, weaponDamage, WeaponTypeEnum.Melee);
                        character.Inventory.AddItemAndAssignToEquipment(weapon, character);
                        break;

                    case "2":
                        Console.Write("Enter Defensive Item Name: ");
                        string defensiveName = Console.ReadLine();
                        Console.Write("Enter Defense Value: ");
                        int defense = int.Parse(Console.ReadLine());
                        DefensiveItem defensiveItem = new DefensiveItem(defensiveName, ItemRarity.Common, defense);
                        character.Inventory.AddItemAndAssignToEquipment(defensiveItem, character);
                        break;

                    case "3":
                        Console.Write("Enter Utility Item Name: ");
                        string utilityName = Console.ReadLine();
                        Console.Write("Enter Effect: ");
                        string effect = Console.ReadLine();
                        UtilityItem utilityItem = new UtilityItem(utilityName, ItemRarity.Common, effect);
                        character.Inventory.AddItemAndAssignToEquipment(utilityItem, character);
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please try again.");
            }
        }

        // Enemy Creation
        static List<Enemy> CreateEnemies()
        {
            List<Enemy> enemies = new List<Enemy>();
            Console.WriteLine("\nEnemy Creation!");

            for (int i = 0; i < 2; i++) // Create 2 enemies
            {
                Console.Write($"Enter enemy type for Enemy {i + 1} (Slime, Goblin, Dragon): ");
                string enemyType = Console.ReadLine();

                Console.Write($"Enter enemy rank for Enemy {i + 1} (Normal, Elite, Boss): ");
                string enemyRank = Console.ReadLine();

                try
                {
                    enemies.Add(EnemyFactory.CreateEnemy(enemyType, enemyRank));
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine($"\nError: {e.Message}");
                    i--; // Retry current enemy creation
                }
            }

            Console.WriteLine("\nEnemies Created!");
            foreach (var enemy in enemies)
            {
                enemy.DisplayStats();
            }

            return enemies;
        }

        // Start Combat
        static void StartCombat(Character character, List<Enemy> enemies)
        {
            CombatManager combatManager = new CombatManager(new List<Character> { character }, enemies);
            combatManager.StartCombat();

            Console.WriteLine("\nFinal Stats:");
            character.DisplayStats();
            foreach (var enemy in enemies)
            {
                enemy.DisplayStats();
            }
        }
    }
}
