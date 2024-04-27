using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Rounds.States;

public class RoundEndState(IBoard<SuitRankCard> board, IPlayerQueue<IPlayer> queue, IPlayerStorage<IPlayer> storage) : IRoundState
{
    public void Execute(RoundSharedData shared)
    {
        shared.Over();

        IPlayer attacker = shared.IsDefenderPassed
            ? storage.GetNextFromActive(queue.Defender)!
            : queue.Defender;

        IPlayer defender = storage.GetNextFromActive(queue.Defender, andSkip: shared.IsDefenderPassed ? 1 : 0)!;

        if (shared.IsDefenderPassed)
        {
            queue.Defender.Add(board.All);
        }

        board.Clear();

        queue.SetAttackerQueue(attacker: attacker, defender: defender);
    }
}