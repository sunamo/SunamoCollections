namespace SunamoCollections;

/// <summary>
/// Collection utility class - part 3.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Removes diacritics from all strings in the list. Direct edit.
    /// </summary>
    /// <param name="list">The list of strings to process.</param>
    /// <returns>The list with diacritics removed.</returns>
    public static List<string> WithoutDiacritic(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].RemoveDiacritics();
        return list;
    }

    /// <summary>
    /// Checks if the list has a valid index with the specified value, without throwing exceptions.
    /// </summary>
    /// <param name="index">The index to check.</param>
    /// <param name="list">The list to check.</param>
    /// <param name="text">The expected value at the index.</param>
    /// <returns>True if the index is valid and the value matches.</returns>
    public static bool HasIndexWithValueWithoutException(int index, List<string> list, string text)
    {
        if (index < 0)
            return false;
        if (list.Count > index && list[index] == text)
            return true;
        return false;
    }

    /// <summary>
    /// Checks if the list has a valid index, without throwing exceptions.
    /// </summary>
    /// <param name="index">The index to check.</param>
    /// <param name="list">The list to check.</param>
    /// <returns>True if the index is valid.</returns>
    public static bool HasIndexWithoutException(int index, IList list)
    {
        if (index < 0)
            return false;
        if (list.Count > index)
            return true;
        return false;
    }

    /// <summary>
    /// Returns the line if it starts with any candidate from the list.
    /// </summary>
    /// <param name="candidates">The list of candidate prefixes.</param>
    /// <param name="line">The line to check.</param>
    /// <returns>The line if a match is found, null otherwise.</returns>
    public static string? StartWith(List<string> candidates, string line)
    {
        string? matchedElement = null;
        return StartWith(candidates, line, out matchedElement);
    }

    /// <summary>
    /// Returns the line if it starts with any candidate from the list, outputting the matched candidate.
    /// </summary>
    /// <param name="candidates">The list of candidate prefixes.</param>
    /// <param name="line">The line to check.</param>
    /// <param name="matchedElement">The matched candidate, or null.</param>
    /// <returns>The line if a match is found, null otherwise.</returns>
    public static string? StartWith(List<string> candidates, string line, out string? matchedElement)
    {
        matchedElement = null;
        if (candidates != null)
            foreach (var candidate in candidates)
                if (line.StartsWith(candidate))
                {
                    matchedElement = candidate;
                    return line;
                }

        return null;
    }

    /// <summary>
    /// Returns elements from the list that contain the specified term.
    /// </summary>
    /// <param name="list">The list to search.</param>
    /// <param name="term">The term to look for.</param>
    /// <param name="compareMethod">The comparison method to use.</param>
    /// <returns>A list of matching elements.</returns>
    public static List<string> ReturnWhichContains(List<string> list, string term, ContainsCompareMethodCA compareMethod = ContainsCompareMethodCA.WholeInput)
    {
        List<int> foundIndexes;
        return ReturnWhichContains(list, term, out foundIndexes, compareMethod);
    }

    /// <summary>
    /// Returns elements from the list that contain the specified term, also outputting their indices.
    /// </summary>
    /// <param name="list">The list to search.</param>
    /// <param name="term">The term to look for.</param>
    /// <param name="foundIndexes">The indices of matching elements.</param>
    /// <param name="compareMethod">The comparison method to use.</param>
    /// <returns>A list of matching elements.</returns>
    public static List<string> ReturnWhichContains(List<string> list, string term, out List<int> foundIndexes, ContainsCompareMethodCA compareMethod = ContainsCompareMethodCA.WholeInput)
    {
        foundIndexes = new List<int>();
        var result = new List<string>();
        var currentIndex = 0;
        List<string>? words = null;
        if (compareMethod == ContainsCompareMethodCA.SplitToWords || compareMethod == ContainsCompareMethodCA.Negations)
        {
            WhitespaceCharService whitespaceChar = new();
            words = SHSplit.SplitNone(term, whitespaceChar.WhiteSpaceChars!.ConvertAll(character => character.ToString()).ToArray());
        }

        if (compareMethod == ContainsCompareMethodCA.WholeInput)
            foreach (var item in list)
            {
                if (item.Contains(term))
                {
                    foundIndexes.Add(currentIndex);
                    result.Add(item);
                }

                currentIndex++;
            }
        else if (compareMethod == ContainsCompareMethodCA.SplitToWords || compareMethod == ContainsCompareMethodCA.Negations)
            foreach (var item in list)
            {
                if (words!.All(word => item.Contains(word)))
                {
                    foundIndexes.Add(currentIndex);
                    result.Add(item);
                }

                currentIndex++;
            }
        else
            ThrowEx.NotImplementedCase(compareMethod);
        return result;
    }

    /// <summary>
    /// Removes elements matching a predicate with the given argument. Direct edit.
    /// </summary>
    /// <param name="list">The list to modify.</param>
    /// <param name="predicate">The predicate to test each element.</param>
    /// <param name="argument">The argument passed to the predicate.</param>
    public static void Remove(List<string> list, Func<string, string, bool> predicate, string argument)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (predicate.Invoke(list[i], argument))
                list.RemoveAt(i);
    }

    /// <summary>
    /// Checks if any element in the list is null.
    /// </summary>
    /// <param name="list">The list to check.</param>
    /// <returns>True if any element is null.</returns>
    public static bool HasNullValue(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            if (list[i] == null)
                return true;
        return false;
    }

    /// <summary>
    /// Converts list elements to integers. Returns null if the list has fewer elements than required or if any element is not a valid integer.
    /// </summary>
    /// <param name="list">The list to convert.</param>
    /// <param name="requiredLength">The minimum number of elements required.</param>
    /// <returns>A list of integers, or null if conversion fails.</returns>
    public static List<int>? ToIntMinRequiredLength(IList list, int requiredLength)
    {
        if (list.Count() < requiredLength)
            return null;
        var result = new List<int>();
        var intValue = 0;
        foreach (var item in list)
            if (int.TryParse(item?.ToString(), out intValue))
                result.Add(intValue);
            else
                return null;
        return result;
    }

    /// <summary>
    /// Ensures each path in the list ends with a backslash. Direct edit.
    /// </summary>
    /// <param name="list">The list of paths to process.</param>
    /// <returns>The list with ensured trailing backslashes.</returns>
    public static List<string> EnsureBackslash(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
        {
            var currentPath = list[i];
            if (currentPath[currentPath.Length - 1] != '\\')
                list[i] = currentPath + "\\";
        }

        return list;
    }

    /// <summary>
    /// Removes elements matching a wildcard pattern. Direct edit.
    /// </summary>
    /// <param name="list">The list to filter.</param>
    /// <param name="mask">The wildcard mask.</param>
    public static void RemoveWildcard(List<string> list, string mask)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (SH.MatchWildcard(list[i], mask))
                list.RemoveAt(i);
    }

    /// <summary>
    /// Converts an IList to a List of objects.
    /// </summary>
    /// <param name="list">The list to convert.</param>
    /// <returns>A list of objects.</returns>
    public static List<object> ToObject(IList list)
    {
        var result = new List<object>();
        foreach (var item in list)
            result.Add(item);
        return result;
    }

    /// <summary>
    /// Converts a list of integers to a list of booleans (1 = true, other = false).
    /// </summary>
    /// <param name="list">The list of integers to convert.</param>
    /// <returns>A list of boolean values.</returns>
    public static List<bool> ToBool(List<int> list)
    {
        var result = new List<bool>(list.Count);
        foreach (var item in list)
            result.Add(item == 1 ? true : false);
        return result;
    }

    /// <summary>
    /// Removes elements that contain the specified patterns. Direct edit.
    /// </summary>
    /// <param name="list">The list to filter.</param>
    /// <param name="patterns">The list of patterns to match.</param>
    /// <param name="isWildcard">Whether to use wildcard matching.</param>
    /// <param name="wildcardIsMatch">The wildcard matching function.</param>
    public static void RemoveWhichContainsList(List<string> list, List<string> patterns, bool isWildcard, Func<string, string, bool>? wildcardIsMatch = null)
    {
        foreach (var pattern in patterns)
            RemoveWhichContains(list, pattern, isWildcard, wildcardIsMatch!);
    }

    /// <summary>
    /// Removes padding bytes and optionally returns the result as a UTF-8 string.
    /// </summary>
    /// <param name="bytes">The list of bytes to process.</param>
    /// <param name="paddingByte">The padding byte value to remove.</param>
    /// <param name="isReturningStringInUtf8">Whether to return the result as a UTF-8 string.</param>
    /// <returns>The UTF-8 string if requested, otherwise empty string.</returns>
    public static string RemovePadding(List<byte> bytes, byte paddingByte, bool isReturningStringInUtf8)
    {
        RemovePadding(bytes, paddingByte);
        if (isReturningStringInUtf8)
            return Encoding.UTF8.GetString(bytes.ToArray());
        return string.Empty;
    }

    /// <summary>
    /// Checks if the list has at least one element.
    /// </summary>
    /// <param name="list">The list to check.</param>
    /// <returns>True if the list is not null and has at least one element.</returns>
    public static bool HasAtLeastOneElementInArray(List<string> list)
    {
        if (list != null)
            if (list.Count != 0)
                return true;
        return false;
    }

    /// <summary>
    /// Checks if the text ends with any of the specified suffixes.
    /// </summary>
    /// <param name="text">The text to check.</param>
    /// <param name="array">The suffixes to match.</param>
    /// <returns>True if the text ends with any suffix.</returns>
    public static bool HasPostfix(string text, params string[] array)
    {
        foreach (var item in array)
            if (text.EndsWith(item))
                return true;
        return false;
    }

    /// <summary>
    /// Prepends numbered elements to each element in the input list. Direct edit.
    /// </summary>
    /// <param name="numbered">The list of numbered prefixes.</param>
    /// <param name="list">The list to prepend to.</param>
    private static void Prepend(List<string> numbered, List<string> list)
    {
        ThrowEx.DifferentCountInLists("numbered", numbered.Count(), "list", list.Count);
        for (var i = 0; i < list.Count; i++)
            list[i] = numbered[i] + list[i];
    }
}
