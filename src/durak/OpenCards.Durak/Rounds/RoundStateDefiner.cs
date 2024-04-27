using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Movements.Results;
using OpenCards.Durak.Players;
using OpenCards.Durak.Rounds.States;

namespace OpenCards.Durak.Rounds;

public class RoundStateDefiner(IPlayerQueue<IPlayer> queue, IPlayerStorage<IPlayer> storage, IBoard<SuitRankCard> board)
{
    public IRoundState GetState(RoundSharedData shared, IPlayerActionResult move)
    {
        List<IRoundState> states = new(capacity: 2);

        if (move.Passed())
        {
            IRoundState state = GetPassState();

            states.Add(state);
        }
        if (move.Moved(out SuitRankCard? card))
        {
            IRoundState state = GetMoveState(card);

            states.Add(state);
        }

        if (shared.IsOver)
        {
            IRoundState state = new RoundEndState(board, queue, storage);

            states.Add(state);
        }

        return new RoundStates(states);
    }

    private IRoundState GetPassState() => queue.IsAttackerQueue
        ? new AttackerPassState(board, queue, storage)
        : new DefenderPassState(board, queue, storage);

    private IRoundState GetMoveState(SuitRankCard card) => queue.IsAttackerQueue
        ? new AttackerMoveState(card, board, queue)
        : new DefenderMoveState(card, board, queue);
}
