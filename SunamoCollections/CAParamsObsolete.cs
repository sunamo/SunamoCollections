// variables names: ok
namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
/// <summary>
///     všechny co jsou params string[] nebo params T[]
/// </summary>
public partial class CA
{
    /// <summary>
    ///     Dont use
    /// </summary>
    /// <param name="parameters"></param>
    [ObjectParamsObsolete]
    public static List<object> TwoDimensionParamsIntoOne(params object[] parameters)
    {
        return TwoDimensionParamsIntoOne<object>(parameters);
    }

    /// <summary>
    ///     Join elements of inner IList to single List
    ///     T is object, not IList
    ///     Multi deep array is not suppported
    ///     For convert into string use ListToString
    /// </summary>
    [ObjectParamsObsolete]
    public static List<T> TwoDimensionParamsIntoOne<T>(params T[] parameters)
    {
        var result = new List<T>();
        foreach (var item in parameters)
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
    ///// Snažit se používat absolutně co nejméně protože všude by měl být specifikovaný generický typ.
    ///// Tedy žádné IEnumerable nebo IList by se neměli v app vyskytovat.
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
    /////     ToListString - working with Type of every element
    ///// </summary>
    ///// <param name="enumerable"></param>
    //public static List<string> ToListStringMoreObject(params object[] enumerable)
    //{
    //    return ToListStringIList(enumerable);
    //}
}