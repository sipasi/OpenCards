using OpenCards.Cards.SuitsRanks;

namespace OpenCards.Durak.Players;

public interface IPlayer : IReadonlyPlayer
{
    void Add(SuitRankCard card);
    void Add(IEnumerable<SuitRankCard> cards);
    void Remove(SuitRankCard card);
}
