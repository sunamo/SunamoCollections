namespace SunamoCollections;

/// <summary>
/// Represents the CA type.
/// </summary>
public partial class CA
{
    /// <summary>
    /// The d first or null.
    /// </summary>
    public static Func<IList, object> dFirstOrNull = null;

    //dFirstOrNull
    private static Type type = typeof(CA);

    /// <summary>
    /// Occurence of every line.
    /// </summary>
    /// <param name="CA">The CA.</param>
    /// <returns>The occurence of every line result.</returns>
    public static Dictionary<string, int> OccurenceOfEveryLine(List<string> l)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Last item.
    /// </summary>
    /// <returns>The last item result.</returns>
    public static string LastItem(string version, string v)
    {
        throw new NotImplementedException();
    }






    /// <summary>
    /// Init fill with.
    /// </summary>
    /// <param name="datas">The datas.</param>
    /// <param name="count">The count.</param>
    /// <param name="initWith">The init with.</param>
    public static void InitFillWith(List<string> datas, int count, string initWith = "")
    {
        InitFillWith<string>(datas, count, initWith);
    }

    /// <summary>
    /// Initializes a new instance of the init fill with t class.
    /// </summary>
    /// <typeparam name="string">The type string.</typeparam>
    /// <param name="datas">The datas.</param>
    /// <param name="count">The count.</param>
    /// <param name="initWith">The init with.</param>
    public static void InitFillWith<T>(List<T> datas, int count, T initWith)
    {
        for (var i = 0; i < count; i++) datas.Add(initWith);
    }






    /// <summary>
    /// Count.
    /// </summary>
    /// <param name="e">The e.</param>
    /// <returns>The count result.</returns>
    public static int Count(IEnumerable e)
    {
        if (e == null) return 0;
        if (e is IList l) return l.Count;
        if (e is Array a) return a.Length;
        var count = 0;
        foreach (var item in e) count++;
        return count;
    }


    /// <summary>
    /// Trim.
    /// </summary>
    /// <param name="l">The l.</param>
    /// <returns>The trim result.</returns>
    public static List<string> Trim(List<string> l)
    {
        for (var i = 0; i < l.Count; i++) l[i] = l[i].Trim();
        return l;
    }

    /// <summary>
    /// Trim where is only whitespace.
    /// </summary>
    /// <param name="Trim"">The trim.</param>
    /// <returns>The trim where is only whitespace result.</returns>
    [Obsolete("Do the same as Trim")]
    public static void TrimWhereIsOnlyWhitespace(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var l = list[i];
            if (string.IsNullOrWhiteSpace(l)) list[i] = list[i].Trim();
        }
    }

    /// <summary>
    /// First.
    /// </summary>
    /// <param name="v2">The v 2.</param>
    /// <returns>The first result.</returns>
    public static string First(IEnumerable v2)
    {
        foreach (var item in v2) return item.ToString();
        return null;
    }

    /// <summary>
    /// Is list string wrapped in array.
    /// </summary>
    /// <param name="v2">The v 2.</param>
    /// <returns>The is list string wrapped in array result.</returns>
    public static bool IsListStringWrappedInArray(IEnumerable v2)
    {
        var first = First(v2);
        if (Count(v2) == 1 && (first == "System.Collections.Generic.List`1[System.String]" ||
                               first == "System.Collections.Generic.List`1[System.Object]")) return true;
        return false;
    }


    /// <summary>
    /// Wrap with if func.
    /// </summary>
    /// <param name="f">The f.</param>
    /// <param name="invert">The invert.</param>
    /// <param name="mustContains">The must contains.</param>
    /// <param name="wrapWith">The wrap with.</param>
    /// <param name="whereIsUsed2">The where is used 2.</param>
    /// <returns>The wrap with if func result.</returns>
    public static List<string> WrapWithIfFunc(Func<string, string, bool, bool> f, bool invert, string mustContains,
        string wrapWith, params string[] whereIsUsed2)
    {
        for (var i = 0; i < whereIsUsed2.Length; i++)
            if (f.Invoke(whereIsUsed2[i], mustContains, invert))
                whereIsUsed2[i] = wrapWith + whereIsUsed2[i] + wrapWith;
        return whereIsUsed2.ToList();
    }

    /// <summary>
    /// Get index.
    /// </summary>
    /// <returns>The get index result.</returns>
    public static object GetIndex(List<string> captions, int i)
    {
        if (captions == null) return null;
        if (!HasIndex(i, captions)) return null;
        return captions[i];
    }

    //[ObjectParamsObsoleteAttribute]
    //    //            // this must be IEnumerable because many things from .net can come in this way (e.g. string)
    //    //                //enumerable2 is not string, then I can add all to list
    //    //            else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList &&
    //    //        }
    //    //    }
    //    //}

    /// <summary>
    /// Has index.
    /// </summary>
    /// <param name="dex">The dex.</param>
    /// <param name="col">The col.</param>
    /// <returns>The has index result.</returns>
    public static bool HasIndex(int dex, Array col)
    {
        return col.Length > dex;
    }

    /// <summary>
    /// Has index.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <param name="nahledy">The nahledy.</param>
    /// <returns>The has index result.</returns>
    public static bool HasIndex(int p, IList nahledy)
    {
        if (p < 0) throw new Exception("Chybn\u00FD parametr p");
        if (nahledy.Count > p) return true;
        return false;
    }

    /// <summary>
    /// Remove and leading.
    /// </summary>
    /// <param name="tokens">The tokens.</param>
    /// <param name="v">The v.</param>
    /// <returns>The remove and leading result.</returns>
    public static bool RemoveAndLeading(List<string> tokens, string v)
    {
        var dx = tokens.IndexOf(v);
        if (dx != -1)
        {
            tokens.RemoveAt(dx);
            tokens.Insert(0, v);
            return true;
        }

        return false;
    }



    /// <summary>
    /// Double or more multi lines to single.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The double or more multi lines to single result.</returns>
    public static string DoubleOrMoreMultiLinesToSingle(string list)
    {
        DoubleOrMoreMultiLinesToSingle(ref list);
        return list;
    }

    /// <summary>
    /// Remove null empty ws.
    /// </summary>
    /// <param name="l">The l.</param>
    /// <returns>The remove null empty ws result.</returns>
    public static void RemoveNullEmptyWs(List<string> l)
    {
        for (var i = l.Count - 1; i >= 0; i--)
            if (string.IsNullOrWhiteSpace(l[i]))
                l.RemoveAt(i);
    }

    /// <summary>
    /// Initializes a new instance of the is empty or null class.
    /// </summary>
    /// <param name="i">The i.</param>
    public static bool IsEmptyOrNull(IList mustBe)
    {
        if (mustBe == null)
            return true;
        if (mustBe.Count == 0) return true;
        return false;
    }

    /// <summary>
    /// To lower.
    /// </summary>
    /// <param name="ss">The ss.</param>
    /// <param name="createNewArray">The create new array.</param>
    /// <returns>The to lower result.</returns>
    public static List<string> ToLower(List<string> ss, bool createNewArray = false)
    {
        var outArr = ss;
        if (createNewArray)
        {
            outArr = new List<string>(ss.Count);
            InitFillWith(outArr, ss.Count);
        }

        for (var i = 0; i < ss.Count; i++) outArr[i] = ss[i].ToLower();
        return outArr;
    }

    /// <summary>
    /// Double or more multi lines to single.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The double or more multi lines to single result.</returns>
    public static void DoubleOrMoreMultiLinesToSingle(ref string list)
    {
        var n = Environment.NewLine;
        list = Regex.Replace(list, @"(\r?\n\s*){2,}", Environment.NewLine + Environment.NewLine);
        list = list.Trim();
        // 27-10-23 it used to be like this
    }

    /// <summary>
    /// Convert list string wrapped in array.
    /// </summary>
    /// <param name="innerMain">The inner main.</param>
    /// <returns>The convert list string wrapped in array result.</returns>
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
                foreach (var item in first) result.Add(item);
            }

            return result.ToArray();
        }

        return innerMain;
    }

    /// <summary>
    /// Is negation tuple.
    /// </summary>
    /// <param name="bool">The bool.</param>
    /// <param name="string">The string.</param>
    /// <returns>The is negation tuple result.</returns>
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
    /// Initializes a new instance of the remove starting with class.
    /// </summary>
    /// <param name="false">The false.</param>
    /// <param name="contains">The contains.</param>
    public static void RemoveStartingWith(string start, List<string> mySites, RemoveStartingWithArgsCA a = null)
    {
        if (a == null) a = new RemoveStartingWithArgsCA();
        var (negate, start2) = IsNegationTuple(start);
        start = start2;
        for (var i = mySites.Count - 1; i >= 0; i--)
        {
            var val = mySites[i];
            if (a.TrimBeforeFinding) val = val.Trim();
            if (negate)
            {
                if (!StartingWith(val, start, a.CaseSensitive)) mySites.RemoveAt(i);
            }
            else
            {
                if (StartingWith(val, start, a.CaseSensitive)) mySites.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Starting with.
    /// </summary>
    /// <param name="v">The v.</param>
    /// <param name="l">The l.</param>
    /// <returns>The starting with result.</returns>
    public static List<string> StartingWith(string v, List<string> l)
    {
        for (var i = l.Count - 1; i >= 0; i--)
            if (!l[i].StartsWith(v))
                l.RemoveAt(i);
        return l;
    }

    /// <summary>
    /// Starting with.
    /// </summary>
    /// <param name="val">The val.</param>
    /// <param name="start">The start.</param>
    /// <param name="caseSensitive">The case sensitive.</param>
    /// <returns>The starting with result.</returns>
    public static bool StartingWith(string val, string start, bool caseSensitive)
    {
        if (caseSensitive)
            return val.StartsWith(start);
        return val.ToLower().StartsWith(start.ToLower());
    }

    /// <summary>
    /// Remove strings empty trim before.
    /// </summary>
    /// <returns>The remove strings empty trim before result.</returns>
    public static List<string> RemoveStringsEmptyTrimBefore(List<string> mySites)
    {
        for (var i = mySites.Count - 1; i >= 0; i--)
            if (mySites[i].Trim() == string.Empty)
                mySites.RemoveAt(i);
        return mySites;
    }

    private static string Replace(string s, string from, string to)
    {
        return s.Replace(from, to);
    }

    /// <summary>
    /// Replace.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <returns>The replace result.</returns>
    public static void Replace(List<string> files_in, string what, string forWhat)
    {
        for (var i = 0; i < files_in.Count; i++) files_in[i] = Replace(files_in[i], what, forWhat);
    }

    /// <summary>
    /// Initializes a new instance of the to list string i enumerable 2 class.
    /// </summary>
    /// <param name="i">The i.</param>
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


    /// <summary>
    /// Returns true when at least one of the directories contains the given path as a substring.
    /// </summary>
    /// <param name="dirs">The directories to search in.</param>
    /// <param name="pathWithoutNameBs">The path (without file name) to look for.</param>
    /// <returns>True when some directory contains the path; false for an empty list.</returns>
    public static bool PartialContains(List<string> dirs, string pathWithoutNameBs)
    {
        foreach (var item in dirs)
        {
            if (item.Contains(pathWithoutNameBs))
            {
                return true;
            }
        }

        return false;
    }



    /// <summary>
    /// All non whitespace lines.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <returns>The all non whitespace lines result.</returns>
    public static int AllNonWhitespaceLines(List<string> lines)
    {
        var nonEmptyLines = 0;

        for (var i = 0; i < lines.Count; i++)
            if (lines[i].Trim() != string.Empty)
                nonEmptyLines++;

        return nonEmptyLines;
    }

    /// <summary>
    /// Remove strings empty from begin start.
    /// </summary>
    /// <param name="sourceList">The source list.</param>
    /// <returns>The remove strings empty from begin start result.</returns>
    public static List<string> RemoveStringsEmptyFromBeginStart(List<string> sourceList)
    {

        int start = 0, end = sourceList.Count - 1;

        while (start < end && string.IsNullOrWhiteSpace(sourceList[start])) start++;
        while (end >= start && string.IsNullOrWhiteSpace(sourceList[end])) end--;

        var result = sourceList.Skip(start).Take(end - start + 1).ToList();

        return result;
    }
}