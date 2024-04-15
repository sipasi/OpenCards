namespace OpenCards.Shared.Collections.Extensions;

public static class ArrayExtension
{
    public static T[] Randomize<T>(this T[] array, int from, int to, int times = 1)
    {
        return (T[])IListTool.Randomize(array, from, to, times);
    }
    public static T[] Randomize<T>(this T[] array, int times = 1)
    {
        return (T[])IListTool.Randomize(array, from: 0, to: array.Length, times);
    }


    public static int[] FillNubers(this int[] array, int count)
    {
        for (int i = 0; i < count; i++)
        {
            array[i] = i;
        }

        return array;
    }
    public static int[] FillNubers(this int[] array)
    {
        return array.FillNubers(count: array.Length);
    }
}