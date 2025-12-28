// variables names: ok
namespace SunamoCollections._sunamo;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
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