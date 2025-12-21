namespace SunamoCollections._sunamo;

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