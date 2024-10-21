using Game_World;

public class Potion : Item
{
    public string Effect { get; private set; }  // Unique attribute for Potion (what it does)
    public int Duration { get; private set; }   // Duration of the effect in seconds

    // Constructor to initialize potion-specific properties
    public Potion(string name, ItemRarity rarity, string effect, int duration)
        : base(name, rarity)  // Call the base class constructor
    {
        Effect = effect;
        Duration = duration;
    }

    // Override the method to display Potion-specific details
    public override void DisplayInfo()
    {
        base.DisplayInfo();  // Call base method to display common item info
        Console.WriteLine($"Effect: {Effect}, Duration: {Duration} seconds");
    }
}
