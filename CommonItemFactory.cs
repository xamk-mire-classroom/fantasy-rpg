using Game_World;

public class CommonItemFactory : ItemFactory
{
    public override Weapon CreateWeapon(string name, WeaponTypeEnum weaponType)
    {
        return new Weapon(name, ItemRarity.Common, 10, weaponType);  // Low damage for common weapons
    }

    public override Potion CreatePotion(string name, string effect, int duration)
    {
        return new Potion(name, ItemRarity.Common, effect, duration);  // Short duration for common potions
    }

    public override Armor CreateArmor(string name, int defense, int durability)
    {
        return new Armor(name, ItemRarity.Common, defense, durability);  // Low defense and durability
    }
}
