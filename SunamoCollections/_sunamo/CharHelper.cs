namespace SunamoCollections._sunamo;

internal class CharHelper
{
    internal static bool IsSpecial(char character)
    {
        SpecialCharsService SpecialChars = new();
        var value = SpecialChars.SpecialChars.Contains(character);
        if (!value) value = SpecialChars.SpecialCharsExtended.Contains(character);
        return value;
    }
}