namespace SunamoCollections;

/// <summary>
/// Collection utility class - part 6.
/// </summary>
public partial class CA
{
    /// <summary>
    /// Changes the element count in a collection to the required length by truncating or padding with null.
    /// </summary>
    /// <param name="list">The source list.</param>
    /// <param name="requiredLength">The target length.</param>
    /// <returns>A list with the specified number of elements.</returns>
    public static List<string> ToSize(List<string> list, int requiredLength)
    {
        List<string>? returnArray = null;
        var realLength = list.Count;
        if (realLength > requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            for (var i = 0; i < requiredLength; i++)
                returnArray[i] = list[i];
            return returnArray;
        }

        if (realLength == requiredLength)
        {
            return list;
        }

        if (realLength < requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            var i = 0;
            for (; i < realLength; i++)
                returnArray[i] = list[i];
            for (; i < requiredLength; i++)
                returnArray[i] = null!;
        }

        return returnArray!;
    }

    /// <summary>
    /// Formats each element using the specified format string. Direct edit.
    /// </summary>
    /// <param name="formatString">The format string.</param>
    /// <param name="list">The list of arguments to format.</param>
    /// <returns>The list with formatted elements.</returns>
    public static List<string> Format(string formatString, List<string> list)
    {
        for (var i = 0; i < list.Count(); i++)
            list[i] = string.Format(formatString, list[i]);
        return list;
    }

    /// <summary>
    /// Trims the specified character from the start of each element. Direct edit.
    /// </summary>
    /// <param name="trimChar">The character to trim.</param>
    /// <param name="list">The list to process.</param>
    /// <returns>The processed list.</returns>
    public static List<string> TrimStartChar(char trimChar, List<string> list)
    {
        for (var i = 0; i < list.Count; i++)
            list[i] = list[i].TrimStart(trimChar);
        return list;
    }
}
