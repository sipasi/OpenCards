using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Boards;
using OpenCards.Collections.Players;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Rounds.States;

public class AttackerPassState(IBoard<SuitRankCard> board, IPlayerQueue<IPlayer> queue, IPlayerStorage<IPlayer> storage) : IRoundState
{
    public void Execute(RoundSharedData shared)
    {
        shared.Over();

        IPlayer attacker = queue.Defender;

        IPlayer defender = storage.GetNextFromActive(queue.Defender)!;

        board.Clear();

        queue.SetAttackerQueue(attacker: attacker, defender: defender);
    }
}
