namespace SunamoCollections._sunamo;

/// <summary>
/// String helper for extracting parts of strings.
/// </summary>
internal class SHParts
{
    /// <summary>
    /// Removes all characters after the first character matching the predicate (excluding allowed characters).
    /// </summary>
    /// <param name="text">The text to process.</param>
    /// <param name="predicate">The predicate to test each character.</param>
    /// <param name="canBe">Characters that are allowed even if they match the predicate.</param>
    /// <returns>The text truncated before the first matching character.</returns>
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
