using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Decks;

namespace OpenCards.Durak.Collections.Decks;

public interface IDurakDeck : IDeck<SuitRankCard>, IReadonlyDurakDeck;
