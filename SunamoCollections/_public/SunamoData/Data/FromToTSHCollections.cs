namespace SunamoCollections._public.SunamoData.Data;

public class FromToTSHCollections<T>
{
    public bool Empty { get; set; }
    private long _from;
    public FromToUseCollections FromToUse { get; set; } = FromToUseCollections.DateTime;
    private long _to;

    public FromToTSHCollections()
    {
        var Type = typeof(T);
        if (Type == typeof(int)) FromToUse = FromToUseCollections.None;
    }


    private FromToTSHCollections(bool empty) : this()
    {
        this.Empty = empty;
    }


    public FromToTSHCollections(T from, T to, FromToUseCollections fromToUse = FromToUseCollections.DateTime) : this()
    {
        this.From = from;
        this.To = to;
        this.FromToUse = fromToUse;
    }

    public T From
    {
        get => (T)(dynamic)_from;
        set => _from = (long)(dynamic)value;
    }

    public T To
    {
        get => (T)(dynamic)_to;
        set => _to = (long)(dynamic)value;
    }

    public long FromAsLong => _from;
    public long ToAsLong => _to;
}