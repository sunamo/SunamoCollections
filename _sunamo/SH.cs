namespace SunamoCollections._sunamo;

internal class SH
{

    internal static string TrimEnd(string name, string ext)
    {
        while (name.EndsWith(ext)) return name.Substring(0, name.Length - ext.Length);
        return name;
    }

    internal static string NullToStringOrDefault(object n)
    {
        return n == null ? " " + Consts.nulled : AllStrings.space + n;
    }

    internal static bool MatchWildcard(string name, string mask)
    {
        return IsMatchRegex(name, mask, AllChars.q, AllChars.asterisk);
    }

    public static void TrimWhiteSpaceRowFromEnd(List<string> s)
    {
        for (int i = s.Count - 1; i >= 0; i--)
        {
            if (!string.IsNullOrWhiteSpace(s[i]))
            {
                break;
            }
            s.RemoveAt(i);
        }
    }

    private static bool IsMatchRegex(string str, string pat, char singleWildcard, char multipleWildcard)
    {
        // If I compared .vs with .vs, return false before
        if (str == pat)
        {
            return true;
        }
        string escapedSingle = Regex.Escape(new string(singleWildcard, 1));
        string escapedMultiple = Regex.Escape(new string(multipleWildcard, 1));
        pat = Regex.Escape(pat);
        pat = pat.Replace(escapedSingle, AllStrings.dot);
        pat = "^" + pat.Replace(escapedMultiple, ".*") + "$";
        Regex reg = new Regex(pat);
        return reg.IsMatch(str);
    }
    internal static List<string> SplitMore(string s, params string[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }




    internal static string JoinNL(List<string> l)
    {
        StringBuilder sb = new();
        foreach (var item in l) sb.AppendLine(item);
        var r = string.Empty;
        r = sb.ToString();
        return r;
    }
    internal static List<string> SplitCharMore(string s, params char[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    internal static List<string> SplitNone(string text, params string[] deli)
    {
        return text.Split(deli, StringSplitOptions.None).ToList();
    }

}