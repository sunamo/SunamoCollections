namespace SunamoCollections;

/// <summary>
/// Collection utility class - part 1.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Converts a wrapped array to a flat array if it contains a single List element.
    /// </summary>
    /// <param name="array">The array to unwrap.</param>
    /// <returns>The unwrapped array, or the original if not wrapped.</returns>
    [ObjectParamsObsoleteAttribute]
    public static object[] ConvertListStringWrappedInArray(object[] array)
    {
        if (IsListStringWrappedInArray(array))
        {
            List<object>? result = null;
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

    /// <summary>
    /// Checks if a string starts with '!' (negation) and returns the negation flag with the cleaned string.
    /// </summary>
    /// <param name="text">The string to check for negation prefix.</param>
    /// <returns>A tuple indicating whether negation was found and the cleaned string.</returns>
    public static (bool, string) IsNegationTuple(string text)
    {
        if (text[0] == '!')
        {
            text = text.Substring(1);
            return (true, text);
        }

        return (false, text);
    }

    /// <summary>
    /// Removes elements starting with the specified prefix. Direct edit.
    /// Prefix can start with '!' for negation (keeps only elements starting with the value).
    /// </summary>
    /// <param name="start">The prefix to match (or '!' + prefix for negation).</param>
    /// <param name="list">The list to filter.</param>
    /// <param name="args">Optional arguments for trimming and case sensitivity.</param>
    public static void RemoveStartingWith(string start, List<string> list, RemoveStartingWithArgsCA? args = null)
    {
        if (args == null)
            args = new RemoveStartingWithArgsCA();
        var (isNegated, extractedStart) = IsNegationTuple(start);
        start = extractedStart;
        for (var i = list.Count - 1; i >= 0; i--)
        {
            var currentElement = list[i];
            if (args.TrimBeforeFinding)
                currentElement = currentElement.Trim();
            if (isNegated)
            {
                if (!StartingWith(currentElement, start, args.CaseSensitive))
                    list.RemoveAt(i);
            }
            else
            {
                if (StartingWith(currentElement, start, args.CaseSensitive))
                    list.RemoveAt(i);
            }
        }
    }

    /// <summary>
    /// Filters a list to keep only elements starting with the specified prefix. Direct edit.
    /// </summary>
    /// <param name="prefix">The prefix to match.</param>
    /// <param name="list">The list to filter.</param>
    /// <returns>The filtered list.</returns>
    public static List<string> StartingWith(string prefix, List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (!list[i].StartsWith(prefix))
                list.RemoveAt(i);
        return list;
    }

    /// <summary>
    /// Checks if a string starts with the specified prefix.
    /// </summary>
    /// <param name="text">The string to check.</param>
    /// <param name="start">The prefix to look for.</param>
    /// <param name="isCaseSensitive">Whether the comparison is case-sensitive.</param>
    /// <returns>True if the string starts with the prefix.</returns>
    public static bool StartingWith(string text, string start, bool isCaseSensitive)
    {
        if (isCaseSensitive)
            return text.StartsWith(start);
        return text.ToLower().StartsWith(start.ToLower());
    }

    /// <summary>
    /// Removes empty strings from the list after trimming each element. Direct edit.
    /// </summary>
    /// <param name="list">The list to filter.</param>
    /// <returns>The filtered list.</returns>
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
    /// Replaces all occurrences of a substring in each element. Direct edit.
    /// </summary>
    /// <param name="list">The list of strings to process.</param>
    /// <param name="what">The substring to find.</param>
    /// <param name="replacement">The replacement string.</param>
    public static void Replace(List<string> list, string what, string replacement)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = Replace(list[i], what, replacement);
    }

    /// <summary>
    /// Converts an IEnumerable to a List of strings by calling ToString() on each element.
    /// </summary>
    /// <param name="enumerable">The enumerable to convert.</param>
    /// <returns>A list of string representations.</returns>
    public static List<string> ToListStringIEnumerable2(IEnumerable enumerable)
    {
        var result = new List<string>();
        foreach (var item in enumerable)
            if (item == null)
                result.Add("(null)");
            else
                result.Add(item.ToString()!);
        return result;
    }

    /// <summary>
    /// Counts non-whitespace lines in the list.
    /// </summary>
    /// <param name="list">The list of strings to check.</param>
    /// <returns>The number of non-whitespace lines.</returns>
    public static int AllNonWhitespaceLines(List<string> list)
    {
        var nonEmptyLines = 0;
        for (var i = 0; i < list.Count; i++)
            if (list[i].Trim() != string.Empty)
                nonEmptyLines++;
        return nonEmptyLines;
    }

    /// <summary>
    /// Removes leading and trailing empty/whitespace lines from the list.
    /// </summary>
    /// <param name="list">The list to trim.</param>
    /// <returns>A new list without leading/trailing empty lines.</returns>
    public static List<string> RemoveStringsEmptyFromBeginStart(List<string> list)
    {
        int start = 0, end = list.Count - 1;
        while (start < end && string.IsNullOrWhiteSpace(list[start]))
            start++;
        while (end >= start && string.IsNullOrWhiteSpace(list[end]))
            end--;
        var result = list.Skip(start).Take(end - start + 1).ToList();
        return result;
    }

    /// <summary>
    /// Removes lines at the specified indices from the list.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="removeList">The list of indices to remove.</param>
    public static void RemoveLines(List<string> list, List<int> removeList)
    {
        removeList.Sort();
        for (var i = removeList.Count - 1; i >= 0; i--)
        {
            var index = removeList[i];
            list.RemoveAt(index);
        }
    }

    /// <summary>
    /// Removes all elements from the first list that exist in the second list.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="what">The elements to remove.</param>
    public static void Remove(List<string> list, List<string> what)
    {
        foreach (var item in what)
            list.Remove(item);
    }

    /// <summary>
    /// Appends a suffix to each element in the list. Direct edit.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="value">The suffix to append.</param>
    public static void AddSuffix(List<string> list, string value)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i] + value;
    }

    /// <summary>
    /// Creates a new list with reserved capacity and copies elements from the source list.
    /// </summary>
    /// <param name="reserveCapacity">The additional capacity to reserve.</param>
    /// <param name="list">The source list to copy from.</param>
    /// <returns>A new list with reserved capacity.</returns>
    public static List<string> CreateListStringWithReserve(int reserveCapacity, IList<string> list)
    {
        var result = new List<string>(reserveCapacity + list.Count());
        result.AddRange(list);
        return result;
    }

    /// <summary>
    /// Converts a collection of strings to a list of chars by taking the first character of each string.
    /// </summary>
    /// <param name="collection">The collection to convert.</param>
    /// <returns>A list of first characters.</returns>
    public static List<char> ToListChar(ICollection<string> collection)
    {
        var result = new List<char>(collection.Count);
        foreach (var item in collection)
            result.Add(item[0]);
        return result;
    }

    /// <summary>
    /// Checks whether a list contains duplicate elements.
    /// </summary>
    /// <param name="list">The list to check.</param>
    /// <returns>True if duplicates exist.</returns>
    public static bool HasDuplicates(List<string> list)
    {
        var distinctList = list.Distinct().ToList();
        if (distinctList.Count != list.Count)
            return true;
        return false;
    }

    /// <summary>
    /// Removes one level of indentation (tab or single space) from each line. Direct edit.
    /// </summary>
    /// <param name="list">The list of lines to unindent.</param>
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

    /// <summary>
    /// Checks if any element in the suffixes list ends with the specified text.
    /// </summary>
    /// <param name="text">The text to search for.</param>
    /// <param name="suffixes">The list of elements to check.</param>
    /// <returns>True if any element ends with the text.</returns>
    public static bool AnyElementEndsWith(string text, IList<string> suffixes)
    {
        string? matchedElement = null;
        return AnyElementEndsWith(text, suffixes, out matchedElement);
    }

    /// <summary>
    /// Checks if any element in the suffixes list ends with the specified text, outputting the matched element.
    /// </summary>
    /// <param name="text">The text to search for.</param>
    /// <param name="suffixes">The list of elements to check.</param>
    /// <param name="matchedElement">The matched element, or null if not found.</param>
    /// <returns>True if any element ends with the text.</returns>
    public static bool AnyElementEndsWith(string text, IList<string> suffixes, out string? matchedElement)
    {
        matchedElement = null;
        foreach (var suffix in suffixes)
            if (suffix.EndsWith(text))
            {
                matchedElement = suffix;
                return true;
            }

        return false;
    }
}
