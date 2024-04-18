namespace OpenCards.Observables;

public interface IObservableContainer
{
    ValueTask NotifyAsync<T>(T value) where T : class;
}
