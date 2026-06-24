namespace SunamoCollections;

public partial class CA
{
    // This method is intentionally kept with params because it is widely used.
    [ObjectParamsAllowed]
    public static List<string> ToListString(params string[] array)
    {
        return new List<string>(array);
    }

    public static List<string> ToListMoreString(params string[] array)
    {
        return array.ToList();
    }
}
