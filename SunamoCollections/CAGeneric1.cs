namespace SunamoCollections;

/// <summary>
/// Generic collection utility methods - part 1. Additional generic methods in a separate file.
/// </summary>
partial class CA
{
    /// <summary>
    /// Converts an IList to a typed list, handling string conversion from char lists and nested collections.
    /// </summary>
    /// <typeparam name="T">The target type.</typeparam>
    /// <param name="enumerable">The list to convert.</param>
    /// <returns>A typed list.</returns>
    private static List<T> ToListT2<T>(IList enumerable)
    {
        if (typeof(T) == Types.TString)
        {
            var stringResults = new List<T>();
            foreach (var item in enumerable)
                if (item is IList)
                {
                    var nestedList = (IList)item;
                    var stringBuilder = new StringBuilder();
                    foreach (var element in nestedList)
                        stringBuilder.Append(element);
                    object convertedString = stringBuilder.ToString();
                    stringResults.Add((T)convertedString);
                }
                else if (item is char)
                {
                    var stringBuilder = new StringBuilder();
                    foreach (var element in enumerable)
                        stringBuilder.Append(element);
                    object convertedString = stringBuilder.ToString();
                    stringResults.Add((T)convertedString);
                    break;
                }
                else
                {
                    stringResults.Add((T)(IEnumerable<char>)item.ToString()!);
                }

            return stringResults;
        }

        var result = new List<T>(enumerable.Count());
        foreach (var item in enumerable)
            if (item == null)
                result.Add(default!);
            else
                result.Add((T)item);
        return result;
    }

    /// <summary>
    /// Randomly shuffles elements in an array.
    /// </summary>
    /// <typeparam name="T">The type of elements.</typeparam>
    /// <param name="array">The array to shuffle.</param>
    /// <returns>The shuffled array.</returns>
    public static T[] JumbleUp<T>(T[] array)
    {
        var length = array.Length;
        var random = new Random();
        for (var i = 0; i < length; ++i)
        {
            var index1 = random.Next() % length;
            var index2 = random.Next() % length;
            var swapTemp = array[index1];
            array[index1] = array[index2];
            array[index2] = swapTemp;
        }

        return array;
    }
}
