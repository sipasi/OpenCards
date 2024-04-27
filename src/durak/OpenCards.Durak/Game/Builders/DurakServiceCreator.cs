using Microsoft.Extensions.DependencyInjection;

using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Decks;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Dealers;
using OpenCards.Durak.Elimenators;
using OpenCards.Durak.Game.States;
using OpenCards.Durak.Movements;
using OpenCards.Durak.Players;
using OpenCards.Durak.Rounds;
using OpenCards.Durak.StateMachines;
using OpenCards.Observables;
using OpenCards.States;

namespace OpenCards.Durak.Game.Builders;

internal class DurakServiceCreator
{
    public required IDurakDeck Deck { get; init; }
    public required IBoard<SuitRankCard> Board { get; init; }
    public required IPlayerStorage<IPlayer> PlayerStorage { get; init; }
    public required IPlayerQueue<IPlayer> PlayerQueue { get; init; }
    public required IPlayerMovementFactory MovementFactory { get; init; }
    public required IObservableContainer ObservableContainer { get; init; }

    public ServiceProvider Create()
    {
        ServiceCollection services = new();

        SetCollections(services);

        SetGameplayEntities(services);

        SetStates(services);

        return services
              .AddSingleton<IReadonlyGameState, ReadonlyGameState>()

              .AddSingleton(ObservableContainer)

              .BuildServiceProvider();
    }

    private void SetCollections(ServiceCollection services) => services
        .AddSingleton<IDeck<SuitRankCard>>(Deck)
        .AddSingleton<IReadonlyDeck<SuitRankCard>>(Deck)
        .AddSingleton(Deck)
        .AddSingleton<IReadonlyDurakDeck>(Deck)

        .AddSingleton(Board)
        .AddSingleton<IReadonlyBoard<SuitRankCard>>(Board)

        .AddSingleton(PlayerStorage)
        .AddSingleton<IPlayerStorage<IReadonlyPlayer>>(PlayerStorage)
        .AddSingleton<IReadonlyPlayerStorage<IPlayer>>(PlayerStorage)
        .AddSingleton<IReadonlyPlayerStorage<IReadonlyPlayer>>(PlayerStorage)

        .AddSingleton(PlayerQueue)
        .AddSingleton<IReadonlyPlayerQueue<IPlayer>>(PlayerQueue)
        .AddSingleton<IReadonlyPlayerQueue<IReadonlyPlayer>>(PlayerQueue);

    private static void SetStates(ServiceCollection services) => services
        .AddSingleton<IStateMachine, DurakStateMachine>()
        .AddSingleton<IStateContainer, StateContainer>()

        .AddSingleton<IState, GameStartState>()
        .AddSingleton<IState, GameEndState>()
        .AddSingleton<IState, RoundStartState>()
        .AddSingleton<IState, RoundExecuteState>()
        .AddSingleton<IState, RoundEndState>();
    private void SetGameplayEntities(ServiceCollection services) => services
        .AddSingleton<IDeckShuffler, DeckShuffler>()
        .AddSingleton<ICardDealer, CardDealer>()
        .AddSingleton<IPlayerDefiner, PlayerDefiner>()
        .AddSingleton<IPlayerElimenator, PlayerElimenator>()
        .AddSingleton<IRoundSystem, RoundSystem>()
        .AddSingleton(MovementFactory);
}