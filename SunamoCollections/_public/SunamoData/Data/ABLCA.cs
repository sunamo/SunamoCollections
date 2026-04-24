namespace SunamoCollections._public.SunamoData.Data;

/// <summary>
/// A pair of lists representing two groups for comparison results.
/// </summary>
/// <typeparam name="T">The type of elements in both lists.</typeparam>
public class ABLCA<T>
{
    /// <summary>
    /// Gets or sets the first group of elements.
    /// </summary>
    public List<T> FirstGroup { get; set; } = default!;

    /// <summary>
    /// Gets or sets the second group of elements.
    /// </summary>
    public List<T> SecondGroup { get; set; } = default!;
}
