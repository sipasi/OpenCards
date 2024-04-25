using OpenCards.Cards.SuitsRanks;
using OpenCards.Collections.Decks;
using OpenCards.Collections.Indexes;

namespace OpenCards.Durak.Collections.Decks;

public sealed class DurakDeck(IReadOnlyList<SuitRankCard> datas, IIndexCollection indexes) : Deck<SuitRankCard>(datas, indexes), IDurakDeck
{
    public SuitRankCard Trump { get; private set; } = null!;

    public DurakDeck(IReadOnlyList<SuitRankCard> datas) : this(datas, new DecrementalIndexes(datas.Count)) { }

    protected sealed override void OnShuffled(IReadOnlyList<SuitRankCard> datas, IReadonlyIndexCollection indexes)
    {
        int index = indexes.PeekReverse();

        Trump = datas[index];
    }
}
