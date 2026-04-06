namespace SunamoCollections._public.SunamoData.Data;

/// <summary>
/// A pair of lists representing two groups (A and B) for comparison results.
/// </summary>
/// <typeparam name="T">The type of elements in the A list.</typeparam>
/// <typeparam name="U">The type parameter for the B list (uses T for elements).</typeparam>
public class ABLCA<T, U>
{
    /// <summary>
    /// Gets or sets the first group of elements.
    /// </summary>
    public List<T> A { get; set; } = default!;

    /// <summary>
    /// Gets or sets the second group of elements.
    /// </summary>
    public List<T> B { get; set; } = default!;
}
