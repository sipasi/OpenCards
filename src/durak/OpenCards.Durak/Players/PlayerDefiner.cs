using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Extensions;
using OpenCards.Collections.Players;
using OpenCards.Durak.Collections.Decks;

namespace OpenCards.Durak.Players;

public class PlayerDefiner(IReadonlyDurakDeck deck, IPlayerQueue<IPlayer> queue, IReadonlyPlayerStorage<IPlayer> storage) : IPlayerDefiner
{
    public void SetFirstPlayer()
    {
        IPlayer attaker = GetWithSmallestTrump(ifNull: storage.Active.First()!);

        queue.SetAttackerQueue(attaker, defender: storage.GetNextFromActive(attaker)!);
    }

    public IPlayer GetWithSmallestTrump(IPlayer ifNull)
    {
        (IPlayer player, SuitRankCard data)? first = null;

        SuitRankCard trump = deck.Trump;

        foreach (var player in storage.Active)
        {
            SuitRankCard? result = player.Hand.MinRankBy(trump.Suit);

            if (result == null)
            {
                continue;
            }

            if (first != null && result.Rank > first?.data.Rank)
            {
                continue;
            }

            first = (player, result);
        }

        return first?.player ?? ifNull;
    }
}
