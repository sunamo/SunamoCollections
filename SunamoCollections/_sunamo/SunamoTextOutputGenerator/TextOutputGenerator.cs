namespace SunamoCollections._sunamo.SunamoTextOutputGenerator;

/// <summary>
///     In Comparing
/// </summary>
internal class TextOutputGenerator //: ITextOutputGenerator
{
    private static readonly string s_znakNadpisu = "*";

    // ale asi to byla blbost, teď mám v _sunamo Create() která je ale null místo abych použil ctor
    // takže vracím nazpět.
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
