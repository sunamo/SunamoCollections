namespace SunamoCollections._public.SunamoData.Data;

/// <summary>
/// Represents the ABLCA t type.
/// </summary>
public class ABLCA<T>
{
    /// <summary>
    /// Gets or sets the first group.
    /// </summary>
    public List<T> FirstGroup { get; set; } = default!;

    /// <summary>
    /// Gets or sets the second group.
    /// </summary>
    public List<T> SecondGroup { get; set; } = default!;
}
