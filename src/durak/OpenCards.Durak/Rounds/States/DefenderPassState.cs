using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Boards;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Rounds.States;

public class DefenderPassState(IBoard<SuitRankCard> board, IPlayerQueue<IPlayer> queue, IPlayerStorage<IPlayer> storage) : IRoundState
{
    public void Execute(RoundSharedData shared)
    {
        shared.DefenderPass();

        var hand = queue.Attacker.Hand;

        if (board.CollisionsRank(hand))
        {
            queue.SetAttackerQueue();

            return;
        }

        shared.Over();

        queue.Defender.Add(board.All);

        board.Clear();

        IPlayer attacker = storage.GetNextFromActive(queue.Defender)!;

        IPlayer defender = storage.GetNextFromActive(queue.Defender, andSkip: 1)!;

        queue.SetAttackerQueue(attacker: attacker, defender: defender);
    }
}
