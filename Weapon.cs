using Game_World;

public enum WeaponTypeEnum  // Enum to classify weapon types
{
    Melee,
    Ranged
}

public class Weapon : Item
{
    public int Damage { get; private set; }  // Unique attribute for Weapon
    public WeaponTypeEnum WeaponType { get; private set; }  // Type of weapon (Melee or Ranged)

    // Constructor to initialize weapon-specific properties
    public Weapon(string name, ItemRarity rarity, int damage, WeaponTypeEnum weaponType)
        : base(name, rarity)  // Call the base class constructor
    {
        Damage = damage;
        WeaponType = weaponType;
    }

    // Override the method to display Weapon-specific details
    public override void DisplayInfo()
    {
        base.DisplayInfo();  // Call base method to display common item info
        Console.WriteLine($"Damage: {Damage}, Weapon Type: {WeaponType}");
    }
}
