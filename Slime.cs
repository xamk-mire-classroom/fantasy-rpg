public class Slime : Enemy
{
    public Slime(string rank, int health, int mana, int strength, int agility)
        : base("Slime", health, mana, strength, agility, rank) { }

    public override void Attack()
    {
        Console.WriteLine($"{Name} ({Rank}) attacks with a weak acid splash!");
    }

    public override void Move()
    {
        Console.WriteLine($"{Name} ({Rank}) slowly moves by slithering.");
    }

    public override Enemy Clone()
    {
        return (Enemy)MemberwiseClone();
    }
}
