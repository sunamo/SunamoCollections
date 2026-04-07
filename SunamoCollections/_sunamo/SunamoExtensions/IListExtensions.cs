namespace SunamoCollections._sunamo.SunamoExtensions;

/// <summary>
/// Extension methods for IEnumerable providing FirstOrNull and Count operations.
/// </summary>
internal static class IListExtensions
{
    /// <summary>
    /// Returns the first element of the enumerable, or null if it is empty.
    /// </summary>
    /// <param name="enumerable">The enumerable to get the first element from.</param>
    /// <returns>The first element, or null.</returns>
    internal static object? FirstOrNull(this IEnumerable enumerable)
    {
        foreach (var item in enumerable) return item;
        return null;
    }

    /// <summary>
    /// Counts the number of elements in the enumerable by iterating through all elements.
    /// </summary>
    /// <param name="enumerable">The enumerable to count.</param>
    /// <returns>The number of elements.</returns>
    internal static int Count(this IEnumerable enumerable)
    {
        var count = 0;
        foreach (var item in enumerable) count++;
        return count;
    }
}
