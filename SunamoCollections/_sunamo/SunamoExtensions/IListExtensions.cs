namespace SunamoCollections._sunamo.SunamoExtensions;

internal static class IListExtensions
{

    internal static object FirstOrNull(this IEnumerable e)
    {
        foreach (var item in e) return item;
        return null;
    }

    internal static int Count(this IEnumerable e)
    {
        var i = 0;
        foreach (var item in e) i++;
        return i;
    }





    
    #region from IListExtensionsShared64.cs


    #endregion

    #region For easy copy from IListExtensionsShared64Sunamo.cs

    
    // todo DumpAsStringHeaderArgs is in SunamoShared, which I cannot add to deps because it would cause a Cycle detected error

    #region Must be two coz in some projects is not Dispatcher


    #region Cant be first because then have priority than LINQ method

    
    #endregion

    #endregion


    
    
    #endregion
}