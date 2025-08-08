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

    //internal static object FirstOrNull(this IList e)
    //{
    //    if (e.Count > 0)
    //    {
    //        // Here cant call CA.ToList because in FirstOrNull is called in CA.ToList => StackOverflowException
    //        //System.Collections.Generic.List<object> c = CAThread.ToList(e);
    //        //return c.FirstOrDefault();
    //        return e.First2();
    //    }
    //    return null;
    //}

    #endregion

    #region For easy copy from IListExtensionsShared64Sunamo.cs

    
    // todo DumpAsStringHeaderArgs je ve SunamoShared který nemůži přidat do deps protože by to způsobilo chybu Cycle detected

    #region Must be two coz in some projects is not Dispatcher

    //internal static object FirstOrNull(this IList e)
    //{
    //    return se.IListExtensions.FirstOrNull(e);
    //}

    #region Cant be first because then have priority than LINQ method

    
    #endregion

    #endregion


    
    
    #endregion
}