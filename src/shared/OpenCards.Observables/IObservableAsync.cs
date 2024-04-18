namespace OpenCards.Observables;

public interface IObservableAsync<T> : IObservableAsync
{
    public void Subscribe(IObserverAsync<T> observer);

    public ValueTask NotifyAsync(T value);
}
