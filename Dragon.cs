public class Dragon : Enemy
{
    public Dragon(string rank, int health, int mana, int strength, int agility)
        : base("Dragon", health, mana, strength, agility, rank) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} ({Rank}) breathes fire on its target!");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} ({Rank}) flies through the air majestically.");
    }

    public override Enemy Clone()
    {
        return (Enemy)MemberwiseClone();
    }
}
