namespace SunamoCollections._public.SunamoData.Data;

public class FromToTSHCollections<T>
{
    public bool Empty { get; set; }

    private long from;

    public FromToUseCollections FromToUse { get; set; } = FromToUseCollections.DateTime;

    private long to;

    public FromToTSHCollections()
    {
        var type = typeof(T);
        if (type == typeof(int)) FromToUse = FromToUseCollections.None;
    }

    private FromToTSHCollections(bool isEmpty) : this()
    {
        Empty = isEmpty;
    }

    public FromToTSHCollections(T from, T to, FromToUseCollections fromToUse = FromToUseCollections.DateTime) : this()
    {
        From = from;
        To = to;
        FromToUse = fromToUse;
    }

    public T From
    {
        get => (T)(dynamic)from!;
        set => from = (long)(dynamic)value!;
    }

    public T To
    {
        get => (T)(dynamic)to!;
        set => to = (long)(dynamic)value!;
    }

    public long FromAsLong => from;

    public long ToAsLong => to;
}
