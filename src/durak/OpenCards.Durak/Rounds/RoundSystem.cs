using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;
using OpenCards.Durak.Movements;
using OpenCards.Durak.Movements.Results;
using OpenCards.Durak.Players;
using OpenCards.Durak.Rounds.Results;

namespace OpenCards.Durak.Rounds;

public class RoundSystem(IPlayerMovementFactory movementFactory, IPlayerQueue<IPlayer> queue, IPlayerStorage<IPlayer> storage, IReadonlyDurakDeck deck, IBoard<SuitRankCard> board) : IRoundSystem
{
    private readonly List<IRound> rounds = [];

    private IRound current = new NotInitRound();

    public void NewRound()
    {
        current = new Round(movementFactory, queue, storage, deck, board);

        rounds.Add(current);
    }

    public async ValueTask<IRoundResult> Execute()
    {
        if (current.Data.IsOver)
        {
            return new RoundCompleted();
        }

        IPlayerActionResult moveResult = await current.Execute();

        return new RoundExecuted(moveResult);
    }
}

file class NotInitRound : IRound
{
    public IRoundSharedData Data { get; } = new RoundSharedData();

    public ValueTask<IPlayerActionResult> Execute()
    {
        throw new NotImplementedException("The first round needs to be initiated with IRoundSystem.NewRound");
    }
}
