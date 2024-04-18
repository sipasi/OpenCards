namespace OpenCards.Observables;

public interface IObservableAsync;

public interface IObserverAsync<in T>
{
    ValueTask Notify(T value);
}
