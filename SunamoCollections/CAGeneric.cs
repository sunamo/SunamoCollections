namespace SunamoCollections;

/// <summary>
/// Generic collection utility methods in a separate file due to generic type parameters.
/// </summary>
partial class CA
{
    /// <summary>
    /// Returns the first element of the list, or default if the list is empty.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to get the first element from.</param>
    /// <returns>The first element, or default.</returns>
    public static T? FirstOrNull<T>(List<T> list)
    {
        if (list.Count > 0)
            return list[0];
        return default;
    }

    /// <summary>
    /// Divides a list into groups of the specified size. The list count must be evenly divisible by the group size.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to divide.</param>
    /// <param name="groupSize">The number of elements per group.</param>
    /// <returns>A result containing the divided groups or an exception message.</returns>
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
    /// Divides a list into parts based on a percentage per part.
    /// </summary>
    /// <typeparam name="T">The type of elements in the list.</typeparam>
    /// <param name="list">The list to divide.</param>
    /// <param name="percentPerPart">The percentage each part should contain.</param>
    /// <returns>A list of divided parts.</returns>
    public static List<List<T>> DivideByPercent<T>(List<T> list, int percentPerPart)
    {
        var parts = 100 / percentPerPart;
        var elementsPerPart = list.Count / parts;
        var from = 0;
        var result = new List<List<T>>();
        for (var i = 0; i < parts; i++)
        {
            result.Add(GetIndexesFromTo(list, from, elementsPerPart));
            from += elementsPerPart;
        }

        var hasRemainingElements = from != list.Count;
        if (hasRemainingElements)
            result.Add(GetIndexesFromTo(list, from, list.Count - result[0].Count * parts));
        return result;
    }

    private static List<T> GetIndexesFromTo<T>(List<T> list, int from, int countOfElements)
    {
        var tempArray = new T[countOfElements];
        list.CopyTo(from, tempArray, 0, countOfElements);
        return new List<T>(tempArray);
    }

    /// <summary>
    /// Fills a list with the specified number of default values.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to fill.</param>
    /// <param name="count">The number of default elements to add.</param>
    public static void InitFillWith<T>(List<T> list, int count)
    {
        for (var i = 0; i < count; i++)
            list.Add(default!);
    }

    /// <summary>
    /// Removes all null (default) elements from the list.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to clean.</param>
    public static void RemoveNull<T>(List<T> list)
    {
        var defaultValue = default(T);
        for (var i = list.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(defaultValue, list[i]))
                list.RemoveAt(i);
    }

    /// <summary>
    /// Replaces null elements with the specified empty value.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to process.</param>
    /// <param name="empty">The value to replace null with.</param>
    /// <returns>The processed list.</returns>
    public static List<T> ReplaceNullFor<T>(List<T> list, T empty)
        where T : class
    {
        for (var i = 0; i < list.Count; i++)
            if (list[i] == null)
                list[i] = empty;
        return list;
    }

    /// <summary>
    /// Creates a list from the array and removes default (null) values.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="array">The array of elements.</param>
    /// <returns>A list without default values.</returns>
    public static List<T> ToArrayTCheckNull<T>(params T[] array)
    {
        var result = array.ToList();
        RemoveDefaultT(result);
        return result;
    }

    /// <summary>
    /// Returns the element at the specified index, or default if the index is out of range.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="array">The array to access.</param>
    /// <param name="index">The index to get.</param>
    /// <returns>The element at the index, or default.</returns>
    public static T? IndexOrNull<T>(T[] array, int index)
    {
        if (array.Length > index)
            return array[index];
        return default;
    }

    /// <summary>
    /// Splits an array at the specified index into two arrays. Elements at and after the split index go into the after array.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="array">The array to split.</param>
    /// <param name="splitIndex">The index at which to split.</param>
    /// <param name="before">The elements before the split index.</param>
    /// <param name="after">The elements at and after the split index.</param>
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
    /// Splits a list into chunks of the specified size.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to split.</param>
    /// <param name="chunkSize">The size of each chunk.</param>
    /// <returns>A list of chunks.</returns>
    public static List<List<T>> SplitList<T>(IList<T> list, int chunkSize = 30)
    {
        var result = new List<List<T>>();
        for (var i = 0; i < list.Count; i += chunkSize)
            result.Add(list.ToList().GetRange(i, Math.Min(chunkSize, list.Count - i)));
        return result;
    }

    /// <summary>
    /// Removes trailing padding elements matching the specified value from the end of the list.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to trim.</param>
    /// <param name="value">The padding value to remove.</param>
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
    /// Checks if the list contains the specified element by equality comparison.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to search.</param>
    /// <param name="element">The element to look for.</param>
    /// <returns>True if the element exists in the list.</returns>
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
    /// Converts an IList to a typed List, handling nested collections and char-to-string conversion.
    /// </summary>
    /// <typeparam name="T">The target type.</typeparam>
    /// <param name="list">The list to convert.</param>
    /// <returns>A typed list.</returns>
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
    /// Checks if a single-element list wraps a List of string or object.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to check.</param>
    /// <returns>True if the list wraps a List of string or object.</returns>
    public static bool IsListStringWrappedInArray<T>(List<T> list)
    {
        var first = list.First()!.ToString();
        if (list.Count == 1 && (first == "System.Collections.Generic.List`1[System.String]" || first == "System.Collections.Generic.List`1[System.Object]"))
            return true;
        return false;
    }

    /// <summary>
    /// Removes all default-valued elements from the list. Direct edit.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to clean.</param>
    public static void RemoveDefaultT<T>(List<T> list)
    {
        for (var i = list.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(list[i], default))
                list.RemoveAt(i);
    }

    /// <summary>
    /// Returns indices of elements that have null values. Only for structs.
    /// </summary>
    /// <typeparam name="T">The struct type.</typeparam>
    /// <param name="list">The list of nullable values.</param>
    /// <returns>A list of indices with null values.</returns>
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
    /// Joins multiple IList collections into a single list.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="collections">The collections to join.</param>
    /// <returns>A combined list.</returns>
    public static List<T> JoinIList<T>(params IList<T>[] collections)
    {
        var result = new List<T>();
        foreach (var collection in collections)
            foreach (var element in collection)
                result.Add(element);
        return result;
    }

    /// <summary>
    /// Checks if two lists are equal by comparing elements in sequence.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="firstList">The first list.</param>
    /// <param name="secondList">The second list.</param>
    /// <returns>True if both lists have the same elements in the same order.</returns>
    public static bool IsTheSame<T>(IList<T> firstList, IList<T> secondList)
    {
        return firstList.SequenceEqual(secondList);
    }

    /// <summary>
    /// Randomly shuffles elements in a list.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="list">The list to shuffle.</param>
    /// <returns>The shuffled list.</returns>
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
}
