using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Decks;
using OpenCards.Collections.Hands;

namespace OpenCards.Durak.Dealers;

public static class Dealer
{
    public static IEnumerable<SuitRankCard> DealCards(IDeck<SuitRankCard> deck, IReadOnlyHand<SuitRankCard> hand, int maxCardsInHand)
    {
        if (CanDeal(deck, hand, maxCardsInHand) is false)
        {
            yield break;
        }

        int cardsNeed = CardsNeed(hand, maxCardsInHand);

        for (int i = 0; i < cardsNeed; i++)
        {
            if (deck.IsEmpty)
            {
                yield break;
            }

            yield return deck.Draw()!;
        }
    }
    public static SuitRankCard? DealOneCard(IDeck<SuitRankCard> deck, IReadOnlyHand<SuitRankCard> hand, int maxCardsInHand)
    {
        if (CanDeal(deck, hand, maxCardsInHand) is false)
        {
            return null;
        }

        return deck.Draw();
    }

    public static bool CanDeal(IReadonlyDeck<SuitRankCard> deck, IReadOnlyHand<SuitRankCard> hand, int maxCardsInHand)
    {
        if (deck.IsEmpty)
        {
            return false;
        }

        int cardsDelta = CardsNeed(hand, maxCardsInHand);

        if (cardsDelta == 0)
        {
            return false;
        }

        return true;
    }

    public static int CardsNeed(IReadOnlyHand<SuitRankCard> hand, int maxCardsInHand) => Math.Max(0, maxCardsInHand - hand.Count);
    public static int CardsNeed(int hand, int maxCardsInHand) => Math.Max(0, maxCardsInHand - hand);
}