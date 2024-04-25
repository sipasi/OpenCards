using OpenCards.Collections.Extensions;
using OpenCards.Collections.Players;
using OpenCards.Durak.Players;

namespace OpenCards.Durak.Elimenators;

public class PlayerElimenator(IPlayerStorage<IReadonlyPlayer> storage) : IPlayerElimenator
{
    public void EliminateEmpty() => storage.RemoveAll(static player => player.Hand.IsEmpty());
}
