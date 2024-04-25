using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Hands;

namespace OpenCards.Durak.Players;

public class Player(int id, string name, MoveType moveType, IHand<SuitRankCard> hand) : IPlayer
{
    public int Id => id;
    public string Name => name;
    public MoveType MoveType => moveType;
    public IReadOnlyHand<SuitRankCard> Hand => hand;

    public void Add(SuitRankCard card) => hand.Add(card);
    public void Add(IEnumerable<SuitRankCard> cards) => hand.Add(cards);
    public void Remove(SuitRankCard card) => hand.Remove(card);
}
