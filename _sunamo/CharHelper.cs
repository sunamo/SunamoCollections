namespace SunamoCollections._sunamo;
internal class CharHelper
{
    public static bool IsSpecial(char c)
    {
        SpecialCharsService specialChars = new();
        var v = specialChars.specialChars.Contains(c);
        if (!v) v = specialChars.specialChars2.Contains(c);
        return v;
    }
}
