using OpenCards.Collections.Extensions;

namespace OpenCards.Collections.Hands;

public static class HandExtentions
{
    public static bool InRange<T>(this IReadOnlyHand<T> hand, int index) => hand.IsNotEmpty() && index >= 0 && index < hand.Count;
}
