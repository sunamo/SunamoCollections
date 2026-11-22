namespace SunamoCollections;

// all that are params string[] or params T[]
public partial class CA
{
    // Dont use
    /// <summary>
    /// Two dimension params into one.
    /// </summary>
    /// <param name="para">The para.</param>
    /// <returns>The two dimension params into one result.</returns>
    [ObjectParamsObsolete]
    public static List<object> TwoDimensionParamsIntoOne(params object[] para)
    {
        return TwoDimensionParamsIntoOne<object>(para);
    }

    // Join elements of inner IList to single list
    // T is object, not IList
    // Multi deep array is not suppported
    // For convert into string use ListToString
    /// <summary>
    /// Two dimension params into one t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="para">The para.</param>
    /// <returns>The two dimension params into one t result.</returns>
    [ObjectParamsObsolete]
    public static List<T> TwoDimensionParamsIntoOne<T>(params T[] para)
    {
        var result = new List<T>();
        foreach (var item in para)
        {
            if (item == null) continue;

            if (item is IList && item.GetType() != typeof(string))
                foreach (T r in (IList)item)
                    result.Add(r);
            else
                result.Add(item);
        }

        return result;
    }

    ///// <summary>
    ///// Try to use as little as possible, because the generic type should be specified everywhere.
    ///// So no IEnumerable or IList should appear in the app.
    ///// </summary>
    ///// <param name="enumerable"></param>
    ///// <returns></returns>
    private static List<object> ToListMoreObject(params object[] enumerable)
    {
        var result = new List<object>();

        foreach (var item in enumerable) result.Add(item);

        return result;
    }

    ///// <summary>
    /////     ToListString2 - simply for all items call ToString()
    /////     ToListString - working with type of every element
    ///// </summary>
    ///// <param name="enumerable"></param>
}
