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
    /// To list more string.
    /// </summary>
    /// <param name="array">The array.</param>
    /// <returns>The to list more string result.</returns>
    public static List<string> ToListMoreString(params string[] array)
    {
        return array.ToList();
    }
}
