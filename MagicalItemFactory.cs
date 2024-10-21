using Game_World;

public class MagicalItemFactory : ItemFactory
{
    public override Weapon CreateWeapon(string name, WeaponTypeEnum weaponType)
    {
        return new Weapon(name, ItemRarity.Magical, 30, weaponType);  // Enhanced damage for magical items
    }

    public override Potion CreatePotion(string name, string effect, int duration)
    {
        return new Potion(name, ItemRarity.Magical, effect, duration * 2);  // Extended duration for magical potions
    }

    public override Armor CreateArmor(string name, int defense, int durability)
    {
        return new Armor(name, ItemRarity.Magical, defense * 2, durability);  // Enhanced defense for magical armor
    }
}
