// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollections._sunamo;

internal class CharHelper
{
    internal static bool IsSpecial(char character)
    {
        SpecialCharsService specialChars = new();
        var value = specialChars.specialChars.Contains(character);
        if (!value) value = specialChars.specialChars2.Contains(character);
        return value;
    }
}