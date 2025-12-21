namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    /// <summary>
    ///     Direct edit input collection
    /// </summary>
    /// <param name = "prefix"></param>
    /// <param name = "items"></param>
    public static List<string> Prepend(string prefix, List<string> items)
    {
        for (var i = 0; i < items.Count; i++)
            if (!items[i].StartsWith(prefix))
                items[i] = prefix + items[i];
        return items;
    }

    /// <summary>
    ///     Direct edit input collection
    /// </summary>
    /// <param name = "prefix"></param>
    /// <param name = "items"></param>
    public static List<string> Prepend(string prefix, string[] items)
    {
        return Prepend(prefix, items.ToList());
    }

    public static string FindOutLongestItem(List<string> items, params string[] delimiters)
    {
        var longestLength = 0;
        var longest = "";
        foreach (var item in items)
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
        foreach (var currentList in lists)
            if (currentList.Count % 2 == 1)
                return true;
        return false;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "items"></param>
    public static List<string> ToLower(List<string> items)
    {
        for (var i = 0; i < items.Count; i++)
            items[i] = items[i].ToLower();
        return items;
    }

    /// <summary>
    ///     Direct editr
    /// </summary>
    /// <param name = "items"></param>
    /// <param name = "pattern"></param>
    /// <param name = "wildcard"></param>
    public static void RemoveWhichContains(List<string> items, string pattern, bool wildcard, Func<string, string, bool> wildcardIsMatch)
    {
        if (wildcard)
        {
            //pattern = SH.WrapWith(pattern, '*');
            for (var i = items.Count - 1; i >= 0; i--)
                if (wildcardIsMatch(items[i], pattern))
                    items.RemoveAt(i);
        }
        else
        {
            for (var i = items.Count - 1; i >= 0; i--)
                if (items[i].Contains(pattern))
                    items.RemoveAt(i);
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
            var enumerable = first as IList<object>;
            if (enumerable != null)
                return enumerable;
            return ToListMoreObject(first);
        }

        return collection as IList<object>;
    }

    /// <summary>
    ///     Direct edit collection
    ///     Na rozdíl od metody RemoveStringsEmpty2 NEtrimuje před porovnáním
    /// </summary>
    /// <param name = "items"></param>
    public static List<string> RemoveStringsEmpty(List<string> items)
    {
        for (var i = items.Count - 1; i >= 0; i--)
            if (items[i] == string.Empty)
                items.RemoveAt(i);
        return items;
    }

    public static List<string> PostfixIfNotEnding(string prefix, List<string> items)
    {
        for (var i = 0; i < items.Count; i++)
            items[i] = prefix + items[i];
        return items;
    }

    public static List<int> ParseInt(string text, string delimiter)
    {
        var parts = SHSplit.Split(text, delimiter);
        var numbers = new List<int>(parts.Count);
        foreach (var item in parts)
            numbers.Add(int.Parse(item));
        //return BTS.CastCollectionStringToInt(parts);
        return numbers;
    }

    public static List<List<string>> Split(List<string> lines, string delimiter)
    {
        var result = new List<List<string>>();
        var currentGroup = new List<string>();
        foreach (var item in lines)
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
            var trimmedLine = item.Trim();
            if (trimmedLine.EndsWith(":"))
                stringBuilder.AppendLine(item);
            else if (trimmedLine == "")
                stringBuilder.AppendLine(trimmedLine);
            else
            {
                WhitespaceCharService whiteSpaceChars = new WhitespaceCharService();
                stringBuilder.AppendLine(trimmedLine.Split(whiteSpaceChars.WhiteSpaceChars.ToArray())[0]);
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
    public static void KeepOnlyWordsToFirstSpecialChars(List<string> items)
    {
        //ThrowEx.NotImplementedMethod();
        for (int i = 0; i < items.Count; i++)
        {
            items[i] = SHParts.RemoveAfterFirstFunc(items[i], CharHelper.IsSpecial, []);
        }
    }

    public static List<string> LinesIndexes(List<string> lines, int from, int to, bool indexedFrom1)
    {
        if (indexedFrom1)
        {
            from--;
            to--;
        }

        var selectedLines = new List<string>();
        for (var i = from; i < to + 1; i++)
            selectedLines.Add(lines[i]);
        return selectedLines;
    }

    // In order to convert any 2d array to jagged one
    // let's use a generic implementation
    public static List<List<int>> ToJagged(bool[, ] matrix)
    {
        var result = new List<List<int>>();
        for (var i = 0; i < matrix.GetLength(0); i++)
        {
            var row = new List<int>();
            for (var columnIndex = 0; columnIndex < matrix.GetLength(1); columnIndex++)
                row.Add(matrix[i, columnIndex] ? 1 : 0);
            result.Add(row);
        }

        return result;
    }
}