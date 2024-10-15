class Program
{
    static void Main(string[] args)
    {
        // Using the Singleton GameWorld
        var gameWorld = GameWorld.Instance;
        gameWorld.UpdateGameState("Night", "Rainy");
        Console.WriteLine($"Time of Day: {gameWorld.TimeOfDay}, Weather: {gameWorld.Weather}");

        // Creating characters using the Factory Method
        Character warrior = CharacterFactory.CreateCharacter("Warrior", "Conan");
        Character mage = CharacterFactory.CreateCharacter("Mage", "Gandalf");
        Character archer = CharacterFactory.CreateCharacter("Archer", "Legolas");

        // Display character stats
        warrior.DisplayStats();  // Output: Name: Conan, Health: 150, Mana: 50, Strength: 100, Agility: 30
        mage.DisplayStats();     // Output: Name: Gandalf, Health: 80, Mana: 150, Strength: 20, Agility: 40
        archer.DisplayStats();   // Output: Name: Legolas, Health: 100, Mana: 75, Strength: 70, Agility: 80
    }
}
