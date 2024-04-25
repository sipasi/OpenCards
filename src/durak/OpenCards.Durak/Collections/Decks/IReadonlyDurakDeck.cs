using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Decks;

namespace OpenCards.Durak.Collections.Decks;

public interface IReadonlyDurakDeck : IReadonlyDeck<SuitRankCard>
{
    SuitRankCard Trump { get; }
}
