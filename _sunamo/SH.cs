namespace SunamoCollections;

//namespace SunamoCollections._sunamo;

internal class SH
{
    public static List<string> Split(string s, params string[] dot)
    {
        return s.Split(dot, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    //    internal static Func<string, string, bool> MatchWildcard;
    //    internal static Func<string, List<string>> GetLines;
    //    internal static Func<string, bool, string> GetFirstWord;
    //    internal static Func<string, Object[], string> Format2;
    //    internal static Func<string, Func<char, bool>, Char[], string> RemoveAfterFirstFunc;
    //    internal static Func<string, string> TextWithoutDiacritic;
    //    internal static Func<char, IList, string> JoinChar;
    //    internal static Func<string, List<string>, ContainsCompareMethod, bool> ContainsAll;
    //    internal static Func<string, string, bool, bool> StartingWith;
    //    internal static Func<string, (bool, string)> IsNegationTuple;

    //    internal static Func<string, string, string, string> Replace;
    //    internal static Func<string, string, string> PostfixIfNotEmpty;
    //    internal static Func<List<string>, string> JoinNL;
    //    internal static Func<string, bool> ContainsDiacritic;
    //    internal static Func<string, string> FirstCharUpper;
    //    internal static Func<string, string> ReplaceWhiteSpacesWithoutSpaces;
    //    internal static Func<string, string> ReplaceAllDoubleSpaceToSingle;
    //    internal static Func<string, string, SearchStrategy, bool> Contains;
}
