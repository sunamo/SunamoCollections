namespace SunamoCollections._sunamo;

/// <summary>
/// String helper for splitting operations.
/// </summary>
internal class SHSplit
{
    /// <summary>
    /// Splits the text by delimiters without removing empty entries.
    /// </summary>
    /// <param name="text">The text to split.</param>
    /// <param name="delimiters">The delimiters to split by.</param>
    /// <returns>A list of split parts including empty entries.</returns>
    internal static List<string> SplitNone(string text, params string[] delimiters)
    {
        return text.Split(delimiters, StringSplitOptions.None).ToList();
    }

    /// <summary>
    /// Splits the text by delimiters, removing empty entries.
    /// </summary>
    /// <param name="text">The text to split.</param>
    /// <param name="delimiters">The delimiters to split by.</param>
    /// <returns>A list of non-empty split parts.</returns>
    internal static List<string> Split(string text, params string[] delimiters)
    {
        return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
