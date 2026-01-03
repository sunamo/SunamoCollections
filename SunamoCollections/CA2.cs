namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    /// <summary>
    ///     Overrides working only with string, not List
    ///     AnyElementEndsWith - string[]
    ///     EndsWith - IList&lt;string&gt;
    /// </summary>
    /// <param name = "text"></param>
    /// <param name = "suffixes"></param>
    /// <returns></returns>
    public static bool EndsWithAnyElement(string text, params string[] suffixes)
    {
        return EndsWithAnyElement(text, suffixes.ToList());
    }

    /// <summary>
    ///     Overrides working only with string, not List
    ///     Return whether A1 contains with any of A2
    /// </summary>
    /// <param name = "text"></param>
    /// <param name = "suffixes"></param>
    public static bool EndsWithAnyElement(string text, IList<string> suffixes)
    {
        foreach (var suffix in suffixes)
            if (text.EndsWith(suffix))
                return true;
        return false;
    }

    /// <summary>
    ///     AnyElementEndsWith - string[]
    ///     EndsWith - IList&lt;string&gt;
    /// </summary>
    /// <param name = "text"></param>
    /// <param name = "suffixes"></param>
    /// <returns></returns>
    public static bool EndsWith(string text, List<string> suffixes)
    {
        foreach (var suffix in suffixes)
            if (text.EndsWith(suffix))
                return true;
        return false;
    }

    public static List<string> Join(IEnumerable<object> enumerable)
    {
        var result = new List<string>();
        foreach (var item in enumerable)
        {
            result.AddRange(new List<string>([item.ToString()]));
        }

        return result;
    }

    public static string ReplaceAll(string text, List<string> what, string replacement)
    {
        foreach (var item in what)
            text = text.Replace(item, replacement);
        return text;
    }

    /// <summary>
    ///     Remove from A1 which exists in A2
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "itemsToRemove"></param>
    public static void RemoveWhichExists(IList<string> list, List<string> itemsToRemove)
    {
        var index = -1;
        foreach (var item in itemsToRemove)
        {
            index = list.IndexOf(item);
            if (index != -1)
                list.RemoveAt(index);
        }
    }

    /// <summary>
    ///     Return first of A2 which starts with  A1. Otherwise null
    ///     So, isnt finding occurences but find out something in A2 have right format.
    ///     Method with shifted parameters working for searching occurences
    /// </summary>
    /// <param name = "prefix"></param>
    /// <param name = "candidates"></param>
    public static string StartWith(string prefix, params string[] candidates)
    {
        return StartWith(prefix, candidates.ToList());
    }

    public static string StartWith(string prefix, IList<string> candidates)
    {
        int foundIndex;
        return StartWith(prefix, candidates, out foundIndex);
    }

    /// <summary>
    ///     Return first of A2 which starts with  A1. Otherwise null
    ///     So, isnt finding occurences but find out something in A2 have right format.
    ///     Method with shifted parameters working for searching occurences
    ///     Cant be use if A1 is shorter than A2 (text vs textarea)
    /// </summary>
    /// <param name = "prefix"></param>
    /// <param name = "candidates"></param>
    /// <param name = "foundIndex"></param>
    public static string StartWith(string prefix, IList<string> candidates, out int foundIndex)
    {
        foundIndex = -1;
        foreach (var item in candidates)
        {
            foundIndex++;
            if (item.StartsWith(prefix))
                return item;
        }

        return null;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "prefix"></param>
    /// <param name = "lines"></param>
    public static List<string> TrimStart(string prefix, List<string> lines)
    {
        ThrowEx.IsNull("prefix", prefix);
        ThrowEx.IsNull("lines", lines);
        for (var i = 0; i < lines.Count; i++)
            if (lines[i].StartsWith(prefix))
                lines[i] = lines[i].Substring(prefix.Length);
        return lines;
    }

    public static void AppendToLastElement(List<string> list, string text)
    {
        if (list.Count > 0)
            list[list.Count - 1] += text;
        else
            list.Add(text);
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "wrapper"></param>
    public static List<string> WrapWith(List<string> list, string wrapper)
    {
        return WrapWith(list, wrapper, wrapper);
    }

    /// <summary>
    ///     direct edit
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "before"></param>
    /// <param name = "after"></param>
    public static List<string> WrapWith(List<string> list, string before, string after)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = before + list[i] + after;
        return list;
    }

    public static List<long> ToLong(IList enumerable)
    {
        var result = new List<long>();
        foreach (var item in enumerable)
            result.Add(long.Parse(item.ToString()));
        return result;
    }

    public static List<short> ToShort(IList enumerable)
    {
        var result = new List<short>();
        foreach (var item in enumerable)
            result.Add(short.Parse(item.ToString()));
        return result;
    }

    public static List<byte> JoinBytesArray(byte[] firstArray, byte[] secondArray)
    {
        var result = new List<byte>(firstArray.Length + secondArray.Length);
        result.AddRange(firstArray);
        result.AddRange(secondArray);
        return result;
    }

    public static int GetLength(IList list)
    {
        if (list == null)
            return 0;
        return list.Count;
    }

    public static string[] JoinVariableAndArray(object firstElement, IList list)
    {
        var result = new List<string>();
        result.Add(firstElement.ToString());
        foreach (var item in list)
            result.Add(item.ToString());
        return result.ToArray();
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "toTrim"></param>
    public static List<string> TrimEnd(List<string> list, params char[] toTrim)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].TrimEnd(toTrim);
        return list;
    }

    public static List<int> StartWithAnyInElement(string text, List<string> list, bool trimBefore)
    {
        var result = new List<int>();
        var i = 0;
        foreach (var item in list)
        {
            var item2 = item;
            if (trimBefore)
                item2 = item2.Trim();
            if (text.StartsWith(item2))
                result.Add(i);
            i++;
        }

        return result;
    }
}