using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Elimenators;
using OpenCards.Durak.Events;
using OpenCards.Durak.Players;
using OpenCards.Observables;
using OpenCards.States;

namespace OpenCards.Durak.Game.States;

public class RoundEndState(
    IDurakDeck deck,
    IPlayerStorage<IPlayer> storage,
    IPlayerElimenator elimenator,
    IObservableContainer observables) : IStateAsync
{
    public async ValueTask<IStateAsync> Execute(IReadonlyGameState info, IStateContainer container)
    {
        elimenator.EliminateEmpty();

        await observables.NotifyAsync<RoundEndEvent>(new(info));

        if (IsGameOver())
        {
            return container.Get<GameEndState>();
        }

        return container.Get<RoundStartState>();
    }

    private bool IsGameOver()
    {
        return deck.IsEmpty && storage.Active.Count < 2;
    }
}
