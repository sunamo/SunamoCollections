namespace SunamoCollections._sunamo.SunamoExtensions;

/// <summary>
/// Extension methods for IEnumerable providing FirstOrNull and Count operations.
/// </summary>
internal static class IListExtensions
{
    internal static object? FirstOrNull(this IEnumerable enumerable)
    {
        foreach (var item in enumerable) return item;
        return null;
    }

    internal static int Count(this IEnumerable enumerable)
    {
        var count = 0;
        foreach (var item in enumerable) count++;
        return count;
    }
}
