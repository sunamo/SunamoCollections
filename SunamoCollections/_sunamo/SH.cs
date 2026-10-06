namespace SunamoCollections._sunamo;

internal class SH
{
    internal static bool MatchWildcard(string name, string mask) =>
        IsMatchRegex(name, mask, '?', '*');

    private static bool IsMatchRegex(string input, string mask, char singleWildcard, char multipleWildcard)
    {
        if (input == mask)
            return true;

        string escapedSingle = Regex.Escape(new string(singleWildcard, 1));
        string escapedMultiple = Regex.Escape(new string(multipleWildcard, 1));
        mask = Regex.Escape(mask);
        mask = mask.Replace(escapedSingle, ".");
        mask = "^" + mask.Replace(escapedMultiple, ".*") + "$";
        var regex = new Regex(mask);
        return regex.IsMatch(input);
    }
}
