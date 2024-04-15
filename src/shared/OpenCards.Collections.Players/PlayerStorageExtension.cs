using OpenCards.Collections.Extensions;

namespace OpenCards.Collections.Players;

public static class PlayerStorageExtension
{
    public static T? GetNextFromActive<T>(this IReadonlyPlayerStorage<T> storage, T player, int andSkip = 0) => storage.Active.GetNextFrom(player, andSkip);

    public static bool IsActive<T>(this IReadonlyPlayerStorage<T> storage, T player) => storage.Active.Contains(player);
}