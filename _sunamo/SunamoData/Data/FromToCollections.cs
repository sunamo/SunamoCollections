namespace SunamoCollections;


/// <summary>
///     Must have always entered both from and to
///     None of event could have unlimited time!
/// </summary>
public class FromToCollections : FromToTSHCollections<long>
{
    internal static FromToCollections Empty = new(true);
    internal FromToCollections()
    {
    }
    /// <summary>
    ///     Use Empty contstant outside of class
    /// </summary>
    /// <param name="empty"></param>
    private FromToCollections(bool empty)
    {
        this.empty = empty;
    }
    /// <summary>
    ///     A3 true = DateTime
    ///     A3 False = None
    /// </summary>
    /// <param name="from"></param>
    /// <param name="to"></param>
    /// <param name="ftUse"></param>
    internal FromToCollections(long from, long to, FromToUseCollections ftUse = FromToUseCollections.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}