namespace SunamoCollections;

/// <summary>
/// Collection utility class providing common operations on lists, arrays, and enumerables.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Counts occurrences of every line in the list.
    /// </summary>
    /// <param name="list">The list of strings to analyze.</param>
    /// <returns>A dictionary mapping each line to its occurrence count.</returns>
    public static Dictionary<string, int> OccurenceOfEveryLine(List<string> list)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Returns the last item from a string split by the specified delimiter.
    /// </summary>
    /// <param name="text">The input string.</param>
    /// <param name="delimiter">The delimiter to split by.</param>
    /// <returns>The last item after splitting.</returns>
    public static string LastItem(string text, string delimiter)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Fills a list with the specified number of copies of the init value.
    /// </summary>
    /// <param name="list">The list to fill.</param>
    /// <param name="count">The number of elements to add.</param>
    /// <param name="initWith">The value to fill with.</param>
    public static void InitFillWith(List<string> list, int count, string initWith = "")
    {
        InitFillWith<string>(list, count, initWith);
    }

    /// <summary>
    /// Fills a list with the specified number of copies of the init value.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to fill.</param>
    /// <param name="count">The number of elements to add.</param>
    /// <param name="initWith">The value to fill with.</param>
    public static void InitFillWith<T>(List<T> list, int count, T initWith)
    {
        for (var i = 0; i < count; i++)
            list.Add(initWith);
    }

    /// <summary>
    /// Counts elements in an enumerable.
    /// </summary>
    /// <param name="enumerable">The enumerable to count.</param>
    /// <returns>The number of elements, or 0 if null.</returns>
    public static int Count(IEnumerable enumerable)
    {
        if (enumerable == null)
            return 0;
        if (enumerable is IList)
            return ((IList)enumerable).Count;
        if (enumerable is Array)
            return ((Array)enumerable).Length;
        var count = 0;
        foreach (var item in enumerable)
            count++;
        return count;
    }

    /// <summary>
    /// Trims all strings in the list. Direct edit.
    /// </summary>
    /// <param name="list">The list of strings to trim.</param>
    /// <returns>The same list with trimmed elements.</returns>
    public static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].Trim();
        return list;
    }

    /// <summary>
    /// Trims only whitespace-only lines in the list.
    /// </summary>
    /// <param name="list">The list of strings to process.</param>
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

    /// <summary>
    /// Returns the first element of an enumerable as a string, or null.
    /// </summary>
    /// <param name="enumerable">The enumerable to get the first element from.</param>
    /// <returns>The string representation of the first element, or null if empty.</returns>
    public static string? First(IEnumerable enumerable)
    {
        foreach (var item in enumerable)
            return item?.ToString();
        return null;
    }

    /// <summary>
    /// Checks whether an enumerable contains a single element that is a List of strings or objects.
    /// </summary>
    /// <param name="enumerable">The enumerable to check.</param>
    /// <returns>True if the enumerable wraps a List of string or object.</returns>
    public static bool IsListStringWrappedInArray(IEnumerable enumerable)
    {
        var first = First(enumerable);
        if (Count(enumerable) == 1 && (first == "System.Collections.Generic.List`1[System.String]" || first == "System.Collections.Generic.List`1[System.Object]"))
            return true;
        return false;
    }

    /// <summary>
    /// Wraps elements with a specified string if a predicate matches.
    /// </summary>
    /// <param name="predicate">The predicate function to test each element.</param>
    /// <param name="isInverted">Whether to invert the predicate result.</param>
    /// <param name="mustContains">The string that must be contained.</param>
    /// <param name="wrapWith">The wrapper string.</param>
    /// <param name="array">The array of strings to process.</param>
    /// <returns>A list of processed strings.</returns>
    public static List<string> WrapWithIfFunc(Func<string, string, bool, bool> predicate, bool isInverted, string mustContains, string wrapWith, params string[] array)
    {
        for (var i = 0; i < array.Length; i++)
            if (predicate.Invoke(array[i], mustContains, isInverted))
                array[i] = wrapWith + array[i] + wrapWith;
        return array.ToList();
    }

    /// <summary>
    /// Gets the element at the specified index, or null if the list is null or the index is out of range.
    /// </summary>
    /// <param name="list">The list to get the element from.</param>
    /// <param name="index">The index of the element.</param>
    /// <returns>The element at the index, or null.</returns>
    public static object? GetIndex(List<string> list, int index)
    {
        if (list == null)
            return null;
        if (!HasIndex(index, list))
            return null;
        return list[index];
    }

    /// <summary>
    /// Checks whether an array has the specified index.
    /// </summary>
    /// <param name="index">The index to check.</param>
    /// <param name="array">The array to check against.</param>
    /// <returns>True if the index is valid.</returns>
    public static bool HasIndex(int index, Array array)
    {
        return array.Length > index;
    }

    /// <summary>
    /// Checks whether a list has the specified index.
    /// </summary>
    /// <param name="index">The index to check.</param>
    /// <param name="list">The list to check against.</param>
    /// <returns>True if the index is valid.</returns>
    public static bool HasIndex(int index, IList list)
    {
        if (index < 0)
            throw new Exception("Invalid parameter index");
        if (list.Count > index)
            return true;
        return false;
    }

    /// <summary>
    /// Removes an element and re-inserts it at the beginning of the list.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="value">The value to move to the front.</param>
    /// <returns>True if the value was found and moved.</returns>
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

    /// <summary>
    /// Replaces sequences of two or more empty lines with a single empty line.
    /// </summary>
    /// <param name="text">The input text.</param>
    /// <returns>The text with collapsed empty lines.</returns>
    public static string DoubleOrMoreMultiLinesToSingle(string text)
    {
        DoubleOrMoreMultiLinesToSingle(ref text);
        return text;
    }

    /// <summary>
    /// Removes null, empty, and whitespace-only strings from the list. Direct edit.
    /// </summary>
    /// <param name="list">The list to clean.</param>
    public static void RemoveNullEmptyWs(List<string> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (string.IsNullOrWhiteSpace(list[i]))
                list.RemoveAt(i);
    }

    /// <summary>
    /// Checks whether the list is null or has zero elements.
    /// </summary>
    /// <param name="list">The list to check.</param>
    /// <returns>True if null or empty.</returns>
    public static bool IsEmptyOrNull(IList list)
    {
        if (list == null)
            return true;
        if (list.Count == 0)
            return true;
        return false;
    }

    /// <summary>
    /// Converts all strings in the list to lowercase. Stores directly in the source list for performance unless a new array is requested.
    /// </summary>
    /// <param name="list">The list to convert.</param>
    /// <param name="isCreatingNewArray">Whether to create a new list instead of modifying the original.</param>
    /// <returns>The list with lowercased elements.</returns>
    public static List<string> ToLower(List<string> list, bool isCreatingNewArray = false)
    {
        var result = list;
        if (isCreatingNewArray)
        {
            result = new List<string>(list.Count);
            InitFillWith(result, list.Count);
        }

        for (var i = 0; i < list.Count; i++)
            result[i] = list[i].ToLower();
        return result;
    }

    /// <summary>
    /// Replaces sequences of two or more empty lines with a single empty line. Direct edit by reference.
    /// </summary>
    /// <param name="text">The text to process.</param>
    public static void DoubleOrMoreMultiLinesToSingle(ref string text)
    {
        text = Regex.Replace(text, @"(\r?\n\s*){2,}", Environment.NewLine + Environment.NewLine);
        text = text.Trim();
    }
}
