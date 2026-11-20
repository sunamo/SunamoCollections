namespace SunamoCollections;

public partial class CA
{

    /// <summary>
    /// Remove lines.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <param name="removeLines">The remove lines.</param>
    /// <returns>The remove lines result.</returns>
    public static void RemoveLines(List<string> lines, List<int> removeLines)
    {
        removeLines.Sort();
        for (var i = removeLines.Count - 1; i >= 0; i--)
        {
            var dx = removeLines[i];
            lines.RemoveAt(dx);
        }
    }


    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="what">The what.</param>
    /// <returns>The remove result.</returns>
    public static void Remove(List<string> from, List<string> what)
    {
        foreach (var item in what) from.Remove(item);
    }


    /// <summary>
    /// Add suffix.
    /// </summary>
    /// <param name="headers">The headers.</param>
    /// <param name="v">The v.</param>
    /// <returns>The add suffix result.</returns>
    public static void AddSuffix(List<string> headers, string v)
    {
        for (var i = 0; i < headers.Count; i++) headers[i] = headers[i] + v;
    }

    /// <summary>
    /// Initializes a new instance of the create list string with reverse class.
    /// </summary>
    /// <param name="i">The i.</param>
    public static List<string> CreateListStringWithReverse(int reverse, IList<string> v)
    {
        var vs = new List<string>(reverse + v.Count());
        vs.AddRange(v);
        return vs;
    }


    /// <summary>
    /// To list char.
    /// </summary>
    /// <param name="values">The values.</param>
    /// <returns>The to list char result.</returns>
    public static List<char> ToListChar(ICollection<string> values)
    {
        var v = new List<char>(values.Count);
        foreach (var item in values) v.Add(item[0]);
        return v;
    }


    /// <summary>
    /// Has duplicates.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The has duplicates result.</returns>
    public static bool HasDuplicates(List<string> list)
    {
        var list2 = list.ToList();
        list2 = list2.Distinct().ToList();
        if (list2.Count != list.Count)
            return true;
        return false;
    }


    /// <summary>
    /// Unindent.
    /// </summary>
    /// <param name="l">The l.</param>
    /// <returns>The unindent result.</returns>
    public static void Unindent(List<string> l)
    {
        for (var i = 0; i < l.Count; i++)
        {
            var line = l[i];
            if (line.StartsWith("\t"))
                l[i] = l[i].Substring("\t".Length);
            else if (line.StartsWith(" ")) l[i] = l[i].Substring(" ".Length);
        }
    }






    /// <summary>
    /// Any element ends with.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="v">The v.</param>
    /// <returns>The any element ends with result.</returns>
    public static bool AnyElementEndsWith(string t, IList<string> v)
    {
        string item2 = null;
        return AnyElementEndsWith(t, v, out item2);
    }

    /// <summary>
    /// Any element ends with.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="v">The v.</param>
    /// <param name="item2">The item 2.</param>
    /// <returns>The any element ends with result.</returns>
    public static bool AnyElementEndsWith(string t, IList<string> v, out string element)
    {
        element = null;

        foreach (var item in v)
            if (item.EndsWith(t))
            {
                element = item;
                return true;
            }

        return false;
    }

    /// <summary>
    /// Ends with any element.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="v">The v.</param>
    /// <returns>The ends with any element result.</returns>
    public static bool EndsWithAnyElement(string t, params string[] v)
    {
        return EndsWithAnyElement(t, v.ToList());
    }

    /// <summary>
    /// Ends with any element.
    /// </summary>
    /// <param name="t">The t.</param>
    /// <param name="v.ToList()">The v to list.</param>
    /// <returns>The ends with any element result.</returns>
    public static bool EndsWithAnyElement(string t, IList<string> v)
    {
        foreach (var item in v)
            if (t.EndsWith(item))
                return true;
        return false;
    }

    /// <summary>
    /// Ends with.
    /// </summary>
    /// <param name="fn">The fn.</param>
    /// <param name="allowedExtension">The allowed extension.</param>
    /// <returns>The ends with result.</returns>
    public static bool EndsWith(string fn, List<string> allowedExtension)
    {
        foreach (var item in allowedExtension)
            if (fn.EndsWith(item))
                return true;
        return false;
    }

    /// <summary>
    /// Join.
    /// </summary>
    /// <param name="o">The o.</param>
    /// <returns>The join result.</returns>
    public static List<string> Join(IEnumerable<object> o)
    {
        var result = new List<string>();
        foreach (var item in o)
        {
            result.AddRange(new List<string>([item.ToString()]));
        }

        return result;
    }

    /// <summary>
    /// Replace all.
    /// </summary>
    /// <param name="r">The r.</param>
    /// <param name="what">The what.</param>
    /// <param name="forWhat">The for what.</param>
    /// <returns>The replace all result.</returns>
    public static string ReplaceAll(string r, List<string> what, string forWhat)
    {
        foreach (var item in what) r = r.Replace(item, forWhat);

        return r;
    }


    /// <summary>
    /// Remove which exists.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="manuallyNo">The manually no.</param>
    /// <returns>The remove which exists result.</returns>
    public static void RemoveWhichExists(IList<string> s, List<string> manuallyNo)
    {
        var dex = -1;
        foreach (var item in manuallyNo)
        {
            dex = s.IndexOf(item);
            if (dex != -1) s.RemoveAt(dex);
        }
    }





    /// <summary>
    /// Start with.
    /// </summary>
    /// <param name="item2">The item 2.</param>
    /// <param name="v1">The v 1.</param>
    /// <returns>The start with result.</returns>
    public static string StartWith(string item2, params string[] v1)
    {
        return StartWith(item2, v1.ToList());
    }

    /// <summary>
    /// Start with.
    /// </summary>
    /// <param name="item2">The item 2.</param>
    /// <param name="v1.ToList()">The v 1 to list.</param>
    /// <returns>The start with result.</returns>
    public static string StartWith(string item2, IList<string> v1)
    {
        int i;
        return StartWith(item2, v1, out i);
    }

    /// <summary>
    /// Start with.
    /// </summary>
    /// <param name="item2">The item 2.</param>
    /// <param name="v1">The v 1.</param>
    /// <param name="i">The i.</param>
    /// <returns>The start with result.</returns>
    public static string StartWith(string item2, IList<string> v1, out int i)
    {
        i = -1;
        foreach (var item in v1)
        {
            i++;
            if (item.StartsWith(item2)) return item;
        }

        return null;
    }

    /// <summary>
    /// Trim start.
    /// </summary>
    /// <param name="backslash">The backslash.</param>
    /// <param name="s">The s.</param>
    /// <returns>The trim start result.</returns>
    public static List<string> TrimStart(string backslash, List<string> s)
    {
        ThrowEx.IsNull("backslash", backslash);
        ThrowEx.IsNull("s", s);

        for (var i = 0; i < s.Count; i++)
            if (s[i].StartsWith(backslash))
                s[i] = s[i].Substring(backslash.Length);
        return s;
    }




    /// <summary>
    /// Append to last element.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="s">The s.</param>
    public static void AppendToLastElement(List<string> list, string s)
    {
        if (list.Count > 0)
            list[list.Count - 1] += s;
        else
            list.Add(s);
    }





    /// <summary>
    /// Wrap with.
    /// </summary>
    /// <param name="whereIsUsed2">The where is used 2.</param>
    /// <param name="v">The v.</param>
    /// <returns>The wrap with result.</returns>
    public static List<string> WrapWith(List<string> whereIsUsed2, string v)
    {
        return WrapWith(whereIsUsed2, v, v);
    }

    /// <summary>
    /// Wrap with.
    /// </summary>
    /// <param name="whereIsUsed2">The where is used 2.</param>
    /// <param name="v">The v.</param>
    /// <returns>The wrap with result.</returns>
    public static List<string> WrapWith(List<string> whereIsUsed2, string before, string after)
    {
        for (var i = 0; i < whereIsUsed2.Count; i++) whereIsUsed2[i] = before + whereIsUsed2[i] + after;
        return whereIsUsed2;
    }


    /// <summary>
    /// To long.
    /// </summary>
    /// <param name="enumerable">The enumerable.</param>
    /// <returns>The to long result.</returns>
    public static List<long> ToLong(IList enumerable)
    {
        var result = new List<long>();
        foreach (var item in enumerable) result.Add(long.Parse(item.ToString()));
        return result;
    }




    /// <summary>
    /// To short.
    /// </summary>
    /// <param name="enumerable">The enumerable.</param>
    /// <returns>The to short result.</returns>
    public static List<short> ToShort(IList enumerable)
    {
        var result = new List<short>();
        foreach (var item in enumerable) result.Add(short.Parse(item.ToString()));
        return result;
    }


    /// <summary>
    /// Join bytes array.
    /// </summary>
    /// <param name="pass">The pass.</param>
    /// <param name="salt">The salt.</param>
    /// <returns>The join bytes array result.</returns>
    public static List<byte> JoinBytesArray(byte[] pass, byte[] salt)
    {
        var lb = new List<byte>(pass.Length + salt.Length);
        lb.AddRange(pass);
        lb.AddRange(salt);
        return lb;
    }






    /// <summary>
    /// Get length.
    /// </summary>
    /// <param name="where">The where.</param>
    /// <returns>The get length result.</returns>
    public static int GetLength(IList where)
    {
        if (where == null) return 0;
        return where.Count;
    }

    /// <summary>
    /// Join variable and array.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <param name="columns">The columns.</param>
    /// <returns>The join variable and array result.</returns>
    public static string[] JoinVariableAndArray(object p, IList columns)
    {
        var o = new List<string>();
        o.Add(p.ToString());
        foreach (var item in columns) o.Add(item.ToString());

        return o.ToArray();
    }

    /// <summary>
    /// Trim end.
    /// </summary>
    /// <returns>The trim end result.</returns>
    public static List<string> TrimEnd(List<string> sf, params char[] toTrim)
    {
        for (var i = 0; i < sf.Count; i++) sf[i] = sf[i].TrimEnd(toTrim);
        return sf;
    }





    /// <summary>
    /// Start with any in element.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="list">The list.</param>
    /// <param name="_trimBefore">The trim before.</param>
    /// <returns>The start with any in element result.</returns>
    public static List<int> StartWithAnyInElement(string s, List<string> list, bool _trimBefore)
    {
        var result = new List<int>();

        var i = 0;
        foreach (var item in list)
        {
            var item2 = item;
            if (_trimBefore) item2 = item2.Trim();

            if (s.StartsWith(item2)) result.Add(i);

            i++;
        }

        return result;
    }


    /// <summary>
    /// Without diacritic.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The without diacritic result.</returns>
    public static List<string> WithoutDiacritic(List<string> name)
    {
        for (var i = 0; i < name.Count; i++) name[i] = name[i].RemoveDiacritics();
        return name;
    }
}