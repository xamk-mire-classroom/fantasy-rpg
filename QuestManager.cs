public class QuestManager : ISubject
{
    private List<IObserver> observers = new List<IObserver>();
    private string questStatus;

    public void Subscribe(IObserver observer)
    {
        observers.Add(observer);
    }

    public void Unsubscribe(IObserver observer)
    {
        observers.Remove(observer);
    }

    public void NotifyObservers(string questStatus)
    {
        foreach (IObserver observer in observers)
        {
            observer.Update(questStatus);
        }
    }

    public void UpdateQuestStatus(string newStatus)
    {
        questStatus = newStatus;
        NotifyObservers(questStatus);
    }
}
