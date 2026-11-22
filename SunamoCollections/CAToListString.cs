namespace SunamoCollections;

public partial class CA
{
    // This method is intentionally kept with params because it is widely used.
    /// <summary>
    /// To list string.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns>The to list string result.</returns>
    [ObjectParamsAllowed]
    public static List<string> ToListString(params string[] array)
    {
        return new List<string>(array);
    }

    /// <summary>
    /// Converts every item to its string form; a null item becomes an empty string.
    /// </summary>
    /// <param name="items">The items to convert.</param>
    /// <returns>The list of string forms of the items.</returns>
    public static List<string> ToListString(IEnumerable<object?> items)
    {
        var result = new List<string>();
        foreach (var item in items)
            result.Add(item?.ToString() ?? string.Empty);
        return result;
    }

    /// <summary>
    /// To list more string.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns>The to list more string result.</returns>
    public static List<string> ToListMoreString(params string[] array)
    {
        return array.ToList();
    }
}
