namespace SunamoCollections;

public partial class CA
{

    /// <summary>
    /// Postfix if not ending.
    /// </summary>
    /// <param name="pre">The pre.</param>
    /// <param name="l">The l.</param>
    /// <returns>The postfix if not ending result.</returns>
    public static List<string> PostfixIfNotEnding(string pre, List<string> l)
    {
        for (var i = 0; i < l.Count; i++) l[i] = pre + l[i];
        return l;
    }

    /// <summary>
    /// Parse int.
    /// </summary>
    /// <param name="v">The v.</param>
    /// <param name="comma">The comma.</param>
    /// <returns>The parse int result.</returns>
    public static List<int> ParseInt(string v, string comma)
    {
        var s = SHSplit.Split(v, comma);
        var n = new List<int>(s.Count);
        foreach (var item in s) n.Add(int.Parse(item));

        return n;
    }

    /// <summary>
    /// Split.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="determining">The determining.</param>
    /// <returns>The split result.</returns>
    public static List<List<string>> Split(List<string> s, string determining)
    {
        var ls = new List<List<string>>();
        var actual = new List<string>();
        foreach (var item in s)
            if (item == determining)
            {
                ls.Add(actual);
                actual.Clear();
            }

        return ls;
    }

    /// <summary>
    /// Get first word of list.
    /// </summary>
    /// <param name="t2">The t 2.</param>
    /// <returns>The get first word of list result.</returns>
    public static string GetFirstWordOfList(string t2)

    {
        var sb = new StringBuilder();

        var text = t2.Split(new[] { t2.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.None)
            .ToList(); //SHGetLines.GetLines(t2);
        foreach (var item in text)
        {
            var t = item.Trim();

            if (t.EndsWith(":"))
                sb.AppendLine(item);
            else if (t == "")
                sb.AppendLine(t);
            else
            {
                WhitespaceCharService whitespaceChars = new WhitespaceCharService();
                sb.AppendLine(t.Split(whitespaceChars.WhiteSpaceChars.ToArray())[0]);
            }
        }

        return sb.ToString();
    }





    /// <summary>
    /// Keep only words to first special chars.
    /// </summary>
    /// <param name="l">The l.</param>
    public static void KeepOnlyWordsToFirstSpecialChars(List<string> l)
    {
        for (int i = 0; i < l.Count; i++)
        {
            l[i] = SHParts.RemoveAfterFirstFunc(l[i], CharHelper.IsSpecial, []);
        }
    }


    /// <summary>
    /// Lines indexes.
    /// </summary>
    /// <param name="cOnlyNamesBy10">The c only names by 10.</param>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <param name="indexedFrom1">The indexed from 1.</param>
    /// <returns>The lines indexes result.</returns>
    public static List<string> LinesIndexes(List<string> cOnlyNamesBy10, int from, int to, bool indexedFrom1)
    {
        if (indexedFrom1)
        {
            from--;
            to--;
        }

        var s = new List<string>();

        for (var i = from; i < to + 1; i++) s.Add(cOnlyNamesBy10[i]);

        return s;
    }

    // In order to convert any 2d array to jagged one
    // let's use a generic implementation
    /// <summary>
    /// To jagged.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <returns>The to jagged result.</returns>
    public static List<List<int>> ToJagged(bool[,] value)
    {
        var result = new List<List<int>>();
        for (var i = 0; i < value.GetLength(0); i++)
        {
            var ca = new List<int>();
            for (var y = 0; y < value.GetLength(1); y++) ca.Add(value[i, y] ? 1 : 0);
            result.Add(ca);
        }

        return result;
    }


    ///// <summary>
    ///// Direct edit
    ///// </summary>
    ///// <param name="input"></param>
    ///// <summary>
    ///// Direct edit
    ///// </summary>
    ///// <param name="input"></param>
    /// <summary>
    /// Compares two lists and returns the differing elements.
    /// </summary>
    /// <param name="c1">The first list.</param>
    /// <param name="c2">The second list.</param>
    /// <returns>The comparison result.</returns>
    public static ABLCA<string> CompareListDifferent(List<string> c1, List<string> c2)
    {
        var existsIn1 = new List<string>();
        var existsIn2 = new List<string>();
        var dex = -1;
        for (var i = c2.Count - 1; i >= 0; i--)
        {
            var item = c2[i];
            dex = c1.IndexOf(item);
            if (dex == -1) existsIn2.Add(item);
        }

        for (var i = c1.Count - 1; i >= 0; i--)
        {
            var item = c1[i];
            dex = c2.IndexOf(item);
            if (dex == -1) existsIn1.Add(item);
        }

        var abl = new ABLCA<string>();
        abl.FirstGroup = existsIn1;
        abl.SecondGroup = existsIn2;
        return abl;
    }


    /// <summary>
    /// Compare list result.
    /// </summary>
    /// <param name="alsoFileNames">The also file names.</param>
    /// <param name="nameForFirstFolder">The name for first folder.</param>
    /// <param name="nameForSecondFolder">The name for second folder.</param>
    /// <param name="nameOfSolution">The name of solution.</param>
    /// <param name="files1">The files 1.</param>
    /// <param name="files2">The files 2.</param>
    /// <param name="inBoth">The in both.</param>
    /// <returns>The compare list result result.</returns>
    public static string CompareListResult(bool alsoFileNames, string nameForFirstFolder, string nameForSecondFolder,
        string nameOfSolution, List<string> files1, List<string> files2, List<string> inBoth)
    {
        var files1Count = files1.Count;
        var files2Count = files2.Count;
        string result;

        dynamic textOutput = null; //new TextOutputGenerator();
        var inBothCount = inBoth.Count;
        double sumBothPlusManaged = inBothCount + files2Count;
        var percentCalculator = new PercentCalculator(sumBothPlusManaged);
        if (nameOfSolution != null) textOutput.sb.AppendLine(nameOfSolution);
        textOutput.sb.AppendLine("Both (" + inBothCount + "-" +
                                 percentCalculator.PercentFor(inBothCount, false) + "%):");
        if (alsoFileNames) textOutput.List(inBoth);
        if (nameForFirstFolder != null)
            textOutput.sb.AppendLine(nameForFirstFolder + "(" + files1Count + "-" +
                                     percentCalculator.PercentFor(files1Count, true) + "%):");
        if (alsoFileNames) textOutput.List(files1);
        if (nameForSecondFolder != null)
            textOutput.sb.AppendLine(nameForSecondFolder + "(" + files2Count + "-" +
                                     percentCalculator.PercentFor(files2Count, true) + "%):");
        if (alsoFileNames) textOutput.List(files2);
        textOutput.SingleCharLine('*', 10);
        result = textOutput.ToString();
        return result;
    }


    /// <summary>
    /// Padding by empty string.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="columns">The columns.</param>
    /// <returns>The padding by empty string result.</returns>
    public static List<string> PaddingByEmptyString(List<string> list, int columns)
    {
        for (var i = list.Count - 1; i < columns - 1; i++) list.Add(string.Empty);
        return list;
    }

    /// <summary>
    /// Count of ending.
    /// </summary>
    /// <param name="winrarFiles">The winrar files.</param>
    /// <param name="v">The v.</param>
    /// <returns>The count of ending result.</returns>
    public static int CountOfEnding(List<string> winrarFiles, string v)
    {
        var count = 0;
        for (var i = 0; i < winrarFiles.Count; i++)
            if (winrarFiles[i].EndsWith(v))
                count++;
        return count;
    }

    /// <summary>
    /// Is in range.
    /// </summary>
    /// <param name="od">The od.</param>
    /// <param name="to">The to.</param>
    /// <param name="index">The index.</param>
    /// <returns>The is in range result.</returns>
    public static bool IsInRange(int od, int to, int index)
    {
        return od >= index && to <= index;
    }

    /// <summary>
    /// Dummy elements collection.
    /// </summary>
    /// <param name="count">The count.</param>
    /// <returns>The dummy elements collection result.</returns>
    public static List<string> DummyElementsCollection(int count)
    {
        return Enumerable.Repeat(string.Empty, count).ToList();
    }


    /// <summary>
    /// Wrap with and join.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="wrapWith">The wrap with.</param>
    /// <param name="delimiter">The delimiter.</param>
    /// <returns>The wrap with and join result.</returns>
    public static List<string> WrapWithAndJoin(IList<string> list, string wrapWith, string delimiter)
    {
        return list.Select(i => wrapWith + i + wrapWith + delimiter).ToList();
    }

    /// <summary>
    /// Parts count.
    /// </summary>
    /// <param name="i">The i.</param>
    /// <returns>The parts count result.</returns>
    public static int PartsCount(int count, int inPart)
    {
        var total = count / inPart;
        if (count % inPart != 0) total++;
        return total;
    }

    /// <summary>
    /// Has first item length.
    /// </summary>
    /// <param name="notContains">The not contains.</param>
    /// <returns>The has first item length result.</returns>
    public static bool HasFirstItemLength(List<string> notContains)
    {
        var t = "";
        if (notContains.Count > 0) t = notContains[0].Trim();
        return t.Length > 0;
    }

    /// <summary>
    /// Trim list.
    /// </summary>
    /// <param name="c">The c.</param>
    /// <returns>The trim list result.</returns>
    public static List<string> TrimList(List<string> c)
    {
        for (var i = 0; i < c.Count; i++) c[i] = c[i].Trim();
        return c;
    }

    /// <summary>
    /// Get text after if contains pattern.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="ifNotFound">The if not found.</param>
    /// <param name="uriPatterns">The uri patterns.</param>
    /// <returns>The get text after if contains pattern result.</returns>
    public static string GetTextAfterIfContainsPattern(string input, string ifNotFound, List<string> uriPatterns)
    {
        foreach (var item in uriPatterns)
        {
            var nt = input.IndexOf(item);
            if (nt != -1)
                if (input.Length > item.Length + nt)
                    return input.Substring(nt + item.Length);
        }

        return ifNotFound;
    }

    /// <summary>
    /// With end slash.
    /// </summary>
    /// <param name="folders">The folders.</param>
    /// <returns>The with end slash result.</returns>
    public static List<string> WithEndSlash(List<string> folders)
    {
        var list = folders;
        if (list == null) list = folders.ToList();
        for (var i = 0; i < list.Count; i++) list[i] = list[i].TrimEnd('\\') + "\\";
        return folders;
    }

    /// <summary>
    /// Without end slash.
    /// </summary>
    /// <param name="folders">The folders.</param>
    /// <returns>The without end slash result.</returns>
    public static List<string> WithoutEndSlash(List<string> folders)
    {
        for (var i = 0; i < folders.Count; i++) folders[i] = folders[i].TrimEnd('\\');
        return folders;
    }


    /// <summary>
    /// Join array and array string.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="p">The p.</param>
    /// <returns>The join array and array string result.</returns>
    public static List<string> JoinArrayAndArrayString(IList<string> a, IList<string> p)
    {
        if (a != null)
        {
            var d = new List<string>(a.Count + p.Count);
            d.AddRange(a);
            d.AddRange(p);
            return d;
        }

        return new List<string>(p);
    }

    /// <summary>
    /// Join array and array string.
    /// </summary>
    /// <typeparam name="string">The type string.</typeparam>
    /// <param name="p">The p.</param>
    /// <returns>The join array and array string result.</returns>
    public static List<string> JoinArrayAndArrayString(IList<string> a, params string[] p)
    {
        return JoinArrayAndArrayString(a, p.ToList());
    }

    /// <summary>
    /// Check exists.
    /// </summary>
    /// <param name="a">The a.</param>
    /// <param name="p.ToList()">The p to list.</param>
    /// <returns>The check exists result.</returns>
    public static void CheckExists(List<bool> photoFiles, List<string> allFilesRelative, List<string> value)
    {
        foreach (var item in allFilesRelative) photoFiles.Add(value.Contains(item));
    }

    /// <summary>
    /// Initializes a new instance of the has other value than null class.
    /// </summary>
    /// <param name="allFilesRelative">The all files relative.</param>
    public static bool HasOtherValueThanNull(List<string> idPhotos)
    {
        foreach (var item in idPhotos)
            if (item != null)
                return true;
        return false;
    }

    /// <summary>
    /// Get row of table.
    /// </summary>
    /// <param name="_dataBinding">The data binding.</param>
    /// <param name="i2">The i 2.</param>
    /// <returns>The get row of table result.</returns>
    public static List<string> GetRowOfTable(List<List<string>> _dataBinding, int i2)
    {
        var vr = new List<string>();
        for (var i = 0; i < _dataBinding.Count; i++) vr.Add(_dataBinding[i][i2]);
        return vr;
    }

    /// <summary>
    /// Remove strings by scope keep at least one.
    /// </summary>
    /// <param name="mySites">The my sites.</param>
    /// <param name="fromTo">The from to.</param>
    /// <param name="keepLines">The keep lines.</param>
    /// <returns>The remove strings by scope keep at least one result.</returns>
    public static List<string> RemoveStringsByScopeKeepAtLeastOne(List<string> mySites, FromToCollections fromTo,
        int keepLines)
    {
        mySites.RemoveRange((int)fromTo.From, (int)fromTo.To - (int)fromTo.From + 1);
        for (var i = fromTo.From; i < fromTo.From - 1 + keepLines; i++) mySites.Insert((int)i, "");
        return mySites;
    }

    /// <summary>
    /// Short circuit.
    /// </summary>
    /// <param name="proj">The proj.</param>
    /// <param name="p">The p.</param>
    /// <returns>The short circuit result.</returns>
    public static List<string> ShortCircuit(List<string> proj, int p)
    {
        var result = new List<string>();
        if (p > proj.Count) p = proj.Count;
        for (var i = 0; i < p; i++) result.Add(proj[i]);
        return result;
    }
}