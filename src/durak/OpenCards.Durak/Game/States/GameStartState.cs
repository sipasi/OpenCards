using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Dealers;
using OpenCards.Durak.Events;
using OpenCards.Durak.Game;
using OpenCards.Durak.Players;
using OpenCards.Observables;
using OpenCards.States;

namespace OpenCards.Durak.Game.States;

public class GameStartState(
    IDurakDeck deck,
    IBoard<SuitRankCard> board,
    IPlayerStorage<IPlayer> storage,
    IPlayerDefiner playerDefiner,
    ICardDealer dealer,
    IObservableContainer observables) : IStateAsync
{
    public async ValueTask<IStateAsync> Execute(IReadonlyGameState info, IStateContainer container)
    {
        storage.Restore();
        board.Clear();
        deck.Reset();

        deck.Shuffle();

        dealer.DealCards();

        playerDefiner.SetFirstPlayer();

        await observables.NotifyAsync<GameStartEvent>(new(info));

        return container.Get<RoundStartState>();
    }
}
