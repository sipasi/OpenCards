namespace OpenCards.Observables;

public class ObservableAsync<T> : IObservableAsync<T>
{
    private readonly List<IObserverAsync<T>> listeners = [];

    public void Subscribe(IObserverAsync<T> listener)
    {
        listeners.Add(listener);
    }

    public async ValueTask NotifyAsync(T value)
    {
        foreach (var listener in listeners)
        {
            await listener.Notify(value);
        }
    }
}
