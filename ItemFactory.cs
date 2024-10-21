public abstract class ItemFactory
{
    public abstract Weapon CreateWeapon(string name, WeaponTypeEnum weaponType);
    public abstract Potion CreatePotion(string name, string effect, int duration);
    public abstract Armor CreateArmor(string name, int defense, int durability);
}
