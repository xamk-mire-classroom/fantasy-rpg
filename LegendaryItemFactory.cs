using Game_World;

public class LegendaryItemFactory : ItemFactory
{
    public override Weapon CreateWeapon(string name, WeaponTypeEnum weaponType)
    {
        return new Weapon(name, ItemRarity.Legendary, 100, weaponType);  // Legendary damage for legendary items
    }

    public override Potion CreatePotion(string name, string effect, int duration)
    {
        return new Potion(name, ItemRarity.Legendary, effect, duration * 4);  // Legendary duration for potions
    }

    public override Armor CreateArmor(string name, int defense, int durability)
    {
        return new Armor(name, ItemRarity.Legendary, defense * 4, durability * 2);  // Legendary defense and durability
    }
}
