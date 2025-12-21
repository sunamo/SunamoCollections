namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
/// V samostatném souboru kvůli <T>
/// Do CAG to nejde, musel bych upravovat i ty v _sunamo všude
/// </summary>
partial class CA
{
    /// <summary>
    ///     better is use first or default, because here I also have to use default(T)
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "List"></param>
    public static T FirstOrNull<T>(List<T> list)
    {
        if (list.Count > 0)
            return list[0];
        return default;
    }

    public static ResultWithExceptionCollections<List<List<T>>> DivideBy<T>(List<T> items, int groupSize)
    {
        if (items.Count % groupSize != 0)
        {
            return new ResultWithExceptionCollections<List<List<T>>>(new Exception($"Elements in {nameof(items)} - {items.Count} is not dividable by {nameof(groupSize)} - {groupSize}"));
        }

        List<List<T>> result = new List<List<T>>();
        List<T> currentGroup = new List<T>();
        foreach (var item in items)
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

    public static List<List<T>> DivideByPercent<T>(List<T> items, int percentPerPart)
    {
        var parts = 100 / percentPerPart;
        var elementsPerPart = items.Count / parts;
        var from = 0;
        var result = new List<List<T>>();
        for (var i = 0; i < parts; i++)
        {
            result.Add(GetIndexesFromTo(items, from, elementsPerPart));
            from += elementsPerPart;
        }

        var hasRemainingElements = from != items.Count;
        if (hasRemainingElements)
            result.Add(GetIndexesFromTo(items, from, items.Count - result[0].Count * parts));
        return result;
    }

    private static List<T> GetIndexesFromTo<T>(List<T> items, int from, int countOfElements)
    {
        var tempArray = new T[countOfElements];
        items.CopyTo(from, tempArray, 0, countOfElements);
        return new List<T>(tempArray);
    }

    public static void InitFillWith<T>(List<T> list, int count)
    {
        for (var i = 0; i < count; i++)
            list.Add(default);
    }

    public static void RemoveNull<T>(List<T> list)
    {
        var def = default(T);
        for (var i = list.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(def, list[i]))
                list.RemoveAt(i);
    }

    public static List<T> ReplaceNullFor<T>(List<T> list, T empty)
        where T : class
    {
        for (var i = 0; i < list.Count; i++)
            if (list[i] == null)
                list[i] = empty;
        return list;
    }

    public static List<T> ToArrayTCheckNull<T>(params T[] items)
    {
        var result = items.ToList();
        RemoveDefaultT(result);
        return result;
    }

    public static T IndexOrNull<T>(T[] array, int index)
    {
        if (array.Length > index)
            return array[index];
        return default;
    }

    /// <summary>
    ///     Index A2 a další bude již v poli A4
    /// </summary>
    /// <param name = "array"></param>
    /// <param name = "splitIndex"></param>
    /// <param name = "before"></param>
    /// <param name = "after"></param>
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
                after[i] = array[i - splitIndex];
        }
    }

    public static List<List<T>> SplitList<T>(IList<T> list, int chunkSize = 30)
    {
        var result = new List<List<T>>();
        for (var i = 0; i < list.Count; i += chunkSize)
            result.Add(list.ToList().GetRange(i, Math.Min(chunkSize, list.Count - i)));
        return result;
    }

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
    /// <typeparam name = "T"></typeparam>
    /// <param name = "list"></param>
    /// <param name = "element"></param>
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
    ///     element can be null, then will be added as default(T)
    ///     If item is null, add instead it default(T)
    ///     cant join from IList elements because there must be T2 for element's Type of collection
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "enumerable"></param>
    public static List<T> ToList<T>(IList enumerable)
    {
        // system array etc cant be casted
        //var ien = enumerable as IList<object>;
        var ien = enumerable as List<object>;
        var ienf = ien.FirstOrNull() as IList;
        List<T> result = null;
        //if (enumerable is IList<char>)
        //{
        //    result = new List<T>(1);
        //    result.Add(SHJoin.JoinIList(string.Empty, enumerable));
        //}
        var b1 = ien != null;
        var b2 = typeof(T) == Types.TString;
        var b3 = ienf.Count > 1;
        var b4 = false;
        var b5 = false;
        if (ienf != null)
        {
            var f = ienf.FirstOrNull();
            if (f != null)
                b4 = f.GetType() == Types.TChar;
        }

        if (ien != null)
        {
            var last = ien.Last();
            if (last != null)
                b5 = last.GetType() == Types.TChar;
        }

        if (enumerable.Count == 1 && enumerable.FirstOrNull() is IList<object>)
            result = ToListT2<T>((IList)enumerable.FirstOrNull());
        else if (b1 && b2 && b3 && b4 && b5)
            result.Add((T)(dynamic)string.Join(string.Empty, enumerable));
        else if (enumerable.Count() == 1 && enumerable.FirstOrNull() is IList)
            result = ToListT2<T>((IList)enumerable.FirstOrNull());
        else
            return ToListT2<T>(enumerable);
        return result;
    }

    public static bool IsListStringWrappedInArray<T>(List<T> list)
    {
        var first = list.First().ToString();
        if (list.Count == 1 && (first == "System.Collections.Generic.List`1[System.String]" || first == "System.Collections.Generic.List`1[System.Object]"))
            return true;
        return false;
    }

    /// <summary>
    ///     Direct edit
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "collection"></param>
    public static void RemoveDefaultT<T>(List<T> collection)
    {
        for (var i = collection.Count - 1; i >= 0; i--)
            if (EqualityComparer<T>.Default.Equals(collection[i], default))
                collection.RemoveAt(i);
    }

    /// <summary>
    ///     Only for structs
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "list"></param>
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

    public static List<T> JoinIList<T>(params IList<T>[] enumerable)
    {
        var result = new List<T>();
        foreach (var item in enumerable)
            foreach (var item2 in item)
                result.Add(item2);
        return result;
    }

    /// <summary>
    ///     Simply calling SequenceEqual
    /// </summary>
    /// <typeparam name = "T"></typeparam>
    /// <param name = "first"></param>
    /// <param name = "second"></param>
    /// <returns></returns>
    public static bool IsTheSame<T>(IList<T> first, IList<T> second)
    {
        return first.SequenceEqual(second);
    }

    public static List<T> JumbleUp<T>(List<T> items)
    {
        var length = items.Count;
        var random = new Random();
        for (var i = 0; i < length; ++i)
        {
            var index1 = random.Next() % length;
            var index2 = random.Next() % length;
            var temp = items[index1];
            items[index1] = items[index2];
            items[index2] = temp;
        }

        return items;
    }
}