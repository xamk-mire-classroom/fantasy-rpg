using Game_World;

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

        // Set action and state for warrior
        warrior.SetActionStrategy(new MeleeAction());
        warrior.SetState(new ActionState());
        warrior.HandleState();  // Output: Conan is ready to perform an action. Conan performs a melee attack!

        // Set action and state for mage
        mage.SetActionStrategy(new MagicAction());
        mage.SetState(new ActionState());
        mage.HandleState();  // Output: Gandalf is ready to perform an action. Gandalf casts a magic spell!

        // Set state for archer (defending)
        archer.SetState(new DefendingState());
        archer.HandleState();  // Output: Legolas is defending and cannot perform other actions.

        // Create a Weapon (Melee)
        Weapon sword = new Weapon("Excalibur", ItemRarity.Legendary, 150, WeaponTypeEnum.Melee);

        // Create a Potion
        Potion healingPotion = new Potion("Healing Potion", ItemRarity.Common, "Restores 50 health", 30);

        // Create an Armor
        Armor dragonArmor = new Armor("Dragon Plate", ItemRarity.Rare, 100, 200);

        // Display item information
        sword.DisplayInfo();  // Output: Item: Excalibur, Rarity: Legendary, Damage: 150, Weapon Type: Melee
        healingPotion.DisplayInfo();  // Output: Item: Healing Potion, Rarity: Common, Effect: Restores 50 health, Duration: 30 seconds
        dragonArmor.DisplayInfo();  // Output: Item: Dragon Plate, Rarity: Rare, Defense: 100, Durability: 200

        // Create common items using the CommonItemFactory
        ItemFactory commonFactory = new CommonItemFactory();
        Weapon commonSword = commonFactory.CreateWeapon("Common Sword", WeaponTypeEnum.Melee);
        Potion commonPotion = commonFactory.CreatePotion("Healing Potion", "Restores 20 health", 10);
        Armor commonArmor = commonFactory.CreateArmor("Leather Armor", 15, 30);

        // Create a Legendary Item Factory
        ItemFactory legendaryFactory = new LegendaryItemFactory();
        Weapon legendarySword = legendaryFactory.CreateWeapon("Excalibur", WeaponTypeEnum.Melee);
        Potion legendaryPotion = legendaryFactory.CreatePotion("Elixir of Life", "Restores full health", 30);
        Armor legendaryArmor = legendaryFactory.CreateArmor("Dragon Armor", 150, 500);

        // Display the created items
        commonSword.DisplayInfo();  // Output: Item: Common Sword, Rarity: Common, Damage: 10, Weapon Type: Melee
        legendarySword.DisplayInfo();  // Output: Item: Excalibur, Rarity: Legendary, Damage: 150, Weapon Type: Melee

        commonPotion.DisplayInfo();  // Output: Item: Healing Potion, Rarity: Common, Effect: Restores 20 health, Duration: 10 seconds
        legendaryPotion.DisplayInfo();  // Output: Item: Elixir of Life, Rarity: Legendary, Effect: Restores full health, Duration: 120 seconds

        commonArmor.DisplayInfo();  // Output: Item: Leather Armor, Rarity: Common, Defense: 15, Durability: 30
        legendaryArmor.DisplayInfo();  // Output: Item: Dragon Armor, Rarity: Legendary, Defense: 600, Durability: 1000
    }
}
