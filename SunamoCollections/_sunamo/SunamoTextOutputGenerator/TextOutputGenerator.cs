namespace SunamoCollections._sunamo.SunamoTextOutputGenerator;

/// <summary>
///     In Comparing
/// </summary>
internal class TextOutputGenerator //: ITextOutputGenerator
{
    private static readonly string s_znakNadpisu = "*";

    // but it was probably nonsense, now I have Create() in _sunamo, which is null instead of using the ctor
    // so I return it back.
    internal StringBuilder sb = new();

    //internal string prependEveryNoWhite

    public override string ToString()
    {
        var ts = sb.ToString();
        return ts;
    }




    #region Other adding methods



    #endregion

    #region List









    #endregion

    #region Dictionary






    #endregion
}
