using Game_World;

public abstract class Item  // Base class for all items
{
    public string Name { get; private set; }  // Common property for all items
    public ItemRarity Rarity { get; private set; }  // Common property for rarity

    // Constructor to initialize item name and rarity
    protected Item(string name, ItemRarity rarity)
    {
        Name = name;
        Rarity = rarity;
    }

    // Method to display item info (optional)
    public virtual void DisplayInfo()
    {
        Console.WriteLine($"Item: {Name}, Rarity: {Rarity}");
    }
}
