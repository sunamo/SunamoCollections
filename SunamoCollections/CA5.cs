namespace SunamoCollections;

/// <summary>
/// Collection utility class - part 5.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Compares two lists and returns elements that exist only in the first or only in the second list.
    /// </summary>
    /// <param name="firstList">The first list to compare.</param>
    /// <param name="secondList">The second list to compare.</param>
    /// <returns>An ABLCA where A contains elements only in the first list and B contains elements only in the second list.</returns>
    public static ABLCA<string, string> CompareListDifferent(List<string> firstList, List<string> secondList)
    {
        var onlyInFirst = new List<string>();
        var onlyInSecond = new List<string>();
        var index = -1;
        for (var i = secondList.Count - 1; i >= 0; i--)
        {
            var item = secondList[i];
            index = firstList.IndexOf(item);
            if (index == -1)
                onlyInSecond.Add(item);
        }

        for (var i = firstList.Count - 1; i >= 0; i--)
        {
            var item = firstList[i];
            index = secondList.IndexOf(item);
            if (index == -1)
                onlyInFirst.Add(item);
        }

        var result = new ABLCA<string, string>();
        result.A = onlyInFirst;
        result.B = onlyInSecond;
        return result;
    }

    /// <summary>
    /// Generates a formatted comparison report of two lists.
    /// </summary>
    /// <param name="isIncludingFileNames">Whether to include individual file names in the output.</param>
    /// <param name="nameForFirstFolder">Header name for the first folder (can be null).</param>
    /// <param name="nameForSecondFolder">Header name for the second folder (can be null).</param>
    /// <param name="nameOfSolution">Main header for the solution (can be null).</param>
    /// <param name="firstFolderFiles">Files found only in the first folder.</param>
    /// <param name="secondFolderFiles">Files found only in the second folder.</param>
    /// <param name="inBoth">Files found in both folders.</param>
    /// <returns>The formatted comparison report.</returns>
    public static string CompareListResult(bool isIncludingFileNames, string nameForFirstFolder, string nameForSecondFolder, string nameOfSolution, List<string> firstFolderFiles, List<string> secondFolderFiles, List<string> inBoth)
    {
        var firstFolderCount = firstFolderFiles.Count;
        var secondFolderCount = secondFolderFiles.Count;
        string result;
        dynamic textOutput = null!;
        var inBothCount = inBoth.Count;
        double totalCount = inBothCount + secondFolderCount;
        var percentCalculator = new PercentCalculator(totalCount);
        if (nameOfSolution != null)
            textOutput.StringBuilder.AppendLine(nameOfSolution);
        textOutput.StringBuilder.AppendLine("Both (" + inBothCount + "-" + percentCalculator.PercentFor(inBothCount, false) + "%):");
        if (isIncludingFileNames)
            textOutput.List(inBoth);
        if (nameForFirstFolder != null)
            textOutput.StringBuilder.AppendLine(nameForFirstFolder + "(" + firstFolderCount + "-" + percentCalculator.PercentFor(firstFolderCount, true) + "%):");
        if (isIncludingFileNames)
            textOutput.List(firstFolderFiles);
        if (nameForSecondFolder != null)
            textOutput.StringBuilder.AppendLine(nameForSecondFolder + "(" + secondFolderCount + "-" + percentCalculator.PercentFor(secondFolderCount, true) + "%):");
        if (isIncludingFileNames)
            textOutput.List(secondFolderFiles);
        textOutput.SingleCharLine('*', 10);
        result = textOutput.ToString();
        return result;
    }

    /// <summary>
    /// Pads a list with empty strings up to the specified target count.
    /// </summary>
    /// <param name="list">The list to pad.</param>
    /// <param name="targetCount">The target number of elements.</param>
    /// <returns>The padded list.</returns>
    public static List<string> PaddingByEmptyString(List<string> list, int targetCount)
    {
        for (var i = list.Count - 1; i < targetCount - 1; i++)
            list.Add(string.Empty);
        return list;
    }

    /// <summary>
    /// Counts elements in the list that end with the specified value.
    /// </summary>
    /// <param name="list">The list to check.</param>
    /// <param name="value">The suffix to match.</param>
    /// <returns>The number of matching elements.</returns>
    public static int CountOfEnding(List<string> list, string value)
    {
        var count = 0;
        for (var i = 0; i < list.Count; i++)
            if (list[i].EndsWith(value))
                count++;
        return count;
    }

    /// <summary>
    /// Checks if an index is within the specified range.
    /// </summary>
    /// <param name="from">The start of the range.</param>
    /// <param name="to">The end of the range.</param>
    /// <param name="index">The index to check.</param>
    /// <returns>True if the index is within range.</returns>
    public static bool IsInRange(int from, int to, int index)
    {
        return from >= index && to <= index;
    }

    /// <summary>
    /// Creates a list of empty strings with the specified count.
    /// </summary>
    /// <param name="count">The number of empty strings.</param>
    /// <returns>A list of empty strings.</returns>
    public static List<string> DummyElementsCollection(int count)
    {
        return Enumerable.Repeat(string.Empty, count).ToList();
    }

    /// <summary>
    /// Wraps each element and appends a delimiter. The last element will also have the delimiter.
    /// </summary>
    /// <param name="list">The list to wrap.</param>
    /// <param name="wrapWith">The wrapper string.</param>
    /// <param name="delimiter">The delimiter to append after each wrapped element.</param>
    /// <returns>A new list of wrapped and delimited strings.</returns>
    public static List<string> WrapWithAndJoin(IList<string> list, string wrapWith, string delimiter)
    {
        return list.Select(element => wrapWith + element + wrapWith + delimiter).ToList();
    }

    /// <summary>
    /// Calculates how many parts are needed to divide a count into groups of specified size.
    /// </summary>
    /// <param name="count">The total count.</param>
    /// <param name="inPart">The size of each part.</param>
    /// <returns>The number of parts needed.</returns>
    public static int PartsCount(int count, int inPart)
    {
        var total = count / inPart;
        if (count % inPart != 0)
            total++;
        return total;
    }

    /// <summary>
    /// Checks if the first item in the list has a non-empty trimmed value.
    /// </summary>
    /// <param name="list">The list to check.</param>
    /// <returns>True if the first item has content after trimming.</returns>
    public static bool HasFirstItemLength(List<string> list)
    {
        var firstItemTrimmed = "";
        if (list.Count > 0)
            firstItemTrimmed = list[0].Trim();
        return firstItemTrimmed.Length > 0;
    }

    /// <summary>
    /// Trims all strings in the list. Direct edit.
    /// </summary>
    /// <param name="list">The list to trim.</param>
    /// <returns>The trimmed list.</returns>
    public static List<string> TrimList(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].Trim();
        return list;
    }

    /// <summary>
    /// Returns the text after the first occurrence of any matching pattern, or a default value if not found.
    /// </summary>
    /// <param name="text">The text to search.</param>
    /// <param name="ifNotFound">The value to return if no pattern is found.</param>
    /// <param name="patterns">The list of patterns to match.</param>
    /// <returns>The text after the matched pattern, or the ifNotFound value.</returns>
    public static string GetTextAfterIfContainsPattern(string text, string ifNotFound, List<string> patterns)
    {
        foreach (var item in patterns)
        {
            var patternIndex = text.IndexOf(item);
            if (patternIndex != -1)
                if (text.Length > item.Length + patternIndex)
                    return text.Substring(patternIndex + item.Length);
        }

        return ifNotFound;
    }

    /// <summary>
    /// Ensures each path ends with a backslash. Direct edit.
    /// </summary>
    /// <param name="list">The list of paths.</param>
    /// <returns>The list with trailing backslashes.</returns>
    public static List<string> WithEndSlash(List<string> list)
    {
        if (list == null)
            list = new List<string>();
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].TrimEnd('\\') + "\\";
        return list;
    }

    /// <summary>
    /// Removes trailing backslashes from each path.
    /// </summary>
    /// <param name="list">The list of paths.</param>
    /// <returns>The list without trailing backslashes.</returns>
    public static List<string> WithoutEndSlash(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].TrimEnd('\\');
        return list;
    }

    /// <summary>
    /// Joins two string lists into a single list.
    /// </summary>
    /// <param name="firstList">The first list (can be null).</param>
    /// <param name="secondList">The second list.</param>
    /// <returns>A combined list.</returns>
    public static List<string> JoinArrayAndArrayString(IList<string> firstList, IList<string> secondList)
    {
        if (firstList != null)
        {
            var combined = new List<string>(firstList.Count + secondList.Count);
            combined.AddRange(firstList);
            combined.AddRange(secondList);
            return combined;
        }

        return new List<string>(secondList);
    }

    /// <summary>
    /// Joins a string list and a string array into a single list.
    /// </summary>
    /// <param name="firstList">The first list (can be null).</param>
    /// <param name="secondArray">The second array of strings.</param>
    /// <returns>A combined list.</returns>
    public static List<string> JoinArrayAndArrayString(IList<string> firstList, params string[] secondArray)
    {
        return JoinArrayAndArrayString(firstList, secondArray.ToList());
    }

    /// <summary>
    /// Checks which items from itemsToCheck exist in the reference list and stores results.
    /// </summary>
    /// <param name="results">The list to store boolean results.</param>
    /// <param name="list">The items to check.</param>
    /// <param name="referenceList">The reference list to check against.</param>
    public static void CheckExists(List<bool> results, List<string> list, List<string> referenceList)
    {
        foreach (var item in list)
            results.Add(referenceList.Contains(item));
    }

    /// <summary>
    /// Checks if the list has any non-null value.
    /// </summary>
    /// <param name="list">The list to check.</param>
    /// <returns>True if any element is not null.</returns>
    public static bool HasOtherValueThanNull(List<string> list)
    {
        foreach (var item in list)
            if (item != null)
                return true;
        return false;
    }

    /// <summary>
    /// Gets a column of values from a table (list of lists) at the specified row index.
    /// </summary>
    /// <param name="table">The table (list of columns).</param>
    /// <param name="rowIndex">The row index to extract.</param>
    /// <returns>A list of values from each column at the specified row.</returns>
    public static List<string> GetRowOfTable(List<List<string>> table, int rowIndex)
    {
        var result = new List<string>();
        for (var i = 0; i < table.Count; i++)
            result.Add(table[i][rowIndex]);
        return result;
    }

    /// <summary>
    /// Removes strings by a scope range and inserts empty lines to keep at least the specified number of lines. Does not trim before comparing.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="fromTo">The from-to range to remove.</param>
    /// <param name="keepLines">The minimum number of lines to keep in the removed range.</param>
    /// <returns>The modified list.</returns>
    public static List<string> RemoveStringsByScopeKeepAtLeastOne(List<string> list, FromToCollections fromTo, int keepLines)
    {
        list.RemoveRange((int)fromTo.FromAsLong, (int)fromTo.ToAsLong - (int)fromTo.FromAsLong + 1);
        for (var i = fromTo.FromAsLong; i < fromTo.FromAsLong - 1 + keepLines; i++)
            list.Insert((int)i, "");
        return list;
    }

    /// <summary>
    /// Returns the first specified number of elements from the list, or all elements if the count exceeds the list size.
    /// </summary>
    /// <param name="list">The source list.</param>
    /// <param name="count">The maximum number of elements to return.</param>
    /// <returns>A list containing at most the specified number of elements.</returns>
    public static List<string> ShortCircuit(List<string> list, int count)
    {
        var result = new List<string>();
        if (count > list.Count)
            count = list.Count;
        for (var i = 0; i < count; i++)
            result.Add(list[i]);
        return result;
    }

    /// <summary>
    /// Returns elements from the list that contain diacritics.
    /// </summary>
    /// <param name="list">The list to filter.</param>
    /// <returns>A list of elements containing diacritics.</returns>
    public static List<string> ContainsDiacritic(IList<string> list)
    {
        var result = new List<string>(list.Count());
        foreach (var item in list)
            if (item.HasDiacritics())
                result.Add(item);
        return result;
    }
}
