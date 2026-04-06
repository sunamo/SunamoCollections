namespace SunamoCollections;

/// <summary>
/// Facade for newer collection utility methods.
/// </summary>
public class CANew
{
    /// <summary>
    /// Checks if the text contains any element from the array.
    /// </summary>
    /// <param name="text">The text to search in.</param>
    /// <param name="array">The array of strings to look for.</param>
    /// <returns>True if the text contains any of the array elements.</returns>
    public static bool ContainsAnyFromArray(string text, string[] array)
    {
        foreach (var item in array)
            if (text.Contains(item))
                return true;

        return false;
    }
}
