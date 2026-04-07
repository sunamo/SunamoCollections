namespace SunamoCollections._sunamo;

/// <summary>
/// Helper class for character classification.
/// </summary>
internal class CharHelper
{
    /// <summary>
    /// Determines whether the specified character is a special character.
    /// </summary>
    /// <param name="character">The character to check.</param>
    /// <returns>True if the character is a special character.</returns>
    internal static bool IsSpecial(char character)
    {
        SpecialCharsService specialChars = new();
        var isSpecial = specialChars.SpecialChars.Contains(character);
        if (!isSpecial) isSpecial = specialChars.SpecialCharsExtended.Contains(character);
        return isSpecial;
    }
}
