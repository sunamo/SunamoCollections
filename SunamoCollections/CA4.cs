namespace SunamoCollections;

/// <summary>
/// Collection utility class - part 4.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Prepends a prefix to each element that does not already start with it. Direct edit.
    /// </summary>
    /// <param name="prefix">The prefix to prepend.</param>
    /// <param name="list">The list to modify.</param>
    /// <returns>The modified list.</returns>
    public static List<string> Prepend(string prefix, List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            if (!list[i].StartsWith(prefix))
                list[i] = prefix + list[i];
        return list;
    }

    /// <summary>
    /// Prepends a prefix to each element. Direct edit.
    /// </summary>
    /// <param name="prefix">The prefix to prepend.</param>
    /// <param name="array">The array of strings to process.</param>
    /// <returns>The modified list.</returns>
    public static List<string> Prepend(string prefix, string[] array)
    {
        return Prepend(prefix, array.ToList());
    }

    /// <summary>
    /// Finds the longest item in the list, optionally splitting by delimiters and taking the first part.
    /// </summary>
    /// <param name="list">The list to search.</param>
    /// <param name="delimiters">Optional delimiters to split each item before measuring length.</param>
    /// <returns>The longest item or its first part after splitting.</returns>
    public static string FindOutLongestItem(List<string> list, params string[] delimiters)
    {
        var longestLength = 0;
        var longest = "";
        foreach (var item in list)
        {
            var processedElement = item;
            if (delimiters.Length != 0)
                processedElement = SHSplit.Split(item, delimiters)[0].Trim();
            if (longestLength < processedElement.Length)
            {
                longest = processedElement;
                longestLength = processedElement.Length;
            }
        }

        return longest;
    }

    /// <summary>
    /// Checks if any of the lists has an odd number of elements.
    /// </summary>
    /// <param name="lists">The lists to check.</param>
    /// <returns>True if any list has an odd count.</returns>
    public static bool IsOdd(params List<int>[] lists)
    {
        foreach (var currentList in lists)
            if (currentList.Count % 2 == 1)
                return true;
        return false;
    }

    /// <summary>
    /// Converts all strings in the list to lowercase. Direct edit.
    /// </summary>
    /// <param name="list">The list to convert.</param>
    /// <returns>The list with lowercased elements.</returns>
    public static List<string> ToLower(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].ToLower();
        return list;
    }

    /// <summary>
    /// Removes elements that contain the specified pattern. Direct edit.
    /// </summary>
    /// <param name="list">The list to filter.</param>
    /// <param name="pattern">The pattern to match.</param>
    /// <param name="isWildcard">Whether to use wildcard matching.</param>
    /// <param name="wildcardIsMatch">The wildcard matching function.</param>
    public static void RemoveWhichContains(List<string> list, string pattern, bool isWildcard, Func<string, string, bool> wildcardIsMatch)
    {
        if (isWildcard)
        {
            for (var i = list.Count - 1; i >= 0; i--)
                if (wildcardIsMatch(list[i], pattern))
                    list.RemoveAt(i);
        }
        else
        {
            for (var i = list.Count - 1; i >= 0; i--)
                if (list[i].Contains(pattern))
                    list.RemoveAt(i);
        }
    }

    /// <summary>
    /// Converts a single-element collection to a multi-element list if it contains a nested list.
    /// </summary>
    /// <param name="list">The list to process.</param>
    /// <returns>The expanded list, or the original cast to IList of object.</returns>
    public static IList<object>? OneElementCollectionToMulti(IList list)
    {
        if (list.Count() == 1)
        {
            var first = list.FirstOrNull();
            var enumerable = first as IList<object>;
            if (enumerable != null)
                return enumerable;
            return ToListMoreObject(first!);
        }

        return list as IList<object>;
    }

    /// <summary>
    /// Removes empty strings from the list. Does not trim before comparing. Direct edit.
    /// </summary>
    /// <param name="list">The list to filter.</param>
    /// <returns>The filtered list.</returns>
    public static List<string> RemoveStringsEmpty(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (list[i] == string.Empty)
                list.RemoveAt(i);
        return list;
    }

    /// <summary>
    /// Prepends a prefix to each element in the list.
    /// </summary>
    /// <param name="prefix">The prefix to prepend.</param>
    /// <param name="list">The list to modify.</param>
    /// <returns>The modified list.</returns>
    public static List<string> PostfixIfNotEnding(string prefix, List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = prefix + list[i];
        return list;
    }

    /// <summary>
    /// Parses a delimited string into a list of integers.
    /// </summary>
    /// <param name="text">The string to parse.</param>
    /// <param name="delimiter">The delimiter separating the numbers.</param>
    /// <returns>A list of parsed integers.</returns>
    public static List<int> ParseInt(string text, string delimiter)
    {
        var parts = SHSplit.Split(text, delimiter);
        var numbers = new List<int>(parts.Count);
        foreach (var item in parts)
            numbers.Add(int.Parse(item));
        return numbers;
    }

    /// <summary>
    /// Splits a list into groups separated by a delimiter element.
    /// </summary>
    /// <param name="list">The list to split.</param>
    /// <param name="delimiter">The delimiter element that separates groups.</param>
    /// <returns>A list of groups.</returns>
    public static List<List<string>> Split(List<string> list, string delimiter)
    {
        var result = new List<List<string>>();
        var currentGroup = new List<string>();
        foreach (var item in list)
            if (item == delimiter)
            {
                result.Add(currentGroup);
                currentGroup.Clear();
            }

        return result;
    }

    /// <summary>
    /// Extracts the first word from each line of the text.
    /// </summary>
    /// <param name="text">The multi-line text to process.</param>
    /// <returns>A string with only the first word from each line.</returns>
    public static string GetFirstWordOfList(string text)
    {
        var stringBuilder = new StringBuilder();
        var lines = text.Split(new[] { text.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.None).ToList();
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
                stringBuilder.AppendLine(trimmedLine.Split(whiteSpaceChars.WhiteSpaceChars!.ToArray())[0]);
            }
        }

        return stringBuilder.ToString();
    }

    /// <summary>
    /// Trims each element to keep only the first word (before any special character).
    /// </summary>
    /// <param name="list">The list to process.</param>
    public static void KeepOnlyWordsToFirstSpecialChars(List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = SHParts.RemoveAfterFirstFunc(list[i], CharHelper.IsSpecial, []);
        }
    }

    /// <summary>
    /// Returns a subset of lines from the list by index range.
    /// </summary>
    /// <param name="list">The source list.</param>
    /// <param name="from">The start index.</param>
    /// <param name="to">The end index (inclusive).</param>
    /// <param name="isIndexedFrom1">Whether the indices are 1-based.</param>
    /// <returns>The selected lines.</returns>
    public static List<string> LinesIndexes(List<string> list, int from, int to, bool isIndexedFrom1)
    {
        if (isIndexedFrom1)
        {
            from--;
            to--;
        }

        var selectedLines = new List<string>();
        for (var i = from; i < to + 1; i++)
            selectedLines.Add(list[i]);
        return selectedLines;
    }

    /// <summary>
    /// Converts a 2D boolean array to a jagged list of integer lists (true=1, false=0).
    /// </summary>
    /// <param name="array">The 2D boolean array.</param>
    /// <returns>A jagged list of integer values.</returns>
    public static List<List<int>> ToJagged(bool[,] array)
    {
        var result = new List<List<int>>();
        for (var i = 0; i < array.GetLength(0); i++)
        {
            var row = new List<int>();
            for (var columnIndex = 0; columnIndex < array.GetLength(1); columnIndex++)
                row.Add(array[i, columnIndex] ? 1 : 0);
            result.Add(row);
        }

        return result;
    }
}
