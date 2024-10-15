public class CharacterFactory
{
    public static Character CreateCharacter(string characterType, string name)
    {
        return characterType switch
        {
            "Warrior" => new Warrior(name),
            "Mage" => new Mage(name),
            "Archer" => new Archer(name),
            _ => throw new ArgumentException($"Unknown character type: {characterType}")
        };
    }
}
