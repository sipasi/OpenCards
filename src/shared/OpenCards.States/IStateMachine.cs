namespace OpenCards.States;

public interface IStateMachine
{
    ValueTask Execute();
}