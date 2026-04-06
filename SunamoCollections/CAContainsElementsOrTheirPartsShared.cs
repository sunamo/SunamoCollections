namespace SunamoCollections;

/// <summary>
/// Shared methods for checking element containment and finding matching indices.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Checks if two lists of the same type have equal string representations for all elements.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="firstList">The first list.</param>
    /// <param name="secondList">The second list.</param>
    /// <returns>True if all elements have equal string representations.</returns>
    public static bool IsAllTheSameString<T>(IList<T> firstList, IList<T> secondList)
    {
        var firstListCount = firstList.Count();
        var secondListCount = secondList.Count();
        if (firstListCount != secondListCount) ThrowEx.DifferentCountInLists("firstList", firstList.Count, "secondList", secondList.Count);

        string? firstValue;
        string? secondValue;

        for (var i = 0; i < firstListCount; i++)
        {
            firstValue = firstList[i]?.ToString();
            secondValue = secondList[i]?.ToString();
            if (firstValue != secondValue) return false;
        }

        return true;
    }

    /// <summary>
    /// Returns the indices in the list where the element equals the specified candidate.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to search.</param>
    /// <param name="candidate">The value to find.</param>
    /// <returns>A list of indices with matching values.</returns>
    public static List<int> IndexesWithValue<T>(List<T> list, T candidate)
    {
        var result = list.Select((element, index) => new { Index = index, Value = element })
            .Where(pair => EqualityComparer<T>.Default.Equals(pair.Value, candidate)).Select(pair => pair.Index).ToList();
        return result;
    }

    /// <summary>
    /// Checks if the text contains any candidate from the list. Returns true on first match.
    /// </summary>
    /// <param name="text">The text to search in.</param>
    /// <param name="candidates">The candidates to look for.</param>
    /// <returns>True if any candidate is found in the text.</returns>
    public static bool ContainsAnyFromElementBool(string text, IList<string> candidates)
    {
        if (candidates.Count() == 1 && candidates.First() == "*") return true;

        foreach (var item in candidates)
            if (text.Contains(item))
                return true;

        return false;
    }

    /// <summary>
    /// Returns the indices of candidates that are contained in the text.
    /// </summary>
    /// <param name="text">The text to search in.</param>
    /// <param name="candidates">The candidates to look for.</param>
    /// <returns>A list of indices of matching candidates.</returns>
    public static List<int> ContainsAnyFromElement(string text, IList<string> candidates)
    {
        var result = new List<int>();

        var currentIndex = 0;

        foreach (var item in candidates)
        {
            if (text.Contains(item)) result.Add(currentIndex);
            currentIndex++;
        }

        return result;
    }

    /// <summary>
    /// Returns the indices of candidates that the text contains.
    /// </summary>
    /// <param name="text">The text to search in.</param>
    /// <param name="candidates">The candidates to check.</param>
    /// <returns>A list of indices of matching candidates.</returns>
    public static List<int> ReturnWhichContainsIndexes(string text, IList<string> candidates)
    {
        var result = new List<int>();
        var currentIndex = 0;
        foreach (var term in candidates)
        {
            if (text.Contains(term)) result.Add(currentIndex);
            currentIndex++;
        }

        return result;
    }

    /// <summary>
    /// Returns the indices of elements in the list that contain the specified candidate.
    /// </summary>
    /// <param name="list">The list to search.</param>
    /// <param name="candidate">The candidate to look for.</param>
    /// <returns>A list of indices of matching elements.</returns>
    public static List<int> ReturnWhichContainsIndexes(IList<string> list, string candidate)
    {
        var result = new List<int>();
        var currentIndex = 0;
        if (list != null)
            foreach (var item in list)
            {
                if (item.Contains(candidate)) result.Add(currentIndex);
                currentIndex++;
            }

        return result;
    }

    /// <summary>
    /// Returns the indices of elements in the list that contain any of the specified candidates.
    /// </summary>
    /// <param name="list">The list to search.</param>
    /// <param name="candidates">The candidates to look for.</param>
    /// <returns>A list of distinct indices of matching elements.</returns>
    public static IList<int> ReturnWhichContainsIndexes(IList<string> list, IList<string> candidates)
    {
        var result = new List<int>();
        foreach (var item in candidates) result.AddRange(ReturnWhichContainsIndexes(list, item));
        result = result.Distinct().ToList();
        return result;
    }
}
