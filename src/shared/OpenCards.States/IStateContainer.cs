namespace OpenCards.States;

public interface IStateContainer
{
    T Get<T>() where T : class, IState;
}
