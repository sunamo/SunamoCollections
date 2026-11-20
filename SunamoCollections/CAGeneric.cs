namespace SunamoCollections;

partial class CA
{
    /// <summary>
    /// First or null t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The first or null t result.</returns>
    public static T? FirstOrNull<T>(List<T> list)
    {
        if (list.Count > 0)
            return list[0];
        return default;
    }

    /// <summary>
    /// Divide by t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="groupSize">The group size.</param>
    /// <returns>The divide by t result.</returns>
    public static ResultWithExceptionCollections<List<List<T>>> DivideBy<T>(List<T> list, int groupSize)
    {
        if (list.Count % groupSize != 0)
        {
            return new ResultWithExceptionCollections<List<List<T>>>(new Exception($"Elements in {nameof(list)} - {list.Count} is not dividable by {nameof(groupSize)} - {groupSize}"));
        }

        List<List<T>> result = new List<List<T>>();
        List<T> currentGroup = new List<T>();
        foreach (var item in list)
        {
            currentGroup.Add(item);
            if (currentGroup.Count == groupSize)
            {
                result.Add(currentGroup);
                currentGroup = new List<T>();
            }
        }

        return new ResultWithExceptionCollections<List<List<T>>>(result);
    }

    /// <summary>
    /// Divide by percent t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="percentPerPart">The percent per part.</param>
    /// <returns>The divide by percent t result.</returns>
    public static List<List<T>> DivideByPercent<T>(List<T> list, int percentPerPart)
    {
        var parts = 100 / percentPerPart;
        var elementsPerPart = list.Count / parts;
        var startIndex = 0;
        var result = new List<List<T>>();
        for (var i = 0; i < parts; i++)
        {
            result.Add(GetIndexesFromTo(list, startIndex, elementsPerPart));
            startIndex += elementsPerPart;
        }

        var hasRemainingElements = startIndex != list.Count;
        if (hasRemainingElements)
            result.Add(GetIndexesFromTo(list, startIndex, list.Count - result[0].Count * parts));
        return result;
    }

    private static List<T> GetIndexesFromTo<T>(List<T> list, int startIndex, int elementCount)
    {
        var tempArray = new T[elementCount];
        list.CopyTo(startIndex, tempArray, 0, elementCount);
        return new List<T>(tempArray);
    }

    /// <summary>
    /// Init fill with t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="count">The count.</param>
    public static void InitFillWith<T>(List<T> list, int count)
    {
        for (var i = 0; i < count; i++)
            list.Add(default!);
    }

    /// <summary>
    /// Remove null t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    public static void RemoveNull<T>(List<T> list)
    {
        var defaultValue = default(T);
        for (var i = list.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(defaultValue, list[i]))
                list.RemoveAt(i);
    }

    /// <summary>
    /// Replace null for t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="empty">The empty.</param>
    /// <returns>The replace null for t result.</returns>
    public static List<T> ReplaceNullFor<T>(List<T> list, T empty)
        where T : class
    {
        for (var i = 0; i < list.Count; i++)
            if (list[i] == null)
                list[i] = empty;
        return list;
    }

    /// <summary>
    /// To array t check null t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="array">The array.</param>
    /// <returns>The to array t check null t result.</returns>
    public static List<T> ToArrayTCheckNull<T>(params T[] array)
    {
        var result = array.ToList();
        RemoveDefaultT(result);
        return result;
    }

    /// <summary>
    /// Index or null t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="array">The array.</param>
    /// <param name="index">The index.</param>
    /// <returns>The index or null t result.</returns>
    public static T? IndexOrNull<T>(T[] array, int index)
    {
        if (array.Length > index)
            return array[index];
        return default;
    }

    /// <summary>
    /// Split t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="array">The array.</param>
    /// <param name="splitIndex">The split index.</param>
    /// <param name="before">The before.</param>
    /// <param name="after">The after.</param>
    public static void Split<T>(T[] array, int splitIndex, out T[] before, out T[] after)
    {
        before = new T[splitIndex];
        var arrayLength = array.Length;
        after = new T[arrayLength - splitIndex];
        var isBeforeSplit = true;
        for (var i = 0; i < arrayLength; i++)
        {
            if (i == splitIndex)
                isBeforeSplit = false;
            if (isBeforeSplit)
                before[i] = array[i];
            else
                after[i - splitIndex] = array[i];
        }
    }

    /// <summary>
    /// Split list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="chunkSize">The chunk size.</param>
    /// <returns>The split list t result.</returns>
    public static List<List<T>> SplitList<T>(IList<T> list, int chunkSize = 30)
    {
        var result = new List<List<T>>();
        for (var i = 0; i < list.Count; i += chunkSize)
            result.Add(list.ToList().GetRange(i, Math.Min(chunkSize, list.Count - i)));
        return result;
    }

    /// <summary>
    /// Remove padding t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="value">The value.</param>
    public static void RemovePadding<T>(List<T> list, T value)
    {
        for (var i = list.Count - 1; i >= 0; i--)
        {
            if (!EqualityComparer<T>.Default.Equals(list[i], value))
                break;
            list.RemoveAt(i);
        }
    }

    /// <summary>
    /// Contains element t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <param name="element">The element.</param>
    /// <returns>The contains element t result.</returns>
    public static bool ContainsElement<T>(IList<T> list, T element)
    {
        if (list.Count() == 0)
            return false;
        foreach (var item in list)
            if (Equals(item, element))
                return true;
        return false;
    }

    /// <summary>
    /// To list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The to list t result.</returns>
    public static List<T> ToList<T>(IList list)
    {
        var enumerableAsList = list as List<object>;
        var firstElementAsList = enumerableAsList?.FirstOrNull() as IList;
        List<T>? result = null;
        var isEnumerableList = enumerableAsList != null;
        var isTargetTypeString = typeof(T) == Types.TString;
        var hasMultipleElements = firstElementAsList != null && firstElementAsList.Count > 1;
        var isFirstElementChar = false;
        var isLastElementChar = false;
        if (firstElementAsList != null)
        {
            var firstElement = firstElementAsList.FirstOrNull();
            if (firstElement != null)
                isFirstElementChar = firstElement.GetType() == Types.TChar;
        }

        if (enumerableAsList != null)
        {
            var lastElement = enumerableAsList.Last();
            if (lastElement != null)
                isLastElementChar = lastElement.GetType() == Types.TChar;
        }

        if (list.Count == 1 && list.FirstOrNull() is IList<object>)
            result = ToListT2<T>((IList)list.FirstOrNull()!);
        else if (isEnumerableList && isTargetTypeString && hasMultipleElements && isFirstElementChar && isLastElementChar)
            result!.Add((T)(dynamic)string.Join(string.Empty, list));
        else if (list.Count() == 1 && list.FirstOrNull() is IList)
            result = ToListT2<T>((IList)list.FirstOrNull()!);
        else
            return ToListT2<T>(list);
        return result!;
    }

    /// <summary>
    /// Is list string wrapped in array t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The is list string wrapped in array t result.</returns>
    public static bool IsListStringWrappedInArray<T>(List<T> list)
    {
        var first = list.First()!.ToString();
        if (list.Count == 1 && (first == "System.Collections.Generic.List`1[System.String]" || first == "System.Collections.Generic.List`1[System.Object]"))
            return true;
        return false;
    }

    /// <summary>
    /// Remove default t t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    public static void RemoveDefaultT<T>(List<T> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(list[i], default))
                list.RemoveAt(i);
    }

    /// <summary>
    /// Indexes with null t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The indexes with null t result.</returns>
    public static List<int> IndexesWithNull<T>(List<T?> list)
        where T : struct
    {
        var nulled = new List<int>();
        for (var i = 0; i < list.Count; i++)
        {
            if (!list[i].HasValue)
                nulled.Add(i);
        }

        return nulled;
    }

    /// <summary>
    /// Join i list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="collections">The collections.</param>
    /// <returns>The join i list t result.</returns>
    public static List<T> JoinIList<T>(params IList<T>[] collections)
    {
        var result = new List<T>();
        foreach (var collection in collections)
            foreach (var element in collection)
                result.Add(element);
        return result;
    }

    /// <summary>
    /// Is the same t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="firstList">The first list.</param>
    /// <param name="secondList">The second list.</param>
    /// <returns>The is the same t result.</returns>
    public static bool IsTheSame<T>(IList<T> firstList, IList<T> secondList)
    {
        return firstList.SequenceEqual(secondList);
    }

    /// <summary>
    /// Jumble up t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="list">The list.</param>
    /// <returns>The jumble up t result.</returns>
    public static List<T> JumbleUp<T>(List<T> list)
    {
        var length = list.Count;
        var random = new Random();
        for (var i = 0; i < length; ++i)
        {
            var index1 = random.Next() % length;
            var index2 = random.Next() % length;
            var swapTemp = list[index1];
            list[index1] = list[index2];
            list[index2] = swapTemp;
        }

        return list;
    }

    /// <summary>
    /// To array t t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="items">The items.</param>
    /// <returns>The to array t t result.</returns>
    public static T[] ToArrayT<T>(params T[] items)
    {
        return items;
    }

    /// <summary>
    /// Indexes with null or empty.
    /// </summary>
    /// <param name="list">The list.</param>
    /// <returns>The indexes with null or empty result.</returns>
    public static List<int> IndexesWithNullOrEmpty(List<object?> list)
    {
        var result = new List<int>();
        for (var i = 0; i < list.Count; i++)
        {
            if (list[i] is null || (list[i] is string s && s == string.Empty)) result.Add(i);
        }
        return result;
    }
}
