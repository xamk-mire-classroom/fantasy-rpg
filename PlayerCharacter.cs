public class PlayerCharacter : IObserver
{
    public string Name { get; set; }

    public PlayerCharacter(string name)
    {
        Name = name;
    }

    public void Update(string questStatus)
    {
        Console.WriteLine($"{Name} has been notified of quest status change: {questStatus}");
    }
}

public class NPC : IObserver
{
    public string Name { get; set; }

    public NPC(string name)
    {
        Name = name;
    }

    public void Update(string questStatus)
    {
        Console.WriteLine($"{Name} (NPC) has been notified of quest status change: {questStatus}");
    }
}
