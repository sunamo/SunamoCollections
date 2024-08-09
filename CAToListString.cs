namespace SunamoCollections;

public partial class CA
{
    #region ToListString

    /// <summary>
    ///     Tuto metodu nechat s params
    ///     Mám ji na miliónu místech kde přesně plní svůj účel
    ///     Už ani nevím co byl původní záměr ale zřejmě to byla nějaká debilní myšlenka "všechno udělat jinak než dosud i když
    ///     k tomu není důvod"
    ///     Vlastně ano, už si pamatuji, byl to záměr zbavit se [] a užívat jen List.
    ///     Teď má [ObjectParamsAllowed] a už na ní nikdo nikdy nešáhne.
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    [ObjectParamsAllowed]
    public static List<string> ToListString(params string[] s)
    {
        return new List<string>(s);
    }

    #endregion


    public static List<string> ToListMoreString(params string[] enumerable2)
    {
        return enumerable2.ToList();
    }
}