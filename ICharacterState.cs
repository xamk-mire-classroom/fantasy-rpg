using Game_World;

public interface ICharacterState
{
    void HandleState(Character character);


    public class IdleState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is idle and doing nothing.");
        }
    }

    public class ActionState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is ready to perform an action.");
            character.PerformAction(); // Execute the current action strategy (e.g., MeleeAction, MagicAction)
        }
    }

    public class DefendingState : ICharacterState
    {
        public void HandleState(Character character)
        {
            Console.WriteLine($"{character.Name} is defending and cannot perform other actions.");
        }
    }
}

