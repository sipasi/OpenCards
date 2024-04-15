using System.Collections;

using OpenCards.Shared.Collections.Extensions;

namespace OpenCards.Collections.Indexes;

public sealed class DecrementalIndexes : IIndexCollection
{
    private readonly int[] array;

    private int size;

    public int Count => size;
    public int Capacity => array.Length;
    public bool IsEmpty => Count == 0;

    public DecrementalIndexes(int count)
    {
        array = new int[count];

        Fill();

        ResetIndex();
    }

    public int Next()
    {
        int next = --size;

        return array[next];
    }

    public int Peek(int offset = 0)
    {
        int index = size - 1 + offset * -1;

        return array[index];
    }
    public int PeekReverse() => array[0];

    public void Fill() => array.FillNubers();

    public void Randomize(int times) => array.Randomize(from: 0, to: size, times);
    public void Randomize(int from, int times) => array.Randomize(from: from, to: size, times);

    public void ResetIndex() => size = array.Length;

    IEnumerator<int> IEnumerable<int>.GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return array[i];
        }
    }
    IEnumerator IEnumerable.GetEnumerator()
    {
        for (int i = 0; i < size; i++)
        {
            yield return array[i];
        }
    }
}