namespace SunamoCollections;

/// <summary>
/// Methods using params string[] or params T[] patterns.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Flattens two-dimensional params into a single list. Do not use directly.
    /// </summary>
    /// <param name="parameters">The parameters to flatten.</param>
    /// <returns>A flattened list of objects.</returns>
    [ObjectParamsObsolete]
    public static List<object> TwoDimensionParamsIntoOne(params object[] parameters)
    {
        return TwoDimensionParamsIntoOne<object>(parameters);
    }

    /// <summary>
    /// Flattens elements of inner IList collections into a single typed list.
    /// Multi-deep arrays are not supported.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="parameters">The parameters to flatten.</param>
    /// <returns>A flattened typed list.</returns>
    [ObjectParamsObsolete]
    public static List<T> TwoDimensionParamsIntoOne<T>(params T[] parameters)
    {
        var result = new List<T>();
        foreach (var item in parameters)
        {
            if (item == null) continue;

            if (item is IList && item.GetType() != typeof(string))
                foreach (T element in (IList)item)
                    result.Add(element);
            else
                result.Add(item);
        }

        return result;
    }

    /// <summary>
    /// Converts params objects into a list of objects.
    /// </summary>
    /// <param name="enumerable">The objects to convert.</param>
    /// <returns>A list of objects.</returns>
    private static List<object> ToListMoreObject(params object[] enumerable)
    {
        var result = new List<object>();

        foreach (var item in enumerable) result.Add(item);

        return result;
    }
}
