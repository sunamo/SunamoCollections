namespace SunamoCollections;

/// <summary>
/// Represents the CA new type.
/// </summary>
public class CANew
{
    /// <summary>
    /// Contains any from array.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <param name="array">The array.</param>
    /// <returns>The contains any from array result.</returns>
    public static bool ContainsAnyFromArray(string text, string[] array)
    {
        foreach (var item in array)
            if (text.Contains(item))
                return true;

        return false;
    }
}
