
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections;
public partial class CA
{
    /// <summary>
    ///     Direct edit input collection
    /// </summary>
    /// <param name = "value"></param>
    /// <param name = "list"></param>
    public static List<string> Prepend(string value, List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            if (!list[i].StartsWith(value))
                list[i] = value + list[i];
        return list;
    }

    /// <summary>
    ///     Direct edit input collection
    /// </summary>
    /// <param name = "value"></param>
    /// <param name = "array"></param>
    public static List<string> Prepend(string value, string[] array)
    {
        return Prepend(value, array.ToList());
    }

    public static string FindOutLongestItem(List<string> list, params string[] delimiters)
    {
        var longestLength = 0;
        var longest = "";
        foreach (var item in list)
        {
            var processedItem = item;
            if (delimiters.Length != 0)
                processedItem = SHSplit.Split(item, delimiters)[0].Trim();
            if (longestLength < processedItem.Length)
            {
                longest = processedItem;
                longestLength = processedItem.Length;
            }
        }

        return longest;
    }

    public static bool IsOdd(params List<int>[] lists)
    {
        foreach (var item in lists)
            if (item.Count % 2 == 1)
                return true;
        return false;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "words"></param>
    public static List<string> ToLower(List<string> words)
    {
        for (var i = 0; i < words.Count; i++)
            words[i] = words[i].ToLower();
        return words;
    }

    /// <summary>
    ///     Direct editr
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "item"></param>
    /// <param name = "wildcard"></param>
    public static void RemoveWhichContains(List<string> list, string item, bool wildcard, Func<string, string, bool> WildcardIsMatch)
    {
        if (wildcard)
        {
            //item = SH.WrapWith(item, '*');
            for (var i = list.Count - 1; i >= 0; i--)
                if (WildcardIsMatch(list[i], item))
                    list.RemoveAt(i);
        }
        else
        {
            for (var i = list.Count - 1; i >= 0; i--)
                if (list[i].Contains(item))
                    list.RemoveAt(i);
        }
    }

    ///// <summary>
    ///// Convert IList to List<string> Nothing more, nothing less
    ///// Must be private - to use only public in CA
    ///// bcoz Cast() not working
    ///// Dont make any Type checking - could be done before
    ///// </summary>
    //private static List<string> ToListString2(IList enumerable)
    //{
    //    return se.new List<string>2(enumerable);
    //}
    ///// <summary>
    ///// Just 3 cases of working:
    ///// IList<char> => string
    ///// IList<string> => List<string>
    ///// IList => List<string>
    ///// </summary>
    ///// <param name="enumerable"></param>
    //public static List<string> ToListString(IList enumerable2)
    //{
    //    return se.new List<string>(enumerable2);
    //}
    public static IList<object> OneElementCollectionToMulti(IList collection)
    {
        if (collection.Count() == 1)
        {
            var first = collection.FirstOrNull();
            var ien = first as IList<object>;
            if (ien != null)
                return ien;
            return ToListMoreObject(first);
        }

        return collection as IList<object>;
    }

    /// <summary>
    ///     Direct edit collection
    ///     Na rozdíl od metody RemoveStringsEmpty2 NEtrimuje před porovnáním
    /// </summary>
    /// <param name = "list"></param>
    public static List<string> RemoveStringsEmpty(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (list[i] == string.Empty)
                list.RemoveAt(i);
        return list;
    }

    public static List<string> PostfixIfNotEnding(string prefix, List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = prefix + list[i];
        return list;
    }

    public static List<int> ParseInt(string value, string delimiter)
    {
        var text = SHSplit.Split(value, delimiter);
        var count = new List<int>(text.Count);
        foreach (var item in text)
            count.Add(int.Parse(item));
        //return BTS.CastCollectionStringToInt(text);
        return count;
    }

    public static List<List<string>> Split(List<string> text, string delimiter)
    {
        var result = new List<List<string>>();
        var currentGroup = new List<string>();
        foreach (var item in text)
            if (item == delimiter)
            {
                result.Add(currentGroup);
                currentGroup.Clear();
            }

        return result;
    }

    public static string GetFirstWordOfList(string text)
    {
        var stringBuilder = new StringBuilder();
        var lines = text.Split(new[] { text.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.None).ToList(); //SHGetLines.GetLines(text);
        foreach (var item in lines)
        {
            var temp = item.Trim();
            if (temp.EndsWith(":"))
                stringBuilder.AppendLine(item);
            else if (temp == "")
                stringBuilder.AppendLine(temp);
            else
            {
                WhitespaceCharService whiteSpaceChars = new WhitespaceCharService();
                stringBuilder.AppendLine(temp.Split(whiteSpaceChars.WhiteSpaceChars.ToArray())[0]);
            }
        }

        return stringBuilder.ToString();
    }

    //public static object FirstOrNull(IList e)
    //{
    //    if (e == null)
    //    {
    //        return null;
    //    }
    //    //var tName = e.GetType().Name;
    //    //if (ThreadHelper.NeedDispatcher(tName))
    //    //{
    //    //    var result = CA.dFirstOrNull(e);
    //    //    return result;
    //    //}
    //    return e.FirstOrNull();
    //}
    public static void KeepOnlyWordsToFirstSpecialChars(List<string> list)
    {
        //ThrowEx.NotImplementedMethod();
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = SHParts.RemoveAfterFirstFunc(list[i], CharHelper.IsSpecial, []);
        }
    }

    public static List<string> LinesIndexes(List<string> lines, int from, int to, bool indexedFrom1)
    {
        if (indexedFrom1)
        {
            from--;
            to--;
        }

        var text = new List<string>();
        for (var i = from; i < to + 1; i++)
            text.Add(lines[i]);
        return text;
    }

    // In order to convert any 2d array to jagged one
    // let's use a generic implementation
    public static List<List<int>> ToJagged(bool[, ] value)
    {
        var result = new List<List<int>>();
        for (var i = 0; i < value.GetLength(0); i++)
        {
            var ca = new List<int>();
            for (var columnIndex = 0; columnIndex < value.GetLength(1); columnIndex++)
                ca.Add(value[i, columnIndex] ? 1 : 0);
            result.Add(ca);
        }

        return result;
    }
}
