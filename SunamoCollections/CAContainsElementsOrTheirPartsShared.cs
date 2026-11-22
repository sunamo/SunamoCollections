namespace SunamoCollections;

public partial class CA
{
    /// <summary>
    /// Is all the same string t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="l">The l.</param>
    /// <param name="l2">The l 2.</param>
    /// <returns>The is all the same string t result.</returns>
    public static bool IsAllTheSameString<T>(IList<T> l, IList<T> l2)
    {
        var c1 = l.Count();
        var c2 = l2.Count();
        if (c1 != c2) ThrowEx.DifferentCountInLists("l", l.Count, "l2", l2.Count);

        string s1;
        string s2;

        for (var i = 0; i < c1; i++)
        {
            s1 = l[i].ToString();
            s2 = l2[i].ToString();
            if (s1 != s2) return false;
        }

        return true;
    }

    #region 7) IndexesWithValue

    /// <summary>
    /// Indexes with value t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="videoCodes">The video codes.</param>
    /// <param name="empty">The empty.</param>
    /// <returns>The indexes with value t result.</returns>
    public static List<int> IndexesWithValue<T>(List<T> videoCodes, T empty)
    {
        var result = videoCodes.Select((r, index) => new { dx = index, value = r })
            .Where(d => EqualityComparer<T>.Default.Equals(d.value, empty)).Select(d => d.dx).ToList();
        return result;
    }

    #endregion

    #region 1) ContainsAnyFromElement - For easy copy from CAContainsElementsOrTheirPartsShared.cs

    /// <summary>
    /// Contains any from element bool.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="list/*">The list.</param>
    /// <param name="acceptAsteriskForPassingAll">The accept asterisk for passing all.</param>
    /// <returns>The contains any from element bool result.</returns>
    public static bool ContainsAnyFromElementBool(string s, IList<string> list/*,
        bool acceptAsteriskForPassingAll = false*/)
    {
        if (list.Count() == 1 && list.First() == "*") return true;

        foreach (var item in list)
            if (s.Contains(item))
                return true;

        return false;
    }

    /// <summary>
    /// Contains any from element.
    /// </summary>
    /// <param name="s">The s.</param>
    /// <param name="list">The list.</param>
    /// <returns>The contains any from element result.</returns>
    public static List<int> ContainsAnyFromElement(string s, IList<string> list)
    {
        var result = new List<int>();

        var i = 0;

        foreach (var item in list)
        {
            if (s.Contains(item)) result.Add(i);
            i++;
        }

        return result;
    }

    #endregion

    #region 8) ReturnWhichContainsIndexes

    /// <summary>
    /// Return which contains indexes.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <param name="terms/*">The terms.</param>
    /// <param name="searchStrategy">The search strategy.</param>
    /// <returns>The return which contains indexes result.</returns>
    public static List<int> ReturnWhichContainsIndexes(string item, IList<string> terms/*,
        SearchStrategyCA searchStrategy = SearchStrategyCA.FixedSpace*/)
    {
        var result = new List<int>();
        var i = 0;
        foreach (var term in terms)
        {
            if (item.Contains(term) /*.Contains(item, term, searchStrategy)*/) result.Add(i);
            i++;
        }

        return result;
    }

    /// <summary>
    /// Return which contains indexes.
    /// </summary>
    /// <param name="value">The value.</param>
    /// <param name="term/*">The term.</param>
    /// <param name="searchStrategy">The search strategy.</param>
    /// <returns>The return which contains indexes result.</returns>
    public static List<int> ReturnWhichContainsIndexes(IList<string> value, string term/*,
        SearchStrategyCA searchStrategy = SearchStrategyCA.FixedSpace*/)
    {
        var result = new List<int>();
        var i = 0;
        if (value != null)
            foreach (var item in value)
            {
                if (item.Contains(term) /*.Contains(item, term, searchStrategy)*/) result.Add(i);
                i++;
            }

        return result;
    }

    /// <summary>
    /// Return which contains indexes.
    /// </summary>
    /// <param name="parts">The parts.</param>
    /// <param name="mustContains">The must contains.</param>
    /// <returns>The return which contains indexes result.</returns>
    public static IList<int> ReturnWhichContainsIndexes(IList<string> parts, IList<string> mustContains)
    {
        var result = new List<int>();
        foreach (var item in mustContains) result.AddRange(ReturnWhichContainsIndexes(parts, item));
        result = result.Distinct().ToList();
        return result;
    }

    #endregion
}
