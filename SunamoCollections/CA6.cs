namespace SunamoCollections;

// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
public partial class CA
{
    /// <summary>
    ///     Change elements count in collection to A2
    /// </summary>
    /// <param name = "input"></param>
    /// <param name = "requiredLength"></param>
    public static List<string> ToSize(List<string> input, int requiredLength)
    {
        List<string> returnArray = null;
        var realLength = input.Count;
        if (realLength > requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            for (var i = 0; i < requiredLength; i++)
                returnArray[i] = input[i];
            return returnArray;
        }

        if (realLength == requiredLength)
        {
            return input;
        }

        if (realLength < requiredLength)
        {
            returnArray = new List<string>(requiredLength);
            InitFillWith(returnArray, requiredLength);
            var i = 0;
            for (; i < realLength; i++)
                returnArray[i] = input[i];
            for (; i < requiredLength; i++)
                returnArray[i] = null;
        }

        return returnArray;
    }

    public static List<string> Format(string formatString, List<string> args)
    {
        for (var i = 0; i < args.Count(); i++)
            args[i] = /*string.Format*/ string.Format(formatString, args[i]);
        return args;
    }

    //public static int Count(IList e)
    //{
    //    return se.CA.Count(e);
    //}
    /// <summary>
    ///     Direct edit
    ///     Must return because is used with params string[]
    /// </summary>
    /// <param name = "trimChar"></param>
    /// <param name = "text"></param>
    public static List<string> TrimStartChar(char trimChar, List<string> text)
    {
        for (var i = 0; i < text.Count; i++)
            text[i] = text[i].TrimStart(trimChar);
        return text;
    }
}