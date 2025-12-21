namespace SunamoCollections._public.SunamoData.Data;

public class FromToCollections : FromToTSHCollections<long>
{
    public static new FromToCollections Empty = new(true);

    public FromToCollections()
    {
    }


    private FromToCollections(bool isEmpty) : base()
    {
        base.Empty = isEmpty;
    }


    public FromToCollections(long from, long to, FromToUseCollections fromToUse = FromToUseCollections.DateTime) : base(from, to, fromToUse)
    {
    }
}