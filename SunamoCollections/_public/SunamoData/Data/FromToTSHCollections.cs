namespace SunamoCollections._public.SunamoData.Data;

/// <summary>
/// Represents the from to TSH collections t type.
/// </summary>
public class FromToTSHCollections<T>
{
    /// <summary>
    /// Gets or sets the empty.
    /// </summary>
    public bool Empty { get; set; }

    private long from;

    /// <summary>
    /// Gets or sets the from to use.
    /// </summary>
    public FromToUseCollections FromToUse { get; set; } = FromToUseCollections.DateTime;

    private long to;

    /// <summary>
    /// From to TSH collections.
    /// </summary>
    /// <returns>The from to TSH collections result.</returns>
    public FromToTSHCollections()
    {
        var type = typeof(T);
        if (type == typeof(int)) FromToUse = FromToUseCollections.None;
    }

    private FromToTSHCollections(bool isEmpty) : this()
    {
        Empty = isEmpty;
    }

    /// <summary>
    /// From to TSH collections.
    /// </summary>
    /// <param name="isEmpty">The is empty.</param>
    /// <returns>The from to TSH collections result.</returns>
    public FromToTSHCollections(T from, T to, FromToUseCollections fromToUse = FromToUseCollections.DateTime) : this()
    {
        From = from;
        To = to;
        FromToUse = fromToUse;
    }

    /// <summary>
    /// The from.
    /// </summary>
    public T From
    {
        get => (T)(dynamic)from!;
        set => from = (long)(dynamic)value!;
    }

    /// <summary>
    /// The to.
    /// </summary>
    public T To
    {
        get => (T)(dynamic)to!;
        set => to = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets the from as long.
    /// </summary>
    public long FromAsLong => from;

    /// <summary>
    /// Gets the to as long.
    /// </summary>
    public long ToAsLong => to;
}
