namespace SunamoCollections._sunamo;

/// <summary>
/// String helper class providing wildcard matching functionality.
/// </summary>
internal class SH
{
    /// <summary>
    /// Checks whether the name matches the wildcard mask pattern.
    /// </summary>
    /// <param name="name">The string to test.</param>
    /// <param name="mask">The wildcard pattern (supports ? and *).</param>
    /// <returns>True if the name matches the mask.</returns>
    internal static bool MatchWildcard(string name, string mask)
    {
        return IsMatchRegex(name, mask, '?', '*');
    }

    /// <summary>
    /// Checks whether the input matches a wildcard mask by converting it to a regex pattern.
    /// </summary>
    private static bool IsMatchRegex(string input, string mask, char singleWildcard, char multipleWildcard)
    {
        if (input == mask)
        {
            return true;
        }
        string escapedSingle = Regex.Escape(new string(singleWildcard, 1));
        string escapedMultiple = Regex.Escape(new string(multipleWildcard, 1));
        mask = Regex.Escape(mask);
        mask = mask.Replace(escapedSingle, ".");
        mask = "^" + mask.Replace(escapedMultiple, ".*") + "$";
        Regex regex = new Regex(mask);
        return regex.IsMatch(input);
    }
}
