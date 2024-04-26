using OpenCards.States;

namespace OpenCards.Durak.StateMachines;

public class StateContainer(IEnumerable<IState> states) : IStateContainer
{
    private readonly Dictionary<Type, IState> states = states.ToDictionary(keySelector: state => state.GetType());

    public T Get<T>() where T : class, IState
    {
        Type type = typeof(T);

        return (states[type] as T)!;
    }
}
