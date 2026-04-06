namespace SunamoCollections;

/// <summary>
/// String list conversion methods for the CA utility class.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Converts a params string array to a List of strings.
    /// This method is intentionally kept with params because it is widely used.
    /// </summary>
    /// <param name="array">The strings to convert.</param>
    /// <returns>A list of strings.</returns>
    [ObjectParamsAllowed]
    public static List<string> ToListString(params string[] array)
    {
        return new List<string>(array);
    }

    /// <summary>
    /// Converts a params string array to a List of strings.
    /// </summary>
    /// <param name="array">The strings to convert.</param>
    /// <returns>A list of strings.</returns>
    public static List<string> ToListMoreString(params string[] array)
    {
        return array.ToList();
    }
}
