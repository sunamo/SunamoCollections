
// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections;
public partial class CA
{
    /// <summary>
    ///     A1 musí být string[], kdyby byl string[] nemůžu vložit List<string>, tj. object ale ne string
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "innerMain"></param>
    /// <returns></returns>
    [ObjectParamsObsoleteAttribute]
    public static object[] ConvertListStringWrappedInArray(object[] innerMain)
    {
        if (IsListStringWrappedInArray(innerMain))
        {
            List<object> result = null;
            var first = (IEnumerable)innerMain[0];
            if (first is List<object>)
            {
                result = (List<object>)first;
            }
            else
            {
                result = new List<object>();
                foreach (var item in first)
                    result.Add(item);
            }

            return result.ToArray();
        }

        return innerMain;
    }

    public static (bool, string) IsNegationTuple(string contains)
    {
        if (contains[0] == '!')
        {
            contains = contains.Substring(1);
            return (true, contains);
        }

        return (false, contains);
    }

    /// <summary>
    ///     Remove elements starting with A1
    ///     Direct edit
    /// </summary>
    /// <param name = "start"></param>
    /// <param name = "list"></param>
    public static void RemoveStartingWith(string start, List<string> list, RemoveStartingWithArgsCA args = null)
    {
        if (args == null)
            args = new RemoveStartingWithArgsCA();
        var(negate, start2) = IsNegationTuple(start);
        start = start2;
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var val = list[i];
            if (args.TrimBeforeFinding)
                val = val.Trim();
            if (negate)
            {
                if (!StartingWith(val, start, args.CaseSensitive))
                    list.RemoveAt(i);
            }
            else
            {
                if (StartingWith(val, start, args.CaseSensitive))
                    list.RemoveAt(i);
            }
        }
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "value"></param>
    /// <param name = "list"></param>
    /// <returns></returns>
    public static List<string> StartingWith(string value, List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (!list[i].StartsWith(value))
                list.RemoveAt(i);
        return list;
    }

    public static bool StartingWith(string val, string start, bool caseSensitive)
    {
        if (caseSensitive)
            return val.StartsWith(start);
        return val.ToLower().StartsWith(start.ToLower());
    }

    public static List<string> RemoveStringsEmptyTrimBefore(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (list[i].Trim() == string.Empty)
                list.RemoveAt(i);
        return list;
    }

    private static string Replace(string text, string from, string to)
    {
        return text.Replace(from, to);
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    public static void Replace(List<string> list, string what, string replacement)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = Replace(list[i], what, replacement);
    //CAChangeContent.ChangeContent2(null, list, Replace, what, replacement);
    }

    /// <summary>
    ///     ToListString2 - simply for all items call ToString()
    ///     ToListString - working with Type of every element
    ///     <string>
    ///         Nothing more, nothing less
    ///         Must be private - to use only public in CA
    ///         bcoz Cast() not working
    ///         Dont make any Type checking - could be done before
    /// </summary>
    public static List<string> ToListStringIEnumerable2(IEnumerable enumerable)
    {
        var result = new List<string>( /*enumerable.Count()*/);
        foreach (var item in enumerable)
            if (item == null)
                result.Add("(null)");
            else
                result.Add(item.ToString());
        return result;
    }

    public static bool PartialContains(List<string> directories, string pathWithoutNameBs)
    {
        throw new NotImplementedException();
    }

    public static int AllNonWhitespaceLines(List<string> lines)
    {
        var nonEmptyLines = 0;
        for (var i = 0; i < lines.Count; i++)
            if (lines[i].Trim() != string.Empty)
                nonEmptyLines++;
        return nonEmptyLines;
    }

    public static List<string> RemoveStringsEmptyFromBeginStart(List<string> list)
    {
        //textLines1.SkipWhile(e => !HasContent(e))
        //            .Reverse()
        //            .SkipWhile(e => !HasContent(e))
        //            .Reverse()
        //            .ToList();
        int start = 0, end = list.Count - 1;
        while (start < end && string.IsNullOrWhiteSpace(list[start]))
            start++;
        while (end >= start && string.IsNullOrWhiteSpace(list[end]))
            end--;
        var result = list.Skip(start).Take(end - start + 1).ToList();
        return result;
    }

    public static void RemoveLines(List<string> lines, List<int> removeLines)
    {
        removeLines.Sort();
        for (var i = removeLines.Count - 1; i >= 0; i--)
        {
            var index = removeLines[i];
            lines.RemoveAt(index);
        }
    }

    public static void Remove(List<string> from, List<string> what)
    {
        foreach (var item in what)
            from.Remove(item);
    }

    public static void AddSuffix(List<string> list, string value)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i] + value;
    }

    public static List<string> CreateListStringWithReserve(int reserveCapacity, IList<string> value)
    {
        var vs = new List<string>(reserveCapacity + value.Count());
        vs.AddRange(value);
        return vs;
    }

    public static List<char> ToListChar(ICollection<string> values)
    {
        var value = new List<char>(values.Count);
        foreach (var item in values)
            value.Add(item[0]);
        return value;
    }

    public static bool HasDuplicates(List<string> list)
    {
        var list2 = list.ToList();
        //CAG.RemoveDuplicitiesList(List);
        list2 = list2.Distinct().ToList();
        if (list2.Count != list.Count)
            //Console.WriteLine( Exceptions.DifferentCountInLists(string.Empty, "list2", list2.Count, "List", list.Count));
            return true;
        return false;
    }

    public static void Unindent(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            var line = list[i];
            if (line.StartsWith("\t"))
                list[i] = list[i].Substring("\t".Length);
            else if (line.StartsWith(" "))
                list[i] = list[i].Substring(" ".Length);
        }
    }

    public static bool AnyElementEndsWith(string temp, IList<string> value)
    {
        string item2 = null;
        return AnyElementEndsWith(temp, value, out item2);
    }

    public static bool AnyElementEndsWith(string temp, IList<string> value, out string element)
    {
        element = null;
        foreach (var item in value)
            if (item.EndsWith(temp))
            {
                element = item;
                return true;
            }

        return false;
    }
}
