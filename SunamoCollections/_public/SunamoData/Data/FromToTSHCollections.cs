// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy

namespace SunamoCollections._public.SunamoData.Data;

public class FromToTSHCollections<T>
{
    public bool empty;
    protected long fromL;
    public FromToUseCollections ftUse = FromToUseCollections.DateTime;
    protected long toL;

    public FromToTSHCollections()
    {
        var type = typeof(T);
        if (type == typeof(int)) ftUse = FromToUseCollections.None;
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