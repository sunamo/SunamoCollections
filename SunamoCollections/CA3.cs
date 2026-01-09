// variables names: ok
namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "list"></param>
    public static List<string> WithoutDiacritic(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].RemoveDiacritics();
        return list;
    }

    public static bool HasIndexWithValueWithoutException(int index, List<string> list, string text)
    {
        if (index < 0)
            return false;
        if (list.Count > index && list[index] == text)
            return true;
        return false;
    }

    public static bool HasIndexWithoutException(int index, IList list)
    {
        if (index < 0)
            return false;
        if (list.Count > index)
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
    ///     Really different method than string, List&lt;string&gt;
    ///     A1 can be null
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
    /// <param name = "list"></param>
    /// <param name = "term"></param>
    public static List<string> ReturnWhichContains(List<string> list, string term, ContainsCompareMethodCA compareMethod = ContainsCompareMethodCA.WholeInput)
    {
        List<int> founded;
        return ReturnWhichContains(list, term, out founded, compareMethod);
    }

    /// <summary>
    ///     Return A1 which contains A2
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "term"></param>
    /// <param name = "founded"></param>
    public static List<string> ReturnWhichContains(List<string> list, string term, out List<int> founded, ContainsCompareMethodCA compareMethod = ContainsCompareMethodCA.WholeInput)
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
            foreach (var item in list)
            {
                if (item.Contains(term))
                {
                    founded.Add(i);
                    result.Add(item);
                }

                i++;
            }
        else if (compareMethod == ContainsCompareMethodCA.SplitToWords || compareMethod == ContainsCompareMethodCA.Negations)
            foreach (var item in list)
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

    public static void Remove(List<string> list, Func<string, string, bool> predicate, string argument)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (predicate.Invoke(list[i], argument))
                list.RemoveAt(i);
    }

    public static bool HasNullValue(List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            if (list[i] == null)
                return true;
        return false;
    }

    /// <summary>
    ///     Create array with A2 elements, otherwise return null. If any of element has not int value, return also null.
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "requiredLength"></param>
    public static List<int> ToIntMinRequiredLength(IList list, int requiredLength)
    {
        if (list.Count() < requiredLength)
            return null;
        var result = new List<int>();
        var intValue = 0;
        foreach (var item in list)
            if (int.TryParse(item.ToString(), out intValue))
                result.Add(intValue);
            else
                return null;
        return result;
    }

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
    ///     Delete which fullfil A2 wildcard
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "mask"></param>
    public static void RemoveWildcard(List<string> list, string mask)
    {
        //https://stackoverflow.com/a/15275806
        for (var i = list.Count - 1; i >= 0; i--)
            if (SH.MatchWildcard(list[i], mask))
                list.RemoveAt(i);
    }

    public static List<object> ToObject(IList list)
    {
        var result = new List<object>();
        foreach (var item in list)
            result.Add(item);
        return result;
    }

    public static List<bool> ToBool(List<int> list)
    {
        var result = new List<bool>(list.Count);
        foreach (var item in list)
            result.Add(item == 1 ? true : false);
        return result;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <param name = "list"></param>
    /// <param name = "patterns"></param>
    /// <param name = "wildcard"></param>
    public static void RemoveWhichContainsList(List<string> list, List<string> patterns, bool wildcard, Func<string, string, bool> wildcardIsMatch = null)
    {
        foreach (var pattern in patterns)
            RemoveWhichContains(list, pattern, wildcard, wildcardIsMatch);
    }

    public static string RemovePadding(List<byte> bytes, byte paddingByte, bool returnStringInUtf8)
    {
        RemovePadding(bytes, paddingByte);
        if (returnStringInUtf8)
            return Encoding.UTF8.GetString(bytes.ToArray());
        return string.Empty;
    }

    public static bool HasAtLeastOneElementInArray(List<string> list)
    {
        if (list != null)
            if (list.Count != 0)
                return true;
        return false;
    }

    public static bool HasPostfix(string text, params string[] array)
    {
        foreach (var item in array)
            if (text.EndsWith(item))
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