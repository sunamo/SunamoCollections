namespace SunamoCollections._sunamo;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal class SHParts
{
    internal static string RemoveAfterFirstFunc(string text, Func<char, bool> predicate, params char[] canBe)
    {
        text = text.Trim();
        for (var i = 0; i < text.Length; i++)
            if (predicate(text[i]))
            {
                if (canBe.Contains(text[i])) continue;
                return text.Substring(0, i);
            }

        return text;
    }
}