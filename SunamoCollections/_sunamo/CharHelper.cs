namespace SunamoCollections._sunamo;

/// <summary>
/// Helper class for character classification.
/// </summary>
internal class CharHelper
{
    internal static bool IsSpecial(char character)
    {
        SpecialCharsService specialChars = new();
        var isSpecial = specialChars.SpecialChars.Contains(character);
        if (!isSpecial) isSpecial = specialChars.SpecialCharsExtended.Contains(character);
        return isSpecial;
    }
}
