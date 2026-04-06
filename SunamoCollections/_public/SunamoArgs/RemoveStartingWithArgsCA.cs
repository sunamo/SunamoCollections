namespace SunamoCollections._public.SunamoArgs;

/// <summary>
/// Public arguments for the RemoveStartingWith operation.
/// </summary>
public class RemoveStartingWithArgsCA
{
    /// <summary>
    /// Gets or sets whether to trim elements before finding matches.
    /// </summary>
    public bool TrimBeforeFinding { get; set; } = false;

    /// <summary>
    /// Gets or sets whether the comparison is case-sensitive.
    /// </summary>
    public bool CaseSensitive { get; set; } = true;
}
