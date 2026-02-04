namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    public static Dictionary<string, int> OccurenceOfEveryLine(List<string> list)
    {
        throw new NotImplementedException();
    }

    public static string LastItem(string text, string value)
    {
        throw new NotImplementedException();
    }

    public static void InitFillWith(List<string> list, int count, string initWith = "")
    {
        InitFillWith<string>(list, count, initWith);
    }

    public static void InitFillWith<T>(List<T> list, int count, T initWith)
    {
        for (var i = 0; i < count; i++)
            list.Add(initWith);
    }

    public static int Count(IEnumerable enumerable)
    {
        if (enumerable == null)
            return 0;
        if (enumerable is IList)
            return (enumerable as IList).Count;
        if (enumerable is Array)
            return (enumerable as Array).Length;
        var count = 0;
        foreach (var item in enumerable)
            count++;
        return count;
    }

    public static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].Trim();
        return list;
    }

    [Obsolete("Do the same as Trim")]
    public static void TrimWhereIsOnlyWhitespace(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var element = list[i];
            if (string.IsNullOrWhiteSpace(element))
                list[i] = list[i].Trim();
        }
    }

    public static string First(IEnumerable enumerable)
    {
        foreach (var item in enumerable)
            return item.ToString();
        return null;
    }

    public static bool IsListStringWrappedInArray(IEnumerable enumerable)
    {
        var first = First(enumerable);
        if (Count(enumerable) == 1 && (first == "System.Collections.Generic.List`1[System.String]" || first == "System.Collections.Generic.List`1[System.Object]"))
            return true;
        return false;
    }

    public static List<string> WrapWithIfFunc(Func<string, string, bool, bool> predicate, bool invert, string mustContains, string wrapWith, params string[] array)
    {
        for (var i = 0; i < array.Length; i++)
            if (predicate.Invoke(array[i], mustContains, invert))
                array[i] = wrapWith + array[i] + wrapWith;
        return array.ToList();
    }

    /// <summary>
    ///     Return null if A1 will be null
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "index"></param>
    public static object GetIndex(List<string> list, int index)
    {
        if (list == null)
            return null;
        if (!HasIndex(index, list))
            return null;
        return list[index];
    }

    /// <summary>
    ///     ToListString2 - simply for all items call ToString()
    ///     ToListString - working with Type of every element
    ///     Just 3 cases of working:
    ///     IList&lt;char&gt; =&gt; string
    ///     IList&lt;string&gt; =&gt; List&lt;string&gt;
    ///     IList =&gt; List&lt;string&gt;
    /// </summary>
    /// <param name = "enumerable"></param>
     //[ObjectParamsObsoleteAttribute]
    //public static List<string> ToListStringIList(IList enumerable2)
    //{
    //    return null;
    //    //List<string> result = new List<string>();
    //    //if (enumerable2.GetType() != typeof(string))
    //    //{
    //    //    foreach (object item in enumerable2)
    //    //    {
    //    //        Type temp = item.GetType();
    //    //        // !(item is string)  - not working
    //    //        if (RH.IsOrIsDeriveFromBaseClass(temp, Types.TIEnumerable))
    //    //        {
    //    //            // zde to musí být IEnumerable protože spousta věcí z .netu může takhle přijít (např. string)
    //    //            var enumerable = (System.Collections.IEnumerable)item;
    //    //            Type Type = enumerable.GetType();
    //    //            bool isEnumerableChar = RH.IsOrIsDeriveFromBaseClass(Type, typeof(IList<char>));
    //    //            bool isEnumerableString = RH.IsOrIsDeriveFromBaseClass(Type, typeof(IList<string>));
    //    //            if (Type == typeof(string))
    //    //            {
    //    //                result.Add(string.Join(string.Empty, enumerable));
    //    //            }
    //    //            else if (isEnumerableChar)
    //    //            {
    //    //                // IList<char> => string
    //    //                //enumerable2 is not string, then I can add all to List
    //    //                result.AddRange(ToListStringIEnumerable2(enumerable));
    //    //            }
    //    //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList<string>)
    //    //            {
    //    //                // IList<string> => List<string>
    //    //                result.AddRange(((IList<string>)enumerable.FirstOrNull()).ToList());
    //    //            }
    //    //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList &&
    //    //                     !isEnumerableChar && !isEnumerableString)
    //    //            {
    //    //                result.AddRange(ToListStringIEnumerable2((IList)enumerable.FirstOrNull()));
    //    //            }
    //    //            else
    //    //            {
    //    //                // IList => List<string>
    //    //                result.AddRange(ToListStringIEnumerable2(enumerable));
    //    //            }
    //    //        }
    //    //        else
    //    //        {
    //    //            result.Add(item.ToString());
    //    //        }
    //    //    }
    //    //}
    //    //else
    //    //{
    //    //    result.Add(enumerable2.ToString());
    //    //}
    //    //return result;
    //}
    public static bool HasIndex(int index, Array array)
    {
        return array.Length > index;
    }

    public static bool HasIndex(int index, IList list)
    {
        if (index < 0)
            throw new Exception("Invalid parameter index");
        if (list.Count > index)
            return true;
        return false;
    }

    public static bool RemoveAndLeading(List<string> list, string value)
    {
        var index = list.IndexOf(value);
        if (index != -1)
        {
            list.RemoveAt(index);
            list.Insert(0, value);
            return true;
        }

        return false;
    }

    public static string DoubleOrMoreMultiLinesToSingle(string text)
    {
        DoubleOrMoreMultiLinesToSingle(ref text);
        return text;
    }

    public static void RemoveNullEmptyWs(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (string.IsNullOrWhiteSpace(list[i]))
                list.RemoveAt(i);
    }

    /// <summary>
    ///     Return true if A1 is null or have zero elements
    /// </summary>
    /// <param name = "list"></param>
    public static bool IsEmptyOrNull(IList list)
    {
        if (list == null)
            return true;
        if (list.Count == 0)
            return true;
        return false;
    }

    /// <summary>
    ///     Pro vyssi vykon uklada primo do zdrojoveho pole, pokud neni A2
    /// </summary>
    /// <param name = "list"></param>
    public static List<string> ToLower(List<string> list, bool createNewArray = false)
    {
        var result = list;
        if (createNewArray)
        {
            result = new List<string>(list.Count);
            InitFillWith(result, list.Count);
        }

        for (var i = 0; i < list.Count; i++)
            result[i] = list[i].ToLower();
        return result;
    }

    public static void DoubleOrMoreMultiLinesToSingle(ref string text)
    {
        text = Regex.Replace(text, @"(\r?\n\s*){2,}", Environment.NewLine + Environment.NewLine);
        text = text.Trim();
    }
}