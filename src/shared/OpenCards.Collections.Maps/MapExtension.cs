namespace OpenCards.Collections.Maps;

public static class MapExtension
{
    public static T1 Get<T1, T2>(this IMap<T1, T2> map, T2 item)
        where T1 : notnull
        where T2 : notnull
        => map.Reverse[item];
    public static T2 Get<T1, T2>(this IMap<T1, T2> map, T1 item)
        where T1 : notnull
        where T2 : notnull
        => map.Forward[item];
}