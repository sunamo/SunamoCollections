
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections._sunamo;
internal class SH
{



    internal static bool MatchWildcard(string name, string mask)
    {
        return IsMatchRegex(name, mask, '?', '*');
    }


    private static bool IsMatchRegex(string input, string pattern, char singleWildcard, char multipleWildcard)
    {
        // If I compared .vs with .vs, return false before
        if (input == pattern)
        {
            return true;
        }
        string escapedSingle = Regex.Escape(new string(singleWildcard, 1));
        string escapedMultiple = Regex.Escape(new string(multipleWildcard, 1));
        pattern = Regex.Escape(pattern);
        pattern = pattern.Replace(escapedSingle, ".");
        pattern = "^" + pattern.Replace(escapedMultiple, ".*") + "$";
        Regex reg = new Regex(pattern);
        return reg.IsMatch(input);
    }






}
