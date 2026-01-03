namespace SunamoCollections._sunamo;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
internal class SH
{



    internal static bool MatchWildcard(string name, string mask)
    {
        return IsMatchRegex(name, mask, '?', '*');
    }


    private static bool IsMatchRegex(string input, string mask, char singleWildcard, char multipleWildcard)
    {
        // If I compared .vs with .vs, return false before
        if (input == mask)
        {
            return true;
        }
        string escapedSingle = Regex.Escape(new string(singleWildcard, 1));
        string escapedMultiple = Regex.Escape(new string(multipleWildcard, 1));
        mask = Regex.Escape(mask);
        mask = mask.Replace(escapedSingle, ".");
        mask = "^" + mask.Replace(escapedMultiple, ".*") + "$";
        Regex reg = new Regex(mask);
        return reg.IsMatch(input);
    }






}