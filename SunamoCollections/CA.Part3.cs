namespace SunamoCollections;

public partial class CA
{

    /// <summary>
    /// Has index with value without exception.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <param name="nahledy">The nahledy.</param>
    /// <param name="item">The item.</param>
    /// <returns>The has index with value without exception result.</returns>
    public static bool HasIndexWithValueWithoutException(int p, List<string> nahledy, string item)
    {
        if (p < 0) return false;
        if (nahledy.Count > p && nahledy[p] == item) return true;
        return false;
    }

    /// <summary>
    /// Has index without exception.
    /// </summary>
    /// <param name="p">The p.</param>
    /// <param name="nahledy">The nahledy.</param>
    /// <returns>The has index without exception result.</returns>
    public static bool HasIndexWithoutException(int p, IList nahledy)
    {
        if (p < 0) return false;
        if (nahledy.Count > p) return true;
        return false;
    }


    /// <summary>
    /// Start with.
    /// </summary>
    /// <param name="suMethods">The su methods.</param>
    /// <param name="line">The line.</param>
    /// <returns>The start with result.</returns>
    public static string StartWith(List<string> suMethods, string line)
    {
        string element = null;
        return StartWith(suMethods, line, out element);
    }

    /// <summary>
    /// Start with.
    /// </summary>
    /// <param name="suMethods">The su methods.</param>
    /// <param name="line">The line.</param>
    /// <param name="element">The element.</param>
    /// <returns>The start with result.</returns>
    public static string StartWith(List<string> suMethods, string line, out string element)
    {
        element = null;

        if (suMethods != null)
            foreach (var method in suMethods)
                if (line.StartsWith(method))
                {
                    element = method;
                    return line;
                }

        return null;
    }

    /// <summary>
    /// Return which contains.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <param name="term">The term.</param>
    /// <param name="parseNegations">The parse negations.</param>
    /// <returns>The return which contains result.</returns>
    public static List<string> ReturnWhichContains(List<string> lines, string term,
        ContainsCompareMethodCA parseNegations = ContainsCompareMethodCA.WholeInput)
    {
        List<int> founded;
        return ReturnWhichContains(lines, term, out founded, parseNegations);
    }

    /// <summary>
    /// Return which contains.
    /// </summary>
    /// <param name="lines">The lines.</param>
    /// <param name="term">The term.</param>
    /// <param name="founded">The founded.</param>
    /// <param name="parseNegations">The parse negations.</param>
    /// <returns>The return which contains result.</returns>
    public static List<string> ReturnWhichContains(List<string> lines, string term, out List<int> founded,
        ContainsCompareMethodCA parseNegations = ContainsCompareMethodCA.WholeInput)
    {
        founded = new List<int>();
        var result = new List<string>();
        var i = 0;

        List<string> w = null;
        if (parseNegations == ContainsCompareMethodCA.SplitToWords ||
            parseNegations == ContainsCompareMethodCA.Negations)
        {
            WhitespaceCharService whitespaceChar = new();
            w = SHSplit.SplitNone(term, whitespaceChar.WhiteSpaceChars.ConvertAll(d => d.ToString()).ToArray());
        }
        if (parseNegations == ContainsCompareMethodCA.WholeInput)
            foreach (var item in lines)
            {
                if (item.Contains(term))
                {
                    founded.Add(i);
                    result.Add(item);
                }

                i++;
            }
        else if (parseNegations == ContainsCompareMethodCA.SplitToWords ||
                 parseNegations == ContainsCompareMethodCA.Negations)
            foreach (var item in lines)
            {
                if (w.All(d => item.Contains(d))) //SH.ContainsAll(item, w, parseNegations))
                {
                    founded.Add(i);
                    result.Add(item);
                }

                i++;
            }
        else
            ThrowEx.NotImplementedCase(parseNegations);

        return result;
    }

    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="input">The input.</param>
    /// <param name="pred">The pred.</param>
    /// <param name="arg">The arg.</param>
    /// <returns>The remove result.</returns>
    public static void Remove(List<string> input, Func<string, string, bool> pred, string arg)
    {
        for (var i = input.Count - 1; i >= 0; i--)
            if (pred.Invoke(input[i], arg))
                input.RemoveAt(i);
    }


    /// <summary>
    /// Has null value.
    /// </summary>
    /// <param name="idPhotos">The id photos.</param>
    /// <returns>The has null value result.</returns>
    public static bool HasNullValue(List<string> idPhotos)
    {
        for (var i = 0; i < idPhotos.Count; i++)
            if (idPhotos[i] == null)
                return true;
        return false;
    }

    /// <summary>
    /// To int min required length.
    /// </summary>
    /// <param name="enumerable">The enumerable.</param>
    /// <param name="requiredLength">The required length.</param>
    /// <returns>The to int min required length result.</returns>
    public static List<int> ToIntMinRequiredLength(IList enumerable, int requiredLength)
    {
        if (enumerable.Count() < requiredLength) return null;

        var result = new List<int>();
        var y = 0;
        foreach (var item in enumerable)
            if (int.TryParse(item.ToString(), out y))
                result.Add(y);
            else
                return null;
        return result;
    }




    /// <summary>
    /// Ensure backslash.
    /// </summary>
    /// <param name="eb">The eb.</param>
    /// <returns>The ensure backslash result.</returns>
    public static List<string> EnsureBackslash(List<string> eb)
    {
        for (var i = 0; i < eb.Count; i++)
        {
            var r = eb[i];
            if (r[r.Length - 1] != '\\') eb[i] = r + "\\";
        }

        return eb;
    }

    /// <summary>
    /// Remove wildcard.
    /// </summary>
    /// <param name="d">The d.</param>
    /// <param name="mask">The mask.</param>
    /// <returns>The remove wildcard result.</returns>
    public static void RemoveWildcard(List<string> d, string mask)
    {
        //https://stackoverflow.com/a/15275806

        for (var i = d.Count - 1; i >= 0; i--)
            if (SH.MatchWildcard(d[i], mask))
                d.RemoveAt(i);
    }



    /// <summary>
    /// To object.
    /// </summary>
    /// <param name="enumerable">The enumerable.</param>
    /// <returns>The to object result.</returns>
    public static List<object> ToObject(IList enumerable)
    {
        var result = new List<object>();
        foreach (var item in enumerable) result.Add(item);
        return result;
    }

    /// <summary>
    /// To bool.
    /// </summary>
    /// <param name="numbers">The numbers.</param>
    /// <returns>The to bool result.</returns>
    public static List<bool> ToBool(List<int> numbers)
    {
        var b = new List<bool>(numbers.Count);
        foreach (var item in numbers) b.Add(item == 1 ? true : false);
        return b;
    }

    /// <summary>
    /// Remove which contains list.
    /// </summary>
    /// <param name="files">The files.</param>
    /// <param name="list">The list.</param>
    /// <param name="wildcard">The wildcard.</param>
    /// <param name="WildcardIsMatch">The wildcard is match.</param>
    /// <returns>The remove which contains list result.</returns>
    public static void RemoveWhichContainsList(List<string> files, List<string> list, bool wildcard,
        Func<string, string, bool> WildcardIsMatch = null)
    {
        foreach (var item in list) RemoveWhichContains(files, item, wildcard, WildcardIsMatch);
    }


    /// <summary>
    /// Remove padding.
    /// </summary>
    /// <param name="decrypted">The decrypted.</param>
    /// <param name="v">The v.</param>
    /// <param name="returnStringInUtf8">The return string in utf 8.</param>
    /// <returns>The remove padding result.</returns>
    public static string RemovePadding(List<byte> decrypted, byte v, bool returnStringInUtf8)
    {
        RemovePadding(decrypted, v);

        if (returnStringInUtf8) return Encoding.UTF8.GetString(decrypted.ToArray());
        return string.Empty;
    }



    /// <summary>
    /// Has at least one element in array.
    /// </summary>
    /// <param name="d">The d.</param>
    /// <returns>The has at least one element in array result.</returns>
    public static bool HasAtLeastOneElementInArray(List<string> d)
    {
        if (d != null)
            if (d.Count != 0)
                return true;
        return false;
    }





    /// <summary>
    /// Has postfix.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="v1">The v 1.</param>
    /// <returns>The has postfix result.</returns>
    public static bool HasPostfix(string key, params string[] v1)
    {
        foreach (var item in v1)
            if (key.EndsWith(item))
                return true;
        return false;
    }

    private static void Prepend(List<string> numbered, List<string> input)
    {
        ThrowEx.DifferentCountInLists("numbered", numbered.Count(), "input", input.Count);
        for (var i = 0; i < input.Count; i++) input[i] = numbered[i] + input[i];
    }

    /// <summary>
    /// Initializes a new instance of the prepend class.
    /// </summary>
    /// <param name="i">The i.</param>
    public static List<string> Prepend(string v, List<string> toReplace)
    {
        for (var i = 0; i < toReplace.Count; i++)
            if (!toReplace[i].StartsWith(v))
                toReplace[i] = v + toReplace[i];
        return toReplace;
    }

    /// <summary>
    /// Prepend.
    /// </summary>
    /// <param name="v">The v.</param>
    /// <param name="toReplace">The to replace.</param>
    /// <returns>The prepend result.</returns>
    public static List<string> Prepend(string v, string[] toReplace)
    {
        return Prepend(v, toReplace.ToList());
    }


    /// <summary>
    /// Find out longest item.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <param name="delimiters">The delimiters.</param>
    /// <returns>The find out longest item result.</returns>
    public static string FindOutLongestItem(List<string> list, params string[] delimiters)
    {
        var longestLength = 0;
        var longest = "";
        foreach (var item in list)
        {
            var tem = item;
            if (delimiters.Length != 0) tem = SHSplit.Split(item, delimiters)[0].Trim();
            if (longestLength < tem.Length)
            {
                longest = tem;
                longestLength = tem.Length;
            }
        }

        return longest;
    }

    /// <summary>
    /// Is odd.
    /// </summary>
    /// <param name="bold">The bold.</param>
    /// <returns>The is odd result.</returns>
    public static bool IsOdd(params List<int>[] bold)
    {
        foreach (var item in bold)
            if (item.Count % 2 == 1)
                return true;
        return false;
    }

    /// <summary>
    /// To lower.
    /// </summary>
    /// <param name="words">The words.</param>
    /// <returns>The to lower result.</returns>
    public static List<string> ToLower(List<string> words)
    {
        for (var i = 0; i < words.Count; i++) words[i] = words[i].ToLower();
        return words;
    }





    /// <summary>
    /// Remove which contains.
    /// </summary>
    /// <param name="files1">The files 1.</param>
    /// <param name="item">The item.</param>
    /// <param name="wildcard">The wildcard.</param>
    /// <param name="WildcardIsMatch">The wildcard is match.</param>
    public static void RemoveWhichContains(List<string> files1, string item, bool wildcard,
        Func<string, string, bool> WildcardIsMatch)
    {
        if (wildcard)
        {
            for (var i = files1.Count - 1; i >= 0; i--)
                if (WildcardIsMatch(files1[i], item))
                    files1.RemoveAt(i);
        }
        else
        {
            for (var i = files1.Count - 1; i >= 0; i--)
                if (files1[i].Contains(item))
                    files1.RemoveAt(i);
        }
    }






    ///// <summary>
    ///// Convert IList to List<string> Nothing more, nothing less
    ///// Must be private - to use only public in CA
    ///// bcoz Cast() not working
    ///// Dont make any type checking - could be done before
    ///// </summary>

    ///// <summary>
    ///// Just 3 cases of working:
    ///// IList<char> => string
    ///// IList<string> => List<string>
    ///// IList => List<string>
    ///// </summary>
    ///// <param name="enumerable"></param>

    /// <summary>
    /// One element collection to multi.
    /// </summary>
    /// <param name="deli2">The deli 2.</param>
    /// <returns>The one element collection to multi result.</returns>
    public static IList<object> OneElementCollectionToMulti(IList deli2)
    {
        if (deli2.Count() == 1)
        {
            var first = deli2.FirstOrNull();
            var ien = first as IList<object>;

            if (ien != null) return ien;
            return ToListMoreObject(first);
        }

        return deli2 as IList<object>;
    }


    /// <summary>
    /// Remove strings empty.
    /// </summary>
    /// <param name="mySites">The my sites.</param>
    /// <returns>The remove strings empty result.</returns>
    public static List<string> RemoveStringsEmpty(List<string> mySites)
    {
        for (var i = mySites.Count - 1; i >= 0; i--)
            if (mySites[i] == string.Empty)
                mySites.RemoveAt(i);
        return mySites;
    }
}