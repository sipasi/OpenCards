using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Decks;
using OpenCards.Collections.Players;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Dealers;

public class CardDealer(IDeck<SuitRankCard> deck, IReadonlyPlayerQueue<IPlayer> queue, IReadonlyPlayerStorage<IPlayer> storage) : ICardDealer
{
    public DealResult DealCards()
    {
        List<DealResult.Info> list = new(capacity: storage.Active.Count);

        foreach (IPlayer player in storage.Active)
        {
            IEnumerable<SuitRankCard> cards = Dealer.DealCards(deck, player.Hand, maxCardsInHand: 6);

            player.Add(cards);

            list.Add(new(player, cards));
        }

        return new DealResult(list);
    }
}
