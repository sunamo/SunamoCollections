namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "items"></param>
    public static List<string> WithoutDiacritic(List<string> items)
    {
        for (var i = 0; i < items.Count; i++)
            items[i] = items[i].RemoveDiacritics();
        return items;
    }

    public static bool HasIndexWithValueWithoutException(int index, List<string> items, string item)
    {
        if (index < 0)
            return false;
        if (items.Count > index && items[index] == item)
            return true;
        return false;
    }

    public static bool HasIndexWithoutException(int index, IList items)
    {
        if (index < 0)
            return false;
        if (items.Count > index)
            return true;
        return false;
    }

    /// <summary>
    ///     Return A2 if start something in A1
    ///     A2 can be null
    /// </summary>
    /// <param name = "candidates"></param>
    /// <param name = "line"></param>
    /// <returns></returns>
    public static string StartWith(List<string> candidates, string line)
    {
        string element = null;
        return StartWith(candidates, line, out element);
    }

    /// <summary>
    ///     Return A2 if start something in A1
    ///     Really different method than string, List
    ///     <string>
    ///         A1 can be null
    /// </summary>
    /// <param name = "candidates"></param>
    /// <param name = "line"></param>
    public static string StartWith(List<string> candidates, string line, out string element)
    {
        element = null;
        if (candidates != null)
            foreach (var method in candidates)
                if (line.StartsWith(method))
                {
                    element = method;
                    return line;
                }

        return null;
    }

    /// <summary>
    ///     Return A1 which contains A2
    /// </summary>
    /// <param name = "lines"></param>
    /// <param name = "term"></param>
    public static List<string> ReturnWhichContains(List<string> lines, string term, ContainsCompareMethodCA compareMethod = ContainsCompareMethodCA.WholeInput)
    {
        List<int> founded;
        return ReturnWhichContains(lines, term, out founded, compareMethod);
    }

    /// <summary>
    ///     Return A1 which contains A2
    /// </summary>
    /// <param name = "lines"></param>
    /// <param name = "term"></param>
    /// <param name = "founded"></param>
    public static List<string> ReturnWhichContains(List<string> lines, string term, out List<int> founded, ContainsCompareMethodCA compareMethod = ContainsCompareMethodCA.WholeInput)
    {
        founded = new List<int>();
        var result = new List<string>();
        var i = 0;
        List<string> words = null;
        if (compareMethod == ContainsCompareMethodCA.SplitToWords || compareMethod == ContainsCompareMethodCA.Negations)
        {
            WhitespaceCharService whitespaceChar = new();
            words = SHSplit.SplitNone(term, whitespaceChar.WhiteSpaceChars.ConvertAll(data => data.ToString()).ToArray());
        }

        if (compareMethod == ContainsCompareMethodCA.WholeInput)
            foreach (var item in lines)
            {
                if (item.Contains(term))
                {
                    founded.Add(i);
                    result.Add(item);
                }

                i++;
            }
        else if (compareMethod == ContainsCompareMethodCA.SplitToWords || compareMethod == ContainsCompareMethodCA.Negations)
            foreach (var item in lines)
            {
                if (words.All(data => item.Contains(data))) //SH.ContainsAll(item, words, compareMethod))
                {
                    founded.Add(i);
                    result.Add(item);
                }

                i++;
            }
        else
            ThrowEx.NotImplementedCase(compareMethod);
        return result;
    }

    public static void Remove(List<string> input, Func<string, string, bool> predicate, string arg)
    {
        for (var i = input.Count - 1; i >= 0; i--)
            if (predicate.Invoke(input[i], arg))
                input.RemoveAt(i);
    }

    public static bool HasNullValue(List<string> items)
    {
        for (var i = 0; i < items.Count; i++)
            if (items[i] == null)
                return true;
        return false;
    }

    /// <summary>
    ///     Create array with A2 elements, otherwise return null. If any of element has not int value, return also null.
    /// </summary>
    /// <param name = "altitudes"></param>
    /// <param name = "requiredLength"></param>
    public static List<int> ToIntMinRequiredLength(IList enumerable, int requiredLength)
    {
        if (enumerable.Count() < requiredLength)
            return null;
        var result = new List<int>();
        var intValue = 0;
        foreach (var item in enumerable)
            if (int.TryParse(item.ToString(), out intValue))
                result.Add(intValue);
            else
                return null;
        return result;
    }

    public static List<string> EnsureBackslash(List<string> paths)
    {
        for (var i = 0; i < paths.Count; i++)
        {
            var currentPath = paths[i];
            if (currentPath[currentPath.Length - 1] != '\\')
                paths[i] = currentPath + "\\";
        }

        return paths;
    }

    /// <summary>
    ///     Delete which fullfil A2 wildcard
    /// </summary>
    /// <param name = "lines"></param>
    /// <param name = "mask"></param>
    public static void RemoveWildcard(List<string> lines, string mask)
    {
        //https://stackoverflow.com/a/15275806
        for (var i = lines.Count - 1; i >= 0; i--)
            if (SH.MatchWildcard(lines[i], mask))
                lines.RemoveAt(i);
    }

    public static List<object> ToObject(IList enumerable)
    {
        var result = new List<object>();
        foreach (var item in enumerable)
            result.Add(item);
        return result;
    }

    public static List<bool> ToBool(List<int> numbers)
    {
        var result = new List<bool>(numbers.Count);
        foreach (var item in numbers)
            result.Add(item == 1 ? true : false);
        return result;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "lines"></param>
    /// <param name = "patterns"></param>
    /// <param name = "wildcard"></param>
    public static void RemoveWhichContainsList(List<string> lines, List<string> patterns, bool wildcard, Func<string, string, bool> wildcardIsMatch = null)
    {
        foreach (var pattern in patterns)
            RemoveWhichContains(lines, pattern, wildcard, wildcardIsMatch);
    }

    public static string RemovePadding(List<byte> bytes, byte paddingByte, bool returnStringInUtf8)
    {
        RemovePadding(bytes, paddingByte);
        if (returnStringInUtf8)
            return Encoding.UTF8.GetString(bytes.ToArray());
        return string.Empty;
    }

    public static bool HasAtLeastOneElementInArray(List<string> data)
    {
        if (data != null)
            if (data.Count != 0)
                return true;
        return false;
    }

    public static bool HasPostfix(string key, params string[] postfixes)
    {
        foreach (var item in postfixes)
            if (key.EndsWith(item))
                return true;
        return false;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "numbered"></param>
    /// <param name = "input"></param>
    private static void Prepend(List<string> numbered, List<string> input)
    {
        ThrowEx.DifferentCountInLists("numbered", numbered.Count(), "input", input.Count);
        for (var i = 0; i < input.Count; i++)
            input[i] = numbered[i] + input[i];
    }
}