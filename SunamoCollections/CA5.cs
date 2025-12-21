namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    ///// <summary>
    ///// Direct edit
    ///// </summary>
    ///// <param name="input"></param>
    //public static string GetNumberedList(List<string> input, int startFrom)
    //{
    //    input = input.Where(data => !string.IsNullOrWhiteSpace(data)).ToList();
    //    CA.PrependWithNumbered(input, startFrom);
    //    return SH.JoinNL(input);
    //}
    ///// <summary>
    ///// Direct edit
    ///// </summary>
    ///// <param name="input"></param>
    //private static void PrependWithNumbered(List<string> input, int startFrom)
    //{
    //    var numbered = SunamoBts.BTS.GetNumberedListFromTo(startFrom, input.Count - 1, ") ");
    //    Prepend(numbered, input);
    //}
    public static ABLCA<string, string> CompareListDifferent(List<string> firstList, List<string> secondList)
    {
        var existsIn1 = new List<string>();
        var existsIn2 = new List<string>();
        var index = -1;
        for (var i = secondList.Count - 1; i >= 0; i--)
        {
            var item = secondList[i];
            index = firstList.IndexOf(item);
            if (index == -1)
                existsIn2.Add(item);
        }

        for (var i = firstList.Count - 1; i >= 0; i--)
        {
            var item = firstList[i];
            index = secondList.IndexOf(item);
            if (index == -1)
                existsIn1.Add(item);
        }

        var abl = new ABLCA<string, string>();
        abl.A = existsIn1;
        abl.B = existsIn2;
        return abl;
    }

    /// <summary>
    ///     A2,3 can be null, then no header will be append
    ///     A4 nameOfSolution - main header, also can be null
    /// </summary>
    /// <param name = "alsoFileNames"></param>
    /// <param name = "nameForFirstFolder"></param>
    /// <param name = "nameForSecondFolder"></param>
    /// <param name = "nameOfSolution"></param>
    /// <param name = "files1"></param>
    /// <param name = "files2"></param>
    /// <param name = "inBoth"></param>
    public static string CompareListResult(bool alsoFileNames, string nameForFirstFolder, string nameForSecondFolder, string nameOfSolution, List<string> files1, List<string> files2, List<string> inBoth)
    {
        var files1Count = files1.Count;
        var files2Count = files2.Count;
        string result;
        dynamic textOutput = null; //new TextOutputGenerator();
        var inBothCount = inBoth.Count;
        double totalCount = inBothCount + files2Count;
        var percentCalculator = new PercentCalculator(totalCount);
        if (nameOfSolution != null)
            textOutput.StringBuilder.AppendLine(nameOfSolution);
        textOutput.StringBuilder.AppendLine("Both (" + inBothCount + "-" + percentCalculator.PercentFor(inBothCount, false) + "%):");
        if (alsoFileNames)
            textOutput.List(inBoth);
        if (nameForFirstFolder != null)
            textOutput.StringBuilder.AppendLine(nameForFirstFolder + "(" + files1Count + "-" + percentCalculator.PercentFor(files1Count, true) + "%):");
        if (alsoFileNames)
            textOutput.List(files1);
        if (nameForSecondFolder != null)
            textOutput.StringBuilder.AppendLine(nameForSecondFolder + "(" + files2Count + "-" + percentCalculator.PercentFor(files2Count, true) + "%):");
        if (alsoFileNames)
            textOutput.List(files2);
        textOutput.SingleCharLine('*', 10);
        result = textOutput.ToString();
        return result;
    }

    public static List<string> PaddingByEmptyString(List<string> list, int columns)
    {
        for (var i = list.Count - 1; i < columns - 1; i++)
            list.Add(string.Empty);
        return list;
    }

    public static int CountOfEnding(List<string> list, string value)
    {
        var count = 0;
        for (var i = 0; i < list.Count; i++)
            if (list[i].EndsWith(value))
                count++;
        return count;
    }

    public static bool IsInRange(int from, int to, int index)
    {
        return from >= index && to <= index;
    }

    public static List<string> DummyElementsCollection(int count)
    {
        return Enumerable.Repeat(string.Empty, count).ToList();
    }

    /// <summary>
    ///     Is useful when want to wrap and also join with string. Also last element will have delimiter
    /// </summary>
    /// <param name = "List"></param>
    /// <param name = "wrapWith"></param>
    /// <param name = "delimiter"></param>
    public static List<string> WrapWithAndJoin(IList<string> list, string wrapWith, string delimiter)
    {
        return list.Select(i => wrapWith + i + wrapWith + delimiter).ToList();
    }

    public static int PartsCount(int count, int inPart)
    {
        var total = count / inPart;
        if (count % inPart != 0)
            total++;
        return total;
    }

    public static bool HasFirstItemLength(List<string> list)
    {
        var temp = "";
        if (list.Count > 0)
            temp = list[0].Trim();
        return temp.Length > 0;
    }

    public static List<string> TrimList(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].Trim();
        return list;
    }

    public static string GetTextAfterIfContainsPattern(string input, string ifNotFound, List<string> patterns)
    {
        foreach (var item in patterns)
        {
            var nt = input.IndexOf(item);
            if (nt != -1)
                if (input.Length > item.Length + nt)
                    return input.Substring(nt + item.Length);
        }

        return ifNotFound;
    }

    /// <summary>
    ///     Direct edit
    ///     WithEndSlash - trims backslash and append new
    ///     WithoutEndSlash - ony trims backslash
    /// </summary>
    /// <param name = "paths"></param>
    public static List<string> WithEndSlash(List<string> paths)
    {
        var list = paths;
        if (list == null)
            list = paths.ToList();
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].TrimEnd('\\') + "\\";
        return paths;
    }

    public static List<string> WithoutEndSlash(List<string> paths)
    {
        for (var i = 0; i < paths.Count; i++)
            paths[i] = paths[i].TrimEnd('\\');
        return paths;
    }

    public static List<string> JoinArrayAndArrayString(IList<string> firstList, IList<string> secondList)
    {
        if (firstList != null)
        {
            var data = new List<string>(firstList.Count + secondList.Count);
            data.AddRange(firstList);
            data.AddRange(secondList);
            return data;
        }

        return new List<string>(secondList);
    }

    public static List<string> JoinArrayAndArrayString(IList<string> firstList, params string[] secondArray)
    {
        return JoinArrayAndArrayString(firstList, secondArray.ToList());
    }

    public static void CheckExists(List<bool> results, List<string> itemsToCheck, List<string> referenceList)
    {
        foreach (var item in itemsToCheck)
            results.Add(referenceList.Contains(item));
    }

    public static bool HasOtherValueThanNull(List<string> list)
    {
        foreach (var item in list)
            if (item != null)
                return true;
        return false;
    }

    public static List<string> GetRowOfTable(List<List<string>> table, int rowIndex)
    {
        var result = new List<string>();
        for (var i = 0; i < table.Count; i++)
            result.Add(table[i][rowIndex]);
        return result;
    }

    /// <summary>
    ///     Na rozdíl od metody RemoveStringsEmpty2 NEtrimuje před porovnáním
    /// </summary>
    public static List<string> RemoveStringsByScopeKeepAtLeastOne(List<string> list, FromToCollections fromTo, int keepLines)
    {
        list.RemoveRange((int)fromTo.FromAsLong, (int)fromTo.ToAsLong - (int)fromTo.FromAsLong + 1);
        for (var i = fromTo.FromAsLong; i < fromTo.FromAsLong - 1 + keepLines; i++)
            list.Insert((int)i, "");
        return list;
    }

    /// <summary>
    ///     Return first A2 elements of A1 or A1 if A2 is bigger
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "count"></param>
    public static List<string> ShortCircuit(List<string> list, int count)
    {
        var result = new List<string>();
        if (count > list.Count)
            count = list.Count;
        for (var i = 0; i < count; i++)
            result.Add(list[i]);
        return result;
    }

    public static List<string> ContainsDiacritic(IList<string> items)
    {
        var result = new List<string>(items.Count());
        foreach (var item in items)
            if (item.HasDiacritics())
                result.Add(item);
        return result;
    }
}