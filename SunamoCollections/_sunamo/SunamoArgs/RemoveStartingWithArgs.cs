namespace SunamoCollections._sunamo.SunamoArgs;

/// <summary>
/// Internal arguments for the RemoveStartingWith operation.
/// </summary>
internal class RemoveStartingWithArgs
{
    /// <summary>
    /// Gets or sets whether to trim elements before finding matches.
    /// </summary>
    internal bool TrimBeforeFinding { get; set; } = false;

    /// <summary>
    /// Gets or sets whether the comparison is case-sensitive.
    /// </summary>
    internal bool CaseSensitive { get; set; } = true;
}
