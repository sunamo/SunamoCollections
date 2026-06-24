namespace SunamoCollections._sunamo;

internal class CharHelper
{
    internal static bool IsSpecial(char character)
    {
        SpecialCharsService specialChars = new();
        var isSpecial = specialChars.specialChars.Contains(character);
        if (!isSpecial) isSpecial = specialChars.specialChars2.Contains(character);
        return isSpecial;
    }
}
