namespace SunamoCollections;

public partial class CA
{
    #region ToListString

    /// <summary>
    ///     Tuto metodu nechat s params
    ///     Mám ji na miliónu místech kde přesně plní svůj účel
    ///     Už ani nevím co byl původní záměr ale zřejmě to byla nějaká debilní myšlenka "všechno udělat jinak než dosud i když
    ///     k tomu není důvod"
    ///     Vlastně ano, už si pamatuji, byl to záměr zbavit se [] a užívat jen list.
    ///     Teď má [ObjectParamsAllowed] a už na ní nikdo nikdy nešáhne.
    /// </summary>
    /// <param name="strings"></param>
    /// <returns></returns>
    [ObjectParamsAllowed]
    public static List<string> ToListString(params string[] strings)
    {
        return new List<string>(strings);
    }

    #endregion


    public static List<string> ToListMoreString(params string[] strings)
    {
        return strings.ToList();
    }
}