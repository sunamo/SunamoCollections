namespace SunamoCollections._public.SunamoEnums.Enums;

/// <summary>
/// Specifies the format used for From/To range values.
/// </summary>
public enum FromToUseCollections
{
    /// <summary>
    /// DateTime-based range values.
    /// </summary>
    DateTime,

    /// <summary>
    /// Unix timestamp-based range values.
    /// </summary>
    Unix,

    /// <summary>
    /// Unix timestamp with time-only values.
    /// </summary>
    UnixJustTime,

    /// <summary>
    /// No specific format.
    /// </summary>
    None
}