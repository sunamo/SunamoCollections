namespace SunamoCollections._sunamo;

internal class SHSplit
{
    internal static List<string> SplitNone(string text, params string[] delimiters)
    {
        return text.Split(delimiters, StringSplitOptions.None).ToList();
    }

    internal static List<string> Split(string text, params string[] delimiters)
    {
        return text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}