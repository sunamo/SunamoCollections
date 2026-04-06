namespace SunamoCollections._public.SunamoData.Data;

/// <summary>
/// Generic from-to range container with long-based internal storage.
/// </summary>
/// <typeparam name="T">The type used for From and To values.</typeparam>
public class FromToTSHCollections<T>
{
    /// <summary>
    /// Gets or sets whether this range is empty.
    /// </summary>
    public bool Empty { get; set; }

    private long from;

    /// <summary>
    /// Gets or sets the format used for From/To values.
    /// </summary>
    public FromToUseCollections FromToUse { get; set; } = FromToUseCollections.DateTime;

    private long to;

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
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
    /// Initializes a new instance with the specified from and to values.
    /// </summary>
    /// <param name="from">The start value.</param>
    /// <param name="to">The end value.</param>
    /// <param name="fromToUse">The format to use for the values.</param>
    public FromToTSHCollections(T from, T to, FromToUseCollections fromToUse = FromToUseCollections.DateTime) : this()
    {
        From = from;
        To = to;
        FromToUse = fromToUse;
    }

    /// <summary>
    /// Gets or sets the start value of the range.
    /// </summary>
    public T From
    {
        get => (T)(dynamic)from!;
        set => from = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets or sets the end value of the range.
    /// </summary>
    public T To
    {
        get => (T)(dynamic)to!;
        set => to = (long)(dynamic)value!;
    }

    /// <summary>
    /// Gets the From value as a long.
    /// </summary>
    public long FromAsLong => from;

    /// <summary>
    /// Gets the To value as a long.
    /// </summary>
    public long ToAsLong => to;
}
