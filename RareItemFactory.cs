using Game_World;

public class RareItemFactory : ItemFactory
{
    public override Weapon CreateWeapon(string name, WeaponTypeEnum weaponType)
    {
        return new Weapon(name, ItemRarity.Rare, 50, weaponType);  // Superior damage for rare items
    }

    public override Potion CreatePotion(string name, string effect, int duration)
    {
        return new Potion(name, ItemRarity.Rare, effect, duration * 3);  // Even longer duration for rare potions
    }

    public override Armor CreateArmor(string name, int defense, int durability)
    {
        return new Armor(name, ItemRarity.Rare, defense * 3, durability);  // Superior defense for rare armor
    }
}
