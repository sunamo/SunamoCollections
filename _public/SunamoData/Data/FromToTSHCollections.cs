namespace SunamoCollections._public.SunamoData.Data;


public class FromToTSHCollections<T>
{

    public bool empty;
    protected long fromL;
    public FromToUseCollections ftUse = FromToUseCollections.DateTime;
    protected long toL;
    public FromToTSHCollections()
    {
        var t = typeof(T);
        if (t == Types.tInt) ftUse = FromToUseCollections.None;
    }
    
    
    
    
    private FromToTSHCollections(bool empty) : this()
    {
        this.empty = empty;
    }
    
    
    
    
    
    
    
    public FromToTSHCollections(T from, T to, FromToUseCollections ftUse = FromToUseCollections.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
    public T from
    {
        get => (T)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }
    public T to
    {
        get => (T)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }
    public long FromL => fromL;
    public long ToL => toL;
}