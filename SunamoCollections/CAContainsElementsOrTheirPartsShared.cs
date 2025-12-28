// variables names: ok
namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    public static bool IsAllTheSameString<T>(IList<T> firstList, IList<T> secondList)
    {
        var firstListCount = firstList.Count();
        var secondListCount = secondList.Count();
        if (firstListCount != secondListCount) ThrowEx.DifferentCountInLists("firstList", firstList.Count, "secondList", secondList.Count);

        string firstValue;
        string secondValue;

        for (var i = 0; i < firstListCount; i++)
        {
            firstValue = firstList[i].ToString();
            secondValue = secondList[i].ToString();
            if (firstValue != secondValue) return false;
        }

        return true;
    }

    #region 7) IndexesWithValue

    /// <summary>
    ///     ContainsAnyFromElement - Contains string elements of list. return list
    ///     <string>
    ///         IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///         IsEqualToAllElement - takes two generic list. return bool
    ///         ContainsElement - at least one element must be equaled. generic. bool
    ///         IsSomethingTheSame - only for string. as list.Contains. bool
    ///         IsAllTheSame() - takes element and list.generic. bool
    ///         IndexesWithValue() - element and list.generic. return list
    ///         <int>
    ///             ReturnWhichContainsIndexes() - takes two List or element and list. return list<int>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list"></param>
    /// <param name="candidate"></param>
    /// <returns></returns>
    public static List<int> IndexesWithValue<T>(List<T> list, T candidate)
    {
        var result = list.Select((r, index) => new { Index = index, Value = r })
            .Where(d => EqualityComparer<T>.Default.Equals(d.Value, candidate)).Select(d => d.Index).ToList();
        return result;
    }

    #endregion

    #region 1) ContainsAnyFromElement - For easy copy from CAContainsElementsOrTheirPartsShared.cs

    public static bool ContainsAnyFromElementBool(string text, IList<string> candidates)
    {
        if (candidates.Count() == 1 && candidates.First() == "*") return true;

        var result = new List<int>();

        foreach (var item in candidates)
            if (text.Contains(item))
                return true;

        return false;
    }

    /// <summary>
    ///     ContainsAnyFromElement - return string elements of List which is contained. Is possible also to use
    ///     ContainsAnyFromElementBool
    ///     IsEqualToAnyElement - same as ContainsElement, only have switched elements
    ///     ContainsElement - at least one element must be equaled. generic
    ///     IsSomethingTheSame - only for string.
    ///     ContainsElement - bool, generic, check for equal.
    ///     ReturnWhichContains - from lines return which contains
    /// </summary>
    /// <param name="text"></param>
    /// <param name="candidates"></param>
    /// <returns></returns>
    public static List<int> ContainsAnyFromElement(string text, IList<string> candidates)
    {
        var result = new List<int>();

        var i = 0;

        foreach (var item in candidates)
        {
            if (text.Contains(item)) result.Add(i);
            i++;
        }

        return result;
    }

    #endregion

    #region 8) ReturnWhichContainsIndexes

    public static List<int> ReturnWhichContainsIndexes(string text, IList<string> candidates)
    {
        var result = new List<int>();
        var i = 0;
        foreach (var term in candidates)
        {
            if (text.Contains(term) /*.Contains(text, term, searchStrategy)*/) result.Add(i);
            i++;
        }

        return result;
    }

    /// <summary>
    ///     ContainsAnyFromElement - Contains string elements of List
    ///     IsEqualToAnyElement - same as ContainsElement, only have switched elements
    ///     ContainsElement - at least one element must be equaled. generic
    ///     IsSomethingTheSame - only for string.
    ///     AnySpaces - split A2 by spaces and A1 must contains all parts
    ///     ExactlyName - ==
    ///     FixedSpace - simple contains
    ///     ContainsAnyFromElement - Contains string elements of list. return list
    ///     <string>
    ///         IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///         IsEqualToAllElement - takes two generic list. return bool
    ///         ContainsElement - at least one element must be equaled. generic. bool
    ///         IsSomethingTheSame - only for string. as list.Contains. bool
    ///         IsAllTheSame() - takes element and list.generic. bool
    ///         IndexesWithValue() - element and list.generic. return list
    ///         <int>
    ///             ReturnWhichContainsIndexes() - takes two List or element and list. return list<int>
    /// </summary>
    /// <param name="list"></param>
    /// <param name="candidate"></param>
    /// <param name="searchStrategy"></param>
    public static List<int> ReturnWhichContainsIndexes(IList<string> list, string candidate)
    {
        var result = new List<int>();
        var i = 0;
        if (list != null)
            foreach (var item in list)
            {
                if (item.Contains(candidate) /*.Contains(item, term, searchStrategy)*/) result.Add(i);
                i++;
            }

        return result;
    }

    /// <summary>
    ///     CA.ContainsAnyFromElement - Contains string elements of list. return list
    ///     <string>
    ///         CAG.IsEqualToAnyElement - same as ContainsElement, only have switched elements. return bool
    ///         CA.IsEqualToAllElement - takes two generic list. return bool
    ///         CA.ContainsElement - at least one element must be equaled. generic. bool
    ///         CA.IsSomethingTheSame - only for string. as list.Contains. bool
    ///         CA.IsAllTheSame() - takes element and list.generic. bool
    ///         CA.IndexesWithValue() - element and list.generic. return list
    ///         <int>
    ///             CA.ReturnWhichContainsIndexes() - takes two List or element and list. return list<int>
    /// </summary>
    /// <param name="list"></param>
    /// <param name="candidates"></param>
    /// <returns></returns>
    public static IList<int> ReturnWhichContainsIndexes(IList<string> list, IList<string> candidates)
    {
        var result = new List<int>();
        foreach (var item in candidates) result.AddRange(ReturnWhichContainsIndexes(list, item));
        result = result.Distinct().ToList();
        return result;
    }

    #endregion
}