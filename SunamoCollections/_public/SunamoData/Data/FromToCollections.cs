// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoCollections._public.SunamoData.Data;

public class FromToCollections : FromToTSHCollections<long>
{
    public static FromToCollections Empty = new(true);

    public FromToCollections()
    {
    }


    private FromToCollections(bool empty)
    {
        this.empty = empty;
    }


    public FromToCollections(long from, long to, FromToUseCollections ftUse = FromToUseCollections.DateTime)
    {
        this.from = from;
        this.to = to;
        this.ftUse = ftUse;
    }
}