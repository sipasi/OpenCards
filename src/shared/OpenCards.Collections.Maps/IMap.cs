namespace OpenCards.Collections.Maps;

public interface IMap<T1, T2>
    where T1 : notnull
    where T2 : notnull
{
    IReadonlyIndexer<T1, T2> Forward { get; }
    IReadonlyIndexer<T2, T1> Reverse { get; }
}