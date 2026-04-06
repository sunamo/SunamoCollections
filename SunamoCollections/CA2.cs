namespace SunamoCollections;

/// <summary>
/// Collection utility class - part 2.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Checks if the text ends with any of the specified suffixes.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="suffixes">The suffixes to match.</param>
    /// <returns>True if the text ends with any suffix.</returns>
    public static bool EndsWithAnyElement(string text, params string[] suffixes)
    {
        return EndsWithAnyElement(text, suffixes.ToList());
    }

    /// <summary>
    /// Checks if the text ends with any of the specified suffixes.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="suffixes">The list of suffixes to match.</param>
    /// <returns>True if the text ends with any suffix.</returns>
    public static bool EndsWithAnyElement(string text, IList<string> suffixes)
    {
        foreach (var suffix in suffixes)
            if (text.EndsWith(suffix))
                return true;
        return false;
    }

    /// <summary>
    /// Checks if the text ends with any of the specified suffixes.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="suffixes">The list of suffixes to match.</param>
    /// <returns>True if the text ends with any suffix.</returns>
    public static bool EndsWith(string text, List<string> suffixes)
    {
        foreach (var suffix in suffixes)
            if (text.EndsWith(suffix))
                return true;
        return false;
    }

    /// <summary>
    /// Joins an enumerable of objects into a list of strings.
    /// </summary>
    /// <param name="enumerable">The enumerable to join.</param>
    /// <returns>A list of string representations.</returns>
    public static List<string> Join(IEnumerable<object> enumerable)
    {
        var result = new List<string>();
        foreach (var item in enumerable)
        {
            result.AddRange(new List<string>([item.ToString()!]));
        }

        return result;
    }

    /// <summary>
    /// Replaces all occurrences of specified substrings in the text.
    /// </summary>
    /// <param name="text">The text to process.</param>
    /// <param name="what">The list of substrings to replace.</param>
    /// <param name="replacement">The replacement string.</param>
    /// <returns>The text with all replacements applied.</returns>
    public static string ReplaceAll(string text, List<string> what, string replacement)
    {
        foreach (var item in what)
            text = text.Replace(item, replacement);
        return text;
    }

    /// <summary>
    /// Removes elements from the first list that exist in the second list.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="elementsToRemove">The elements to remove.</param>
    public static void RemoveWhichExists(IList<string> list, List<string> elementsToRemove)
    {
        var index = -1;
        foreach (var item in elementsToRemove)
        {
            index = list.IndexOf(item);
            if (index != -1)
                list.RemoveAt(index);
        }
    }

    /// <summary>
    /// Returns the first candidate that starts with the specified prefix, or null.
    /// </summary>
    /// <param name="prefix">The prefix to match.</param>
    /// <param name="candidates">The candidates to search.</param>
    /// <returns>The first matching candidate, or null.</returns>
    public static string? StartWith(string prefix, params string[] candidates)
    {
        return StartWith(prefix, candidates.ToList());
    }

    /// <summary>
    /// Returns the first candidate that starts with the specified prefix, or null.
    /// </summary>
    /// <param name="prefix">The prefix to match.</param>
    /// <param name="candidates">The list of candidates to search.</param>
    /// <returns>The first matching candidate, or null.</returns>
    public static string? StartWith(string prefix, IList<string> candidates)
    {
        int foundIndex;
        return StartWith(prefix, candidates, out foundIndex);
    }

    /// <summary>
    /// Returns the first candidate that starts with the specified prefix, or null.
    /// Also outputs the index of the found candidate.
    /// </summary>
    /// <param name="prefix">The prefix to match.</param>
    /// <param name="candidates">The list of candidates to search.</param>
    /// <param name="foundIndex">The index of the found candidate, or -1 if not found.</param>
    /// <returns>The first matching candidate, or null.</returns>
    public static string? StartWith(string prefix, IList<string> candidates, out int foundIndex)
    {
        foundIndex = -1;
        foreach (var item in candidates)
        {
            foundIndex++;
            if (item.StartsWith(prefix))
                return item;
        }

        return null;
    }

    /// <summary>
    /// Trims the specified prefix from the start of each element. Direct edit.
    /// </summary>
    /// <param name="prefix">The prefix to remove.</param>
    /// <param name="list">The list to process.</param>
    /// <returns>The processed list.</returns>
    public static List<string> TrimStart(string prefix, List<string> list)
    {
        ThrowEx.IsNull("prefix", prefix);
        ThrowEx.IsNull("list", list);
        for (var i = 0; i < list.Count; i++)
            if (list[i].StartsWith(prefix))
                list[i] = list[i].Substring(prefix.Length);
        return list;
    }

    /// <summary>
    /// Appends text to the last element of the list, or adds it as a new element if the list is empty.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="text">The text to append.</param>
    public static void AppendToLastElement(List<string> list, string text)
    {
        if (list.Count > 0)
            list[list.Count - 1] += text;
        else
            list.Add(text);
    }

    /// <summary>
    /// Wraps each element with the specified wrapper string. Direct edit.
    /// </summary>
    /// <param name="list">The list to wrap.</param>
    /// <param name="wrapper">The wrapper string to prepend and append.</param>
    /// <returns>The wrapped list.</returns>
    public static List<string> WrapWith(List<string> list, string wrapper)
    {
        return WrapWith(list, wrapper, wrapper);
    }

    /// <summary>
    /// Wraps each element with specified before and after strings. Direct edit.
    /// </summary>
    /// <param name="list">The list to wrap.</param>
    /// <param name="before">The string to prepend.</param>
    /// <param name="after">The string to append.</param>
    /// <returns>The wrapped list.</returns>
    public static List<string> WrapWith(List<string> list, string before, string after)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = before + list[i] + after;
        return list;
    }

    /// <summary>
    /// Converts elements of an IList to a list of long values.
    /// </summary>
    /// <param name="enumerable">The list to convert.</param>
    /// <returns>A list of long values.</returns>
    public static List<long> ToLong(IList enumerable)
    {
        var result = new List<long>();
        foreach (var item in enumerable)
            result.Add(long.Parse(item.ToString()!));
        return result;
    }

    /// <summary>
    /// Converts elements of an IList to a list of short values.
    /// </summary>
    /// <param name="enumerable">The list to convert.</param>
    /// <returns>A list of short values.</returns>
    public static List<short> ToShort(IList enumerable)
    {
        var result = new List<short>();
        foreach (var item in enumerable)
            result.Add(short.Parse(item.ToString()!));
        return result;
    }

    /// <summary>
    /// Joins two byte arrays into a single list of bytes.
    /// </summary>
    /// <param name="firstArray">The first byte array.</param>
    /// <param name="secondArray">The second byte array.</param>
    /// <returns>A combined list of bytes.</returns>
    public static List<byte> JoinBytesArray(byte[] firstArray, byte[] secondArray)
    {
        var result = new List<byte>(firstArray.Length + secondArray.Length);
        result.AddRange(firstArray);
        result.AddRange(secondArray);
        return result;
    }

    /// <summary>
    /// Gets the count of a list, or 0 if null.
    /// </summary>
    /// <param name="list">The list to count.</param>
    /// <returns>The count of elements.</returns>
    public static int GetLength(IList list)
    {
        if (list == null)
            return 0;
        return list.Count;
    }

    /// <summary>
    /// Joins a single element and a list into a string array.
    /// </summary>
    /// <param name="firstElement">The first element to add.</param>
    /// <param name="list">The remaining elements.</param>
    /// <returns>A combined string array.</returns>
    public static string[] JoinVariableAndArray(object firstElement, IList list)
    {
        var result = new List<string>();
        result.Add(firstElement.ToString()!);
        foreach (var item in list)
            result.Add(item?.ToString()!);
        return result.ToArray();
    }

    /// <summary>
    /// Trims specified trailing characters from each element. Direct edit.
    /// </summary>
    /// <param name="list">The list to trim.</param>
    /// <param name="toTrim">The characters to trim from the end.</param>
    /// <returns>The trimmed list.</returns>
    public static List<string> TrimEnd(List<string> list, params char[] toTrim)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].TrimEnd(toTrim);
        return list;
    }

    /// <summary>
    /// Returns indices of elements from the list that the text starts with.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="list">The list of prefixes.</param>
    /// <param name="isTrimming">Whether to trim elements before comparing.</param>
    /// <returns>A list of matching indices.</returns>
    public static List<int> StartWithAnyInElement(string text, List<string> list, bool isTrimming)
    {
        var result = new List<int>();
        var currentIndex = 0;
        foreach (var item in list)
        {
            var trimmedElement = item;
            if (isTrimming)
                trimmedElement = trimmedElement.Trim();
            if (text.StartsWith(trimmedElement))
                result.Add(currentIndex);
            currentIndex++;
        }

        return result;
    }
}
