using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Rounds.States;

public class AttackerMoveState(SuitRankCard move, IBoard<SuitRankCard> board, IPlayerQueue<IPlayer> queue) : IRoundState
{
    public void Execute(RoundSharedData shared)
    {
        queue.Current.Remove(move);

        board.AddToAttacks(move);

        if (shared.IsDefenderPassed)
        {
            return;
        }

        queue.SetDefenderQueue();
    }
}
