namespace SunamoCollections._public.SunamoEnums.Enums;

/// <summary>
/// Specifies the comparison method used when checking if a string contains elements.
/// </summary>
public enum ContainsCompareMethodCA
{
    /// <summary>
    /// Compare using the whole input string.
    /// </summary>
    WholeInput,

    /// <summary>
    /// Split the input into words and check each word.
    /// </summary>
    SplitToWords,

    /// <summary>
    /// Support negation patterns in the comparison.
    /// </summary>
    Negations
}