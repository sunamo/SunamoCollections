namespace SunamoCollections._public.SunamoData.Data;

/// <summary>
/// Long-based from-to range container.
/// </summary>
public class FromToCollections : FromToTSHCollections<long>
{
    /// <summary>
    /// An empty range instance.
    /// </summary>
    public static new FromToCollections Empty = new(true);

    /// <summary>
    /// Initializes a new instance with default values.
    /// </summary>
    public FromToCollections()
    {
    }

    private FromToCollections(bool isEmpty) : base()
    {
        base.Empty = isEmpty;
    }

    /// <summary>
    /// Initializes a new instance with the specified from and to values.
    /// </summary>
    /// <param name="from">The start value.</param>
    /// <param name="to">The end value.</param>
    /// <param name="fromToUse">The format to use for the values.</param>
    public FromToCollections(long from, long to, FromToUseCollections fromToUse = FromToUseCollections.DateTime) : base(from, to, fromToUse)
    {
    }
}
