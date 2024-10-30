public class Goblin : Enemy
{
    public Goblin(string rank, int health, int mana, int strength, int agility)
        : base("Goblin", health, mana, strength, agility, rank) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} ({Rank}) attacks with a quick dagger strike!");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} ({Rank}) moves stealthily.");
    }

    public override Enemy Clone()
    {
        return (Enemy)MemberwiseClone();
    }
}
