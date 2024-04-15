namespace OpenCards.Collections.Extensions;

public static class ListExtension
{
    public static bool IsEmpty<T>(this IReadOnlyList<T> list) => list.Count == default;
    public static bool IsNotEmpty<T>(this IReadOnlyList<T> list) => list.Count > 0;

    public static T? First<T>(this IReadOnlyList<T> list) => list.IsEmpty() ? default : list[0];
    public static T? Last<T>(this IReadOnlyList<T> list) => list.IsEmpty() ? default : list[list.Count - 1];

    public static int IndexOf<T>(this IReadOnlyList<T> list, T value)
    {
        int length = list.Count;

        var comparer = EqualityComparer<T>.Default;

        for (int i = 0; i < length; i++)
        {
            T item = list[i];

            if (comparer.Equals(value, item))
            {
                return i;
            }
        }

        return -1;
    }

    public static T? GetNextFrom<T>(this IReadOnlyList<T> list, T value, int andSkip = 0)
    {
        if (list is null or { Count: 0 })
        {
            return default;
        }

        int index = list.IndexOf(value);

        int next = (index + 1 + andSkip) % list.Count;

        return list[next];
    }
}