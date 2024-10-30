public class EnemyFactory
{
    private Dictionary<string, Enemy> _enemyPrototypes = new Dictionary<string, Enemy>();

    public EnemyFactory()
    {
        // Initialize prototypes with base stats
        _enemyPrototypes["Slime"] = new Slime("Normal", 30, 0, 5, 5);
        _enemyPrototypes["Goblin"] = new Goblin("Normal", 50, 10, 10, 10);
        _enemyPrototypes["Dragon"] = new Dragon("Normal", 200, 100, 50, 30);
    }

    public Enemy CreateEnemy(string type, string rank, int health, int mana, int strength, int agility)
    {
        if (_enemyPrototypes.ContainsKey(type))
        {
            // Clone the prototype and modify its properties for the specific instance
            Enemy enemy = _enemyPrototypes[type].Clone();
            enemy.Rank = rank;
            enemy.Health = health;
            enemy.Mana = mana;
            enemy.Strength = strength;
            enemy.Agility = agility;
            return enemy;
        }
        throw new ArgumentException("Unknown enemy type.");
    }
}
