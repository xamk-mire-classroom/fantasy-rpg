public abstract class Enemy
{
    public string Name { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Strength { get; set; }
    public int Agility { get; set; }
    public string Rank { get; set; }  // Ranking to indicate the level or class of the enemy

    public Enemy(string name, int health, int mana, int strength, int agility, string rank)
    {
        Name = name;
        Health = health;
        Mana = mana;
        Strength = strength;
        Agility = agility;
        Rank = rank;
    }

    // Basic actions for enemies
    public abstract void Attack();
    public abstract void Move();

    // Prototype method for cloning
    public abstract Enemy Clone();
}
