namespace SunamoCollections._public.SunamoEnums.Enums;

/// <summary>
/// Specifies the strategy used when searching for string matches.
/// </summary>
public enum SearchStrategyCA
{
    /// <summary>
    /// Match using fixed space comparison.
    /// </summary>
    FixedSpace,

    /// <summary>
    /// Match allowing any whitespace between words.
    /// </summary>
    AnySpaces,

    /// <summary>
    /// Match using exact name comparison.
    /// </summary>
    ExactlyName
}