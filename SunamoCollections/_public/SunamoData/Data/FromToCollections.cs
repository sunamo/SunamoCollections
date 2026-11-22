namespace SunamoCollections._public.SunamoData.Data;

/// <summary>
/// Represents the from to collections type.
/// </summary>
public class FromToCollections : FromToTSHCollections<long>
{
    /// <summary>
    /// The empty.
    /// </summary>
    public static new FromToCollections Empty = new(true);

    /// <summary>
    /// From to collections.
    /// </summary>
    /// <param name="true">The true.</param>
    /// <returns>The from to collections result.</returns>
    public FromToCollections()
    {
    }

    private FromToCollections(bool isEmpty) : base()
    {
        base.Empty = isEmpty;
    }

    /// <summary>
    /// From to collections.
    /// </summary>
    /// <param name="from">The from.</param>
    /// <param name="to">The to.</param>
    /// <param name="fromToUse">The from to use.</param>
    /// <returns>The from to collections result.</returns>
    public FromToCollections(long from, long to, FromToUseCollections fromToUse = FromToUseCollections.DateTime) : base(from, to, fromToUse)
    {
    }
}
