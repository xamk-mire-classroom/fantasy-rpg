using System;

namespace Game_World
{
    class Program
    {
        static void Main(string[] args)
        {
            // Get the single instance of GameWorld
            GameWorld gameWorld = GameWorld.Instance;

            // Display the current state of the game world
            gameWorld.DisplayState();

            // Modify game state
            gameWorld.TimeOfDay = "Evening";
            gameWorld.Weather = "Rainy";

            // Display the updated state
            Console.WriteLine("\nUpdated Game State:");
            gameWorld.DisplayState();

            // Character Creation
            Console.WriteLine("\nWelcome to the Character Creation!");

            Console.Write("Enter character name: ");
            string characterName = Console.ReadLine();

            Console.Write("Enter character type (Warrior, Mage, Archer): ");
            string characterType = Console.ReadLine();

            Character character;
            try
            {
                // Create the character using the factory
                character = CharacterFactory.CreateCharacter(characterType, characterName);

                // Display character stats
                Console.WriteLine("\nCharacter Created!");
                character.DisplayStats();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // Enemy Creation
            Console.WriteLine("\nEnemy Creation!");

            Console.Write("Enter enemy type (Slime, Goblin, Dragon): ");
            string enemyType = Console.ReadLine();

            Console.Write("Enter enemy rank (Normal, Elite, Boss): ");
            string enemyRank = Console.ReadLine();

            Enemy enemy;
            try
            {
                // Create enemy using the factory
                enemy = EnemyFactory.CreateEnemy(enemyType, enemyRank);

                // Display enemy stats and actions
                enemy.DisplayStats();
                enemy.Move();
                enemy.Attack();
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            // Quest Notifications
            QuestManager questManager = new QuestManager();
            PlayerCharacter player = new PlayerCharacter(characterName);
            QuestNPC villager = new QuestNPC("Villager");
            QuestNPC blacksmith = new QuestNPC("Blacksmith");

            questManager.RegisterObserver(player);
            questManager.RegisterObserver(villager);
            questManager.RegisterObserver(blacksmith);

            questManager.ChangeQuestState("Quest Started: Defend the Village");
            questManager.ChangeQuestState("Quest Updated: Gather Reinforcements");
            questManager.ChangeQuestState("Quest Completed: Victory!");
            questManager.UnregisterObserver(villager);
            questManager.ChangeQuestState("New Quest Started: Repair the Village!");

            // Commands and Controller
            GameController gameController = new GameController();
            Controller controller = new Controller();

            ICommand attackCommand = new AttackCommand(character, enemy);
            ICommand defendCommand = new DefendCommand(character);
            ICommand healCommand = new HealCommand(character);
            ICommand moveCommand = new MoveCommand(character, "Forest");

            // Map keys to commands
            controller.MapKeyToCommand(ConsoleKey.A, attackCommand);
            controller.MapKeyToCommand(ConsoleKey.D, defendCommand);
            controller.MapKeyToCommand(ConsoleKey.H, healCommand);
            controller.MapKeyToCommand(ConsoleKey.M, moveCommand);

            Console.WriteLine("\nWelcome to the Game!");
            Console.WriteLine("Use the following keys to control your character:");
            Console.WriteLine("A - Attack | D - Defend | H - Heal | M - Move | Q - Quit");

            // Game loop
            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("\nPress a key: ");
                ConsoleKey key = Console.ReadKey(true).Key;

                if (key == ConsoleKey.Q)
                {
                    Console.WriteLine("\nExiting the game. Goodbye!");
                    Console.ReadLine();
                    isRunning = false;
                }
                else
                {
                    controller.HandleKeyPress(key);

                    // Check if the enemy is defeated
                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine($"\n{enemy.Name} has been defeated! You win!");
                        Console.ReadLine();
                        isRunning = false; // End the game loop
                    }
                }
            }

            // Final Stats
            Console.WriteLine("\nFinal Stats:");
            character.DisplayStats();
            enemy.DisplayStats();
        }
    }
}
