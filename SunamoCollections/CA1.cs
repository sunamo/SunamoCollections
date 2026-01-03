namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    /// <summary>
    ///     A1 musí být string[], kdyby byl string[] nemůžu vložit List&lt;string&gt;, tj. object ale ne string
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "array"></param>
    /// <returns></returns>
    [ObjectParamsObsoleteAttribute]
    public static object[] ConvertListStringWrappedInArray(object[] array)
    {
        if (IsListStringWrappedInArray(array))
        {
            List<object> result = null;
            var first = (IEnumerable)array[0];
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

        return array;
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
            var value = list[i];
            if (args.TrimBeforeFinding)
                value = value.Trim();
            if (negate)
            {
                if (!StartingWith(value, start, args.CaseSensitive))
                    list.RemoveAt(i);
            }
            else
            {
                if (StartingWith(value, start, args.CaseSensitive))
                    list.RemoveAt(i);
            }
        }
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "prefix"></param>
    /// <param name = "list"></param>
    /// <returns></returns>
    public static List<string> StartingWith(string prefix, List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (!list[i].StartsWith(prefix))
                list.RemoveAt(i);
        return list;
    }

    public static bool StartingWith(string text, string start, bool caseSensitive)
    {
        if (caseSensitive)
            return text.StartsWith(start);
        return text.ToLower().StartsWith(start.ToLower());
    }

    public static List<string> RemoveStringsEmptyTrimBefore(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (list[i].Trim() == string.Empty)
                list.RemoveAt(i);
        return list;
    }

    private static string Replace(string text, string what, string replacement)
    {
        return text.Replace(what, replacement);
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
    ///     ToListString - working with Type of every element - returns List&lt;string&gt;
    ///     Nothing more, nothing less
    ///     Must be private - to use only public in CA
    ///     bcoz Cast() not working
    ///     Dont make any Type checking - could be done before
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

    public static int AllNonWhitespaceLines(List<string> list)
    {
        var nonEmptyLines = 0;
        for (var i = 0; i < list.Count; i++)
            if (list[i].Trim() != string.Empty)
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

    public static void RemoveLines(List<string> list, List<int> removeList)
    {
        removeList.Sort();
        for (var i = removeList.Count - 1; i >= 0; i--)
        {
            var index = removeList[i];
            list.RemoveAt(index);
        }
    }

    public static void Remove(List<string> list, List<string> what)
    {
        foreach (var item in what)
            list.Remove(item);
    }

    public static void AddSuffix(List<string> list, string value)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i] + value;
    }

    public static List<string> CreateListStringWithReserve(int reserveCapacity, IList<string> list)
    {
        var vs = new List<string>(reserveCapacity + list.Count());
        vs.AddRange(list);
        return vs;
    }

    public static List<char> ToListChar(ICollection<string> collection)
    {
        var result = new List<char>(collection.Count);
        foreach (var item in collection)
            result.Add(item[0]);
        return result;
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

    public static bool AnyElementEndsWith(string text, IList<string> suffixes)
    {
        string matchedElement = null;
        return AnyElementEndsWith(text, suffixes, out matchedElement);
    }

    public static bool AnyElementEndsWith(string text, IList<string> suffixes, out string element)
    {
        element = null;
        foreach (var suffix in suffixes)
            if (suffix.EndsWith(text))
            {
                element = suffix;
                return true;
            }

        return false;
    }
}