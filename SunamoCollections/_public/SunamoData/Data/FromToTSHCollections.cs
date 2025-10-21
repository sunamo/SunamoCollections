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
        var type = typeof(type);
        if (type == typeof(int)) ftUse = FromToUseCollections.None;
    }


    private FromToTSHCollections(bool empty) : this()
    {
        this.empty = empty;
    }


    public FromToTSHCollections(type from, type to, FromToUseCollections ftUse = FromToUseCollections.DateTime) : this()
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }

    public type from
    {
        get => (type)(dynamic)fromL;
        set => fromL = (long)(dynamic)value;
    }

    public type to
    {
        get => (type)(dynamic)toL;
        set => toL = (long)(dynamic)value;
    }

    public long FromL => fromL;
    public long ToL => toL;
}