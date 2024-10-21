using Game_World;

public class Armor : Item
{
    public int Defense { get; private set; }  // Unique attribute for Armor (defense level)
    public int Durability { get; private set; }  // Durability of the armor

    // Constructor to initialize armor-specific properties
    public Armor(string name, ItemRarity rarity, int defense, int durability)
        : base(name, rarity)  // Call the base class constructor
    {
        Defense = defense;
        Durability = durability;
    }

    // Override the method to display Armor-specific details
    public override void DisplayInfo()
    {
        base.DisplayInfo();  // Call base method to display common item info
        Console.WriteLine($"Defense: {Defense}, Durability: {Durability}");
    }
}
