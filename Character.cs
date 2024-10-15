public abstract class Character
{
    public string Name { get; private set; }
    public int Health { get; protected set; }
    public int Mana { get; protected set; }
    public int Strength { get; protected set; }
    public int Agility { get; protected set; }

    protected Character(string name)
    {
        Name = name;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Name: {Name}, Health: {Health}, Mana: {Mana}, Strength: {Strength}, Agility: {Agility}");
    }
}

public class Warrior : Character
{
    public Warrior(string name) : base(name)
    {
        Health = 150;
        Mana = 50;
        Strength = 100;
        Agility = 30;
    }
}

public class Mage : Character
{
    public Mage(string name) : base(name)
    {
        Health = 80;
        Mana = 150;
        Strength = 20;
        Agility = 40;
    }
}

public class Archer : Character
{
    public Archer(string name) : base(name)
    {
        Health = 100;
        Mana = 75;
        Strength = 70;
        Agility = 80;
    }
}
