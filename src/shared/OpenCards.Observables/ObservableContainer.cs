namespace OpenCards.Observables;

public class ObservableContainer : IObservableContainer
{
    private readonly Dictionary<Type, IObservableAsync> events = [];

    public ObservableContainer Register<T>(IObserverAsync<T> observer) where T : class
    {
        Type type = typeof(T);

        if (events.ContainsKey(type) is false)
        {
            events.Add(type, new ObservableAsync<T>());
        }

        IObservableAsync<T> observable = Get<T>()!;

        observable.Subscribe(observer);

        return this;
    }

    public ValueTask NotifyAsync<T>(T value) where T : class
    {
        IObservableAsync<T> observable = Get<T>()!;

        return observable is not null
            ? observable.NotifyAsync(value)
            : ValueTask.CompletedTask;
    }

    private IObservableAsync<T>? Get<T>() where T : class
    {
        Type type = typeof(T);

        return events.TryGetValue(type, out IObservableAsync? value)
            ? value as IObservableAsync<T>
            : null;
    }
}
